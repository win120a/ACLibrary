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

using System.Security.Cryptography;

namespace ACLibrary.Crypto.CryptoProviders
{
    /// <summary>
    /// The DES encryption provider.
    /// </summary>
    public sealed class DESProvider : SymmetricCryptoProvider, ICryptoProvider
    {
        private DESProvider() { }
        private static DESProvider instance;

        public static DESProvider Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = DESProvider.Instance;
                }
                return instance;
            }
        }

        private CipherInitiator ci = () => new TripleDESCryptoServiceProvider();

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
