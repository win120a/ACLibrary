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

using System;
using System.Collections;
using System.Collections.Generic;

namespace ACLibrary.Collection
{
    /// <summary>
    /// A extended HashSet object.
    /// </summary>
    /// <typeparam name="Element">The element.</typeparam>
    public class ACHashSet<Element> : HashSet<Element>, IACCollection<Element>
    {
        /// <summary>
        /// Check the dictionary is empty.
        /// </summary>
        /// <returns>The result.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// Add all items in a collection to this set.
        /// </summary>
        /// <typeparam name="E">The element.</typeparam>
        /// <param name="c">The collection.</param>
        public void AddAll<E>(ICollection<E> c) where E : Element
        {
            if (c is IDictionary)
            {
                throw new NotSupportedException();
            }

            foreach (E e in c)
            {
                Add(e);
            }
        }

        /// <summary>
        /// Convert the system collection (HashSet) to AC Collection (ACHashSet).
        /// </summary>
        /// <param name="c">The system collection.</param>
        /// <returns>A AC Collection contains all elements in system collection.</returns>
        public static ACHashSet<Element> SystemCollection2ACCollection(ICollection<Element> c)
        {
            ACHashSet<Element> ahs = new ACHashSet<Element>();

            foreach (Element e in c)
            {
                ahs.Add(e);
            }

            return ahs;
        }

        /// <summary>
        /// Convert the AC collection (ACHashSet) to system Collection (HashSet).
        /// </summary>
        /// <returns>A system Collection contains all elements in AC collection.</returns>
        public ICollection<Element> ToSystemCollection()
        {
            HashSet<Element> hs = new HashSet<Element>();

            foreach (Element e in this)
            {
                hs.Add(e);
            }

            return hs;
        }

        /// <summary>
        /// Add all system collection items to this collection.
        /// </summary>
        /// <param name="c">The system collection.</param>
        public void AddAllSystemCollectionItems(ICollection<Element> c)
        {
            foreach (Element e in c)
            {
                Add(e);
            }
        }

        /// <summary>
        /// Check the element exists or not.
        /// </summary>
        /// <param name="pe">The element.</param>
        /// <returns>If exists, true; otherwise, false.</returns>
        public bool Exists(Element pe)
        {
            bool flag = false;

            foreach (Element e in this)
            {
                if (Object.Equals(pe, e))
                {
                    flag = true;
                }
            }

            return flag;
        }
    }
}
