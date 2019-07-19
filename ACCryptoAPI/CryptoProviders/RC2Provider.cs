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
    /// <summary>
    /// The RC2 encryption provider.
    /// </summary>
    public class RC2Provider : SymmetricCryptoProvider, ICryptoProvider
    {
        private RC2Provider() { }
        private static RC2Provider instance;

        public static RC2Provider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RC2Provider();
                }
                return instance;
            }
        }

        private CipherInitiator ci = () => new RC2CryptoServiceProvider();

        /// <summary>
        /// The Encryption method.
        /// </summary>
        /// <param name="plainText">The string to encrypt.</param>
        /// <param name="password">The password.</param>
        /// <returns>The encrypted string.</returns>
        public string EncryptString(string plainText, string password)
        {
            return Encrypt(plainText, password, ci);
        }

        /// <summary>
        /// The Decryption method.
        /// </summary>
        /// <param name="encryptedText">The string to decrypt.</param>
        /// <param name="password">The password.</param>
        /// <returns>The decrypted string.</returns>
        public string DecryptString(string encryptedText, string password)
        {
            return Decrypt(encryptedText, password, ci);
        }
    }
}
