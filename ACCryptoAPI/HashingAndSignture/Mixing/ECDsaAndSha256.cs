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

using ACLibrary.Crypto.HashingAndSignture.Providers;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ACLibrary.Crypto.HashingAndSignture.Mixing
{
    public class ECDsaAndSha256
    {
        public bool Check(string signFile, string verifyFile, string ecdSaKeyFile)
        {
            StreamReader sr = new StreamReader(signFile);
            string result = sr.ReadToEnd();
            sr.Close();

            if (!result.StartsWith("=== Start ECDSA Sign ==="))
            {
                throw new InvalidDataException();
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(result);

            sb.Replace("=== Start ECDSA Sign ===", "");
            sb.Replace("=== End ECDSA Sign ===", "\\");
            sb.Replace("=== Start Sha256 Sign ===", "");
            sb.Replace("=== End Sha256 Sign ===", "");

            string APResult = sb.ToString().Trim();
            string[] diffSign = APResult.Split('\\');

            StreamReader ecdKSR = new StreamReader(ecdSaKeyFile);
            String s = ecdKSR.ReadToEnd();
            ecdKSR.Close();

            ECDsaProvider esa = ECDsaProvider.CreateUseAXMLKeyFile(s);
            bool esaRe = esa.VerifyBytes(diffSign[0], verifyFile);

            SHA256Provider s256 = new SHA256Provider();
            byte[] s256R = s256.ComputeFile(verifyFile);

            bool s256Re = true;

            string[] signBlockStrArray = diffSign[1].Split(',');

            byte[] signBlock = new byte[signBlockStrArray.Length];

            int i = 0;

            foreach (string item in signBlockStrArray)
            {
                signBlock[i] = byte.Parse(item);
                i++;
            }

            i = 0;
            foreach (byte b1 in signBlock)
            {
                if (b1 != signBlock[i])
                {
                    s256Re = false;
                }
                i++;
            }

            return s256Re & esaRe;
        }

        //public void SignUseAPrivateKey(string signFile, string needToSignFile, string ecdSaKeyFile)
        //{
        //    SHA256Provider s256 = new SHA256Provider();
        //    byte[] s256R = s256.ComputeFile(needToSignFile);

        //    StreamReader sr = new StreamReader(ecdSaKeyFile);
        //    String s = sr.ReadToEnd();
        //    sr.Close();

        //    ECDsaProvider esa = ECDsaProvider.CreateUseAXMLKeyFile(s);

        //    byte[] sign = esa.SignFile(needToSignFile);

        //    File.Create(signFile).Close();

        //    StreamWriter sw = new StreamWriter(signFile);

        //    sw.WriteLine("=== Start ECDSA Sign ===");

        //    int i = 0;
        //    foreach (byte b in sign)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(b);
        //        sw.Write(sb.ToString());
        //        if ((sign.Length - 1) != i)
        //        {
        //            sw.Write(',');
        //        }
        //        i++;
        //    }

        //    sw.WriteLine();

        //    sw.WriteLine("=== End ECDSA Sign ===");

        //    sw.WriteLine();

        //    sw.WriteLine("=== Start Sha256 Sign ===");
        //    i = 0;
        //    foreach (byte b in s256R)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(b);
        //        sw.Write(sb.ToString());
        //        if ((s256R.Length - 1) != i)
        //        {
        //            sw.Write(',');
        //        }
        //        i++;
        //    }
        //    sw.WriteLine();

        //    sw.Write("=== End Sha256 Sign ===");

        //    sw.Close();
        //}

        public string SignAsNewKeyAndExportPublicKeyAsXml(string signFile, string needToSignFile, string keyName)
        {
            SHA256Provider s256 = new SHA256Provider();
            byte[] s256R = s256.ComputeFile(needToSignFile);

            ECDsaProvider esa = new ECDsaProvider(keyName, null);

            CngKey k = esa.Key;

            byte[] sign = esa.SignFile(needToSignFile);

            File.Create(signFile).Close();

            StreamWriter sw = new StreamWriter(signFile);

            sw.WriteLine("=== Start ECDSA Sign ===");

            int i = 0;
            foreach (byte b in sign)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(b);
                sw.Write(sb.ToString());
                if ((sign.Length - 1) != i)
                {
                    sw.Write(',');
                }
                i++;
            }

            sw.WriteLine();

            sw.WriteLine("=== End ECDSA Sign ===");

            sw.WriteLine();

            sw.WriteLine("=== Start Sha256 Sign ===");
            i = 0;
            foreach (byte b in s256R)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(b);
                sw.Write(sb.ToString());
                if ((s256R.Length - 1) != i)
                {
                    sw.Write(',');
                }
                i++;
            }
            sw.WriteLine();

            sw.Write("=== End Sha256 Sign ===");

            sw.Close();

            return esa.ToXmlString;
        }
    }
}
