using ACLibrary.Collection;
using System;
using System.Windows.Controls;

namespace ACLibrary.GUI.WPF
{
    /// <summary>
    /// Stores the comboBox's Data (In WPF) and help it shows.
    /// </summary>
    public class ComboBoxData : ACDictionary<string,int>
    {
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
