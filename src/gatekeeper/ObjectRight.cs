using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of ObjectRight Class.
    /// </summary>
	public class ObjectRight:BaseEntity
    {

        /// <summary>
        /// Initializes a new instance of the ObjectRight class.
        /// </summary>
        public ObjectRight()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ObjectRight class with two parameters.
        /// </summary>
        /// <param name="securableObjectGUID">The securable object GUID,object if Guid class.</param>
        /// <param name="right">The right,object of Right Class.</param>
        public ObjectRight(long securableObjectId, Right right)
        {
            this.Right = right;
            this.SecurableObjectId = securableObjectId;
         
        }

        /// <summary>
        /// Initializes a new instance of the ObjectRight class with two parameters.
        /// </summary>
        /// <param name="securableObjectGUID">The securable object GUID.</param>
        /// <param name="rightName">Name of the right.</param>
        public ObjectRight(long securableObjectId, string rightName)
        {
            this.Right = new Right();
            this.Right.Name = rightName;
            this.SecurableObjectId = securableObjectId;
            
        }

        /// <summary>
        /// Initializes a new instance of the ObjectRight class with two parameters.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        /// <param name="right">The right.</param>
        public ObjectRight(ISecurableObject securableObject, Right right) :
            this(securableObject.SecurableObjectId, right)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ObjectRight class with parameters.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        /// <param name="rightName">Name of the right.</param>
        public ObjectRight(ISecurableObject securableObject, string rightName): 
            this(securableObject.SecurableObjectId, rightName)
        {
        }

        /// <summary>
        /// Gets or sets the securable object GUID.
        /// </summary>
        /// <value>The securable object GUID.</value>
        public long SecurableObjectId { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>The right.</value>
        public Right Right { get; set; }

    }
}
