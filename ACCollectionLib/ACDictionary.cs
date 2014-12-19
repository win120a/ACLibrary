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
    public class ACDictionary<K, V> : Dictionary<K, V>
    {
        public V Get(K key)
        {
            return this[key];
        }

        public HashSet<K> KeySet()
        {
            HashSet<K> ks = new HashSet<K>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                ks.Add(kp.Key);
            }

            return ks;
        }

        public HashSet<V> ValueSet()
        {
            HashSet<V> vs = new HashSet<V>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                vs.Add(kp.Value);
            }

            return vs;
        }

        public List<K> KeyList()
        {
            List<K> kl = new List<K>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                kl.Add(kp.Key);
            }

            return kl;
        }

        public List<V> ValueList()
        {
            List<V> vl = new List<V>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                vl.Add(kp.Value);
            }

            return vl;
        }
    }
}
