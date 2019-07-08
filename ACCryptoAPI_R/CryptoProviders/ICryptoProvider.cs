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

namespace ACLibrary.Crypto.CryptoProviders
{
    /// <summary>
    /// The base interface of all crypto providers in this library.
    /// </summary>
    public interface ICryptoProvider
    {
        /// <summary>
        /// The Encryption method.
        /// </summary>
        /// <param name="plainText">The string to encrypt.</param>
        /// <param name="password">The password.</param>
        /// <returns>The encrypted string.</returns>
        string EncryptString(string plainText, string password);

        /// <summary>
        /// The Decryption method.
        /// </summary>
        /// <param name="encryptedText">The string to decrypt.</param>
        /// <param name="password">The password.</param>
        /// <returns>The decrypted string.</returns>
        string DecryptString(string encryptedText, string password);
    }
}
