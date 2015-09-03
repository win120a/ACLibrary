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

using ACLibrary.Crypto.HashingAndSignture.Mixing;
using System;

namespace TestSignApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Init Code ////
            ECDsaAndSha256 p = new ECDsaAndSha256();

            //StreamWriter sw = new StreamWriter("F:\\xmlpubkey.xml");
            //sw.Write(p.SignAsNewKeyAndExportPublicKeyAsXml("F:\\ecdsatest.sig", "F:\\gpg4win-2.2.1.exe", "TestKey"));
            //sw.Close();

            //// Test Code ////
            Console.WriteLine(p.Check("F:\\ecdsatest.sig", "F:\\gpg4win-2.2.1.exe", "F:\\xmlpubkey.xml"));

            Console.ReadKey();
        }
    }
}
