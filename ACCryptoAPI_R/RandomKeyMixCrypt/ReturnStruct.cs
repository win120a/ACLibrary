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


namespace ACLibrary.Crypto.RandomKeyMixCrypt
{
    public struct ReturnStruct
    {
        private string result;
        private int[] randomKeys;

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        public int[] RandomKeys
        {
            get
            {
                return randomKeys;
            }
            set
            {
                randomKeys = value;
            }
        }
    }
}
