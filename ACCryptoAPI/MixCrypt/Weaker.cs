/*
   Copyright (C) 2011-2015 AC Inc. (Andy Cheung)

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

using ACLibrary.Crypto.CryptoProviders;
using System;

namespace ACLibrary.Crypto
{
    namespace MixCryptSeries
    {
        /// <summary>
        /// The Weaker MixCrypt encryption class. (3AES)
        /// </summary>
        public class Weaker : MixCryptBase
        {
            /// <summary>
            /// The Encryption method.
            /// </summary>
            /// <param name="plainText">The string to encrypt.</param>
            /// <param name="password">The password.</param>
            /// <returns>The encrypted string.</returns>
            public String EncryptString(String plainText, String password)
            {
                // 3AES
                AESProvider aes = new AESProvider();
                string aes1 = aes.EncryptString(plainText, password);
                string aes2 = aes.EncryptString(aes1, password);
                string aes3 = aes.EncryptString(aes2, password);
                return aes3;

                // Use Casts: aes(aes(aes($content)));
            }

            /// <summary>
            /// The Decryption method.
            /// </summary>
            /// <param name="Source">The string to decrypt.</param>
            /// <param name="password">The password.</param>
            /// <returns>The decrypted string.</returns>
            public String DecryptString(String Source, String password)
            {
                // string plain = testEncrypt.DecryptString(encText, password);

                // 3AES
                AESProvider aes = new AESProvider();
                string aes1 = aes.DecryptString(Source, password);
                string aes2 = aes.DecryptString(aes1, password);
                string aes3 = aes.DecryptString(aes2, password);
                return aes3;
            }
        }
    }

}
