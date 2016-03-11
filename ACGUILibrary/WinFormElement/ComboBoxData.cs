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

using ACLibrary.Collection;
using System;
using System.Windows.Forms;

namespace ACLibrary.GUI.WinFormElement
{
    /// <summary>
    /// Stores the comboBox's Data (In windows form) and help it shows.
    /// </summary>
    public class ComboBoxData : ACDictionary<string, int>
    {
        // ComboBox

        /// <summary>
        /// Add a option to collection and without set id.
        /// </summary>
        /// <param name="s">The option string.</param>
        /// <returns>The option id.</returns>
        public int Add(string s)
        {
            int id = GetBiggestId() + 1;  // Assign ID.
            Add(s, id); // Add to collection.
            return id; // Return id.
        }

        /// <summary>
        /// Get the biggest id in the collection.
        /// </summary>
        /// <returns>The biggest ID.</returns>
        private int GetBiggestId()
        {
            int biggest = 0;   // Init the var.
            foreach (int i in this.ValueList())
            {
                if (i > biggest)
                {
                    biggest = i;   // Set the biggest id.
                }
            }
            return biggest; // Return it.
        }

        /// <summary>
        /// Fill the string collection to the combobox, and clear all items in the collection.
        /// </summary>
        /// <param name="cb">The ComboBox</param>
        public void FillToComboBoxAndClear(ComboBox cb)
        {
            foreach (string s in KeySet())
            {
                cb.Items.Add(s);
            }
            Clear();
        }

        /// <summary>
        /// Fill the string collection to the combobox, but won't clear all items in the collection.
        /// </summary>
        /// <param name="cb">The ComboBox</param>
        public void FillToComboBox(ComboBox cb)
        {
            foreach (string s in KeySet())
            {
                cb.Items.Add(s);
            }
        }

        /// <summary>
        /// Get the option ID, and it won't cause exception.
        /// If you invoke FillToComboBoxAndClear(), this method will not work.
        /// </summary>
        /// <param name="optionText">The option Text.</param>
        /// <returns>If it exists, return the id. Otherwise, return -1.</returns>
        public int SecureGetOptionId(string optionText)
        {
            try
            {
                return Get(optionText);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
