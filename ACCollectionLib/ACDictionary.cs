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
    /// <summary>
    /// A extended Dictionary object.
    /// </summary>
    /// <typeparam name="K">The key.</typeparam>
    /// <typeparam name="V">The value.</typeparam>
    public class ACDictionary<K, V> : Dictionary<K, V>, IACCollection<KeyValuePair<K, V>>
    {
        /// <summary>
        /// Get the value of key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The key of value.</returns>
        public V Get(K key)
        {
            return this[key];
        }

        /// <summary>
        /// Get the key of value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The key.</returns>
        public K GetKeyByValue(V value)
        {
            foreach (K k in KeyList())
            {
                if (Equals(Get(k), value))
                {
                    return k;
                }
            }
            return default(K);
        }

        /// <summary>
        /// Get a set of key.
        /// </summary>
        /// <returns>A set of keys.</returns>
        public HashSet<K> KeySet()
        {
            HashSet<K> ks = new HashSet<K>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                ks.Add(kp.Key);
            }

            return ks;
        }

        /// <summary>
        /// Get a set of value.
        /// </summary>
        /// <returns>A set of values.</returns>
        public HashSet<V> ValueSet()
        {
            HashSet<V> vs = new HashSet<V>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                vs.Add(kp.Value);
            }

            return vs;
        }

        /// <summary>
        /// Get a list of key.
        /// </summary>
        /// <returns>A list of keys.</returns>
        public List<K> KeyList()
        {
            List<K> kl = new List<K>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                kl.Add(kp.Key);
            }

            return kl;
        }

        /// <summary>
        /// Get a list of value.
        /// </summary>
        /// <returns>A list of values.</returns>
        public List<V> ValueList()
        {
            List<V> vl = new List<V>();

            foreach (KeyValuePair<K, V> kp in this)
            {
                vl.Add(kp.Value);
            }

            return vl;
        }

        /// <summary>
        /// Check the dictionary is empty.
        /// </summary>
        /// <returns>The result.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// Add all system collection items to this collection.
        /// </summary>
        /// <param name="c">The system collection.</param>
        public void AddAllSystemCollectionItems(ICollection<KeyValuePair<K, V>> c)
        {
            foreach (KeyValuePair<K, V> kvp in c)
            {
                Add(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Convert the AC collection (ACDictionary) to system Collection (Dictonary).
        /// </summary>
        /// <returns>A system Collection contains all elements in AC collection.</returns>
        public ICollection<KeyValuePair<K, V>> ToSystemCollection()
        {
            Dictionary<K, V> d = new Dictionary<K, V>();

            List<K> keyList = KeyList();

            foreach (K k in keyList)
            {
                d.Add(k, Get(k));
            }

            return d;
        }

        /// <summary>
        /// Convert the system collection (Dictionary) to AC Collection (ACDictionary).
        /// </summary>
        /// <param name="c">The system collection.</param>
        /// <returns>A AC Collection contains all elements in system collection.</returns>
        public static IACCollection<KeyValuePair<K, V>> SystemCollection2ACCollection(ICollection<KeyValuePair<K, V>> c)
        {
            ACDictionary<K, V> ad = new ACDictionary<K, V>();

            foreach (KeyValuePair<K, V> kvp in c)
            {
                ad.Add(kvp.Key, kvp.Value);
            }

            return ad;
        }

        /// <summary>
        /// Check the key exists or not.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>If exists, true; otherwise, false.</returns>
        public bool Exists(K key)
        {
            V test = default(V);

            if (TryGetValue(key, out test))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
