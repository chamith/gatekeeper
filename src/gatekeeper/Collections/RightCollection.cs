using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Gatekeeper.Collections
{
    /// <summary>
    /// Summary of  RightCollection.Represents a collection of rights.
    /// </summary>
    public class RightCollection: KeyedCollection<long,Right>
    {
        /// <summary>
        /// Initializes a new instance of the RightCollection class.
        /// </summary>
        public RightCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RightCollection class with rights as parameters.
        /// </summary>
        /// <param name="rights">The right,Ilist collection of class Right.</param>
        public RightCollection(IList<Right> rights)
        {
            foreach (Right right in rights)
                this.Add(right);
        }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override long GetKeyForItem(Right item)
        {
            return item.Id;
        }
    }
}
