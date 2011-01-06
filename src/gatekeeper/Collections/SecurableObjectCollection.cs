using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{
 
    /// <summary>
    /// Summary of  SecurableObjectCollection class.It represents a collection of securable objects.
    /// </summary>
    public class SecurableObjectCollection:List<ISecurableObject>
    {

        /// <summary>
        /// Initializes a new instance of the SecurableObjectCollection.
        /// </summary>
        public SecurableObjectCollection() { }


        /// <summary>
        /// Initializes a new instance of the SecurableObjectCollection class with securableObjects as parameters.
        /// </summary>
        /// <param name="securableObjects">The securableObject,Ilist collection of class ISecurableObject.</param>
        public SecurableObjectCollection(IList<ISecurableObject> securableObjects)
        {
            this.AddRange(securableObjects);
        }
    }
}
