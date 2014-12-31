/*
   Copyright (C) 2011-2014 AC Inc. (Andy Cheung)

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

namespace ACLibrary.Crypto.Utils
{
    /// <summary>
    /// The entry class of string encryption.
    /// </summary>
    public class StringCryptoEntry
    {
        /// <summary>
        /// The encryption method.
        /// </summary>
        /// <param name="icp">The encryption Provider.</param>
        /// <param name="otext">The original text.</param>
        /// <param name="psw">The password.</param>
        /// <returns>The encrypted text.</returns>
        public static string Encrypt(ICryptoProvider icp, string otext, string psw)
        {
            return icp.EncryptString(otext, psw);
        }

        /// <summary>
        /// The decryption method.
        /// </summary>
        /// <param name="icp">The encryption Provider.</param>
        /// <param name="otext">The original text.</param>
        /// <param name="psw">The password.</param>
        /// <returns>The decrypted text.</returns>
        public static string Decrypt(ICryptoProvider icp, string otext, string psw)
        {
            return icp.DecryptString(otext, psw);
        }
    }
}
