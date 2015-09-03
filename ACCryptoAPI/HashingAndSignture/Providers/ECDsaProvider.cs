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

using System;
using System.IO;
using System.Security.Cryptography;

namespace ACLibrary.Crypto.HashingAndSignture.Providers
{
    public class ECDsaProvider : CngProvider
    {
        private ECDsaCng instance;

        public ECDsaProvider(string keyPath)
        {
            byte[] keyBlock = ImportKeyFromFile(keyPath);

            CngKey ck = CngKey.Import(keyBlock, CngKeyBlobFormat.EccPrivateBlob);

            instance = new ECDsaCng(ck);
        }

        public ECDsaProvider(string newKeyName, string nullAble)
        {
            if (CngKey.Exists(newKeyName))
            {
                instance = new ECDsaCng(CngKey.Open(newKeyName));
            }
            else
            {
                CngKeyCreationParameters p = new CngKeyCreationParameters();
                p.ExportPolicy = CngExportPolicies.AllowExport;
                instance = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP521, newKeyName, p));
            }
        }

        public ECDsaProvider()
        {
            new ECDsaProvider("myKey", null);
        }

        private ECDsaProvider(int nr)
        {
            instance = new ECDsaCng();
        }

        public static ECDsaProvider CreateUseAXMLKeyFile(string xml)
        {
            ECDsaProvider p = new ECDsaProvider(0);
            p.instance.FromXmlString(xml, ECKeyXmlFormat.Rfc4050);
            return p;
        }

        public CngKey Key
        {
            get
            {
                return instance.Key;
            }
        }

        public string ToXmlString
        {
            get
            {
                return instance.ToXmlString(ECKeyXmlFormat.Rfc4050);
            }
        }

        public byte[] SignFile(string path)
        {
            StreamReader sr = new StreamReader(path);

            byte[] b = null;

            try
            {
                b = instance.SignData(sr.BaseStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
           
            sr.Close();

            return b;
        }

        public bool VerifyFile(string path, string signPath)
        {
            StreamReader sr = new StreamReader(signPath);

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

            return instance.VerifyData(new StreamReader(path).BaseStream, keyBlock);
        }

        public bool VerifyBytes(string sign, string file)
        {
            string[] signBlockStrArray = sign.Split(',');

            byte[] signBlock = new byte[signBlockStrArray.Length];

            int i = 0;

            foreach (string item in signBlockStrArray)
            {
                signBlock[i] = byte.Parse(item);
                i++;
            }

            StreamReader sr = new StreamReader(file);

            bool result = instance.VerifyData(sr.BaseStream, signBlock);

            sr.Close();

            return result;
        }
    }
}
