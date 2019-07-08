using System.Collections.Generic;

namespace ACLibrary.Collection
{
    /// <summary>
    /// A interface marks an AC Collection.
    /// </summary>
    /// <typeparam name="E">The element.</typeparam>
    public interface IACCollection<E>
    {
        /// <summary>
        /// Add all system collection items to this collection.
        /// </summary>
        /// <param name="c">The system collection.</param>
        void AddAllSystemCollectionItems(ICollection<E> c);

        /// <summary>
        /// Convert the AC collection (ACDictionary) to system Collection (Dictonary).
        /// </summary>
        /// <returns>A system Collection contains all elements in AC collection.</returns>
        ICollection<E> ToSystemCollection();
    }
}
