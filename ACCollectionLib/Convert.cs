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

using System.Collections.Generic;

namespace ACLibrary.Collection
{
    public class Convert
    {
        public static class KeyValueConvert<K, V>
        {
            public static ACDictionary<K, V> DictionaryToACDictionary(Dictionary<K, V> od)
            {
                ACDictionary<K, V> acd = new ACDictionary<K, V>();

                foreach (KeyValuePair<K, V> kvp in od)
                {
                    acd.Add(kvp.Key, kvp.Value);
                }

                return acd;
            }

            public static Dictionary<K, V> ACDictionaryToDictionary(ACDictionary<K, V> od)
            {
                Dictionary<K, V> d = new Dictionary<K, V>();

                List<K> keyList = od.KeyList();

                foreach (K k in keyList)
                {
                    d.Add(k, od.Get(k));
                }

                return d;
            }
        }
    }
}
