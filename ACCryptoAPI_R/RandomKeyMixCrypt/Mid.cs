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
using ACLibrary.TypeConvert;
using System;
using System.Collections.Generic;

namespace ACLibrary.Crypto.RandomKeyMixCrypt
{
    public class Mid : IRandomKeyMixCryptBase
    {
        /// <summary>
        /// The Encryption method.
        /// </summary>
        /// <param name="plainText">The string to encrypt.</param>
        /// <param name="password">The password.</param>
        /// <returns>The encrypted string.</returns>
        public ReturnStruct EncryptString(String plainText, String partPassword)
        {
            List<int> ril = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 6; i++)
            {
                ril.Add(r.Next(0, 10));
            }

            List<string> sl = NumberConverter.IntCollectionToStringList(ril);

            // 3DES
            DESProvider des = DESProvider.Instance;
            string des1 = des.EncryptString(plainText, partPassword + sl[0]);
            string des2 = des.EncryptString(des1, partPassword + sl[1]);
            string des3 = des.EncryptString(des2, partPassword + sl[2]);

            // 3AES
            AESProvider aes = AESProvider.Instance;
            string aes1 = aes.EncryptString(des3, partPassword + sl[3]);
            string aes2 = aes.EncryptString(aes1, partPassword + sl[4]);
            string aes3 = aes.EncryptString(aes2, partPassword + sl[5]);

            ReturnStruct rs = new ReturnStruct();

            rs.Result = aes3;
            rs.RandomKeys = ril.ToArray();

            return rs;

            // Use Casts: aes(aes(aes(des(des(des($content))))));
        }

        /// <summary>
        /// The Decryption method.
        /// </summary>
        /// <param name="Source">The string to decrypt.</param>
        /// <param name="password">The password.</param>
        /// <returns>The decrypted string.</returns>
        public String DecryptString(String Source, String password, int[] rKeys)
        {
            // string plain = testEncrypt.DecryptString(encText, password);

            // 3AES
            AESProvider aes = AESProvider.Instance;
            string aes1 = aes.DecryptString(Source, password + rKeys[5]);
            string aes2 = aes.DecryptString(aes1, password + rKeys[4]);
            string aes3 = aes.DecryptString(aes2, password + rKeys[3]);

            // 3DES
            DESProvider des = DESProvider.Instance;
            string des1 = des.DecryptString(aes3, password + rKeys[2]);
            string des2 = des.DecryptString(des1, password + rKeys[1]);
            string des3 = des.DecryptString(des2, password + rKeys[0]);

            return des3;
        }
    }
}
