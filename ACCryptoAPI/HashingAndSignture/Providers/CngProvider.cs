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

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ACLibrary.Crypto.HashingAndSignture.Providers
{
    public abstract class CngProvider
    {
        private CngKey GenerateCngKey(CngAlgorithm ca)
        {
            return CngKey.Create(ca);
        }

        public string GenerateCngKeyAsString(CngAlgorithm ca, CngKeyBlobFormat cbf)
        {
            CngKey ck = GenerateCngKey(ca);

            byte[] b = ck.Export(cbf);

            string[] s = new string[b.Length];

            int i = 0;
            foreach (byte v in b)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(v);

                s[i] = sb.ToString();
            }

            StringBuilder strb = new StringBuilder();

            foreach (string st in s)
            {
                strb.Append(st);
                strb.Append(',');
            }

            return strb.ToString();
        }

        public void GenerateAndExportAsFile(string path, CngAlgorithm ca, CngKeyBlobFormat cbf)
        {
            StreamWriter sw = new StreamWriter(path);

            sw.Write(GenerateCngKeyAsString(ca, cbf));

            sw.Close();
        }

        public byte[] ImportKeyFromFile(string keyPath)
        {
            StreamReader sr = new StreamReader(keyPath);

            string keyBlockStr = sr.ReadToEnd();
            sr.Close();

            string[] keyBlockStrArray = keyBlockStr.Split(',');

            byte[] keyBlock = new byte[keyBlockStrArray.Length];

            int i = 0;

            foreach (string item in keyBlockStrArray)
            {
                keyBlock[i] = byte.Parse(item);
                i++;
            }

            return keyBlock;
        }
    }
}
