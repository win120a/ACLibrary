/*
   Copyright (C) 2011-2019 Andy Cheung

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

/*
 * Based on MVA's 20 C# Question Explained.
 * Copyright (C) Microsoft Corporation
 */

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ACLibrary.Crypto.CryptoProviders
{
    public abstract class SymmetricCryptoProvider
    {
        protected void InitCipherObject(SymmetricAlgorithm alg, string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            alg.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            alg.IV = new byte[alg.BlockSize / 8];
        }

        public delegate SymmetricAlgorithm CipherInitiator();

        internal string Encrypt(string plainText, string password, CipherInitiator ci)
        {
            // first we convert the plain text into a byte array
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);

            // use a memory stream to hold the bytes
            MemoryStream myStream = new MemoryStream();

            // create the key and initialization vector using the password
            SymmetricAlgorithm sa = ci();
            InitCipherObject(sa, password);

            // create the encoder that will write to the memory stream
            CryptoStream cryptStream = new CryptoStream(myStream, sa.CreateEncryptor(), CryptoStreamMode.Write);

            // we now use the crypto stream to write our byte array to the memory stream
            cryptStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptStream.FlushFinalBlock();

            // change the encrypted stream to a printable version of our encrypted string
            return Convert.ToBase64String(myStream.ToArray());
        }

        internal string Decrypt(string encryptedText, string password, CipherInitiator ci)
        {
            // convert our encrypted string to a byte array
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            // create a memory stream to hold the bytes
            MemoryStream myStream = new MemoryStream();

            // create the key and initialization vector using the password
            SymmetricAlgorithm sa = ci();
            InitCipherObject(sa, password);

            // create our decoder to write to the stream
            CryptoStream decryptStream = new CryptoStream(myStream, sa.CreateDecryptor(), CryptoStreamMode.Write);

            // we now use the crypto stream to the byte array
            decryptStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            decryptStream.FlushFinalBlock();

            // convert our stream to a string value
            return Encoding.Unicode.GetString(myStream.ToArray());
        }
    }
}
