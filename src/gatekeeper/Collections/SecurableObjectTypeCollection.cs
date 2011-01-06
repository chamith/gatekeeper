using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Gatekeeper.Collections
{

    /// <summary>
    /// Summary of SecurableObjectTypeCollection.It represents a collection of securable object types.
    /// </summary>
    public class SecurableObjectTypeCollection : KeyedCollection<long, SecurableObjectType>
    {

        /// <summary>
        /// Initializes a new instance of the SecurableObjectTypeCollection class.
        /// </summary>
        public SecurableObjectTypeCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SecurableObjectTypeCollection class.
        /// </summary>
        /// <param name="securableObjectTypes">The securable object types,Ilist collection of SecurableObjectType class.</param>
        public SecurableObjectTypeCollection(IList<SecurableObjectType> securableObjectTypes)
        {
            foreach (SecurableObjectType securableObjectType in securableObjectTypes)
                this.Add(securableObjectType);
        }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override long GetKeyForItem(SecurableObjectType item)
        {
            return item.Id;
        }
    }
}
