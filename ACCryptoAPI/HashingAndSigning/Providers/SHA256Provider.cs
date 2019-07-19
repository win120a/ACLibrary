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

using System.IO;
using System.Security.Cryptography;

namespace ACLibrary.Crypto.HashingAndSigning.Providers
{
    /// <summary>
    /// Provides SHA256 hashing functions.
    /// </summary>
    public class SHA256Provider : CngProvider
    {
        SHA256Cng instance = new SHA256Cng();

        /// <summary>
        /// Compute Hash of the file.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash.</returns>
        public byte[] ComputeFile(string path)
        {
            StreamReader sr = new StreamReader(path);

            byte[] b = instance.ComputeHash(sr.BaseStream);

            sr.Close();

            return b;
        }

        /// <summary>
        /// Compute Hash of the byte array.
        /// </summary>
        /// <param name="path">The data.</param>
        /// <returns>The hash.</returns>
        public byte[] ComputeHash(byte[] data)
        {
            return instance.ComputeHash(data);
        }
    }
}
