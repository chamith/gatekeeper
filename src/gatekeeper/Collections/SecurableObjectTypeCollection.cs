using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Gatekeeper.Collections
{



    /// <summary>
    /// Summary of SecurableObjectTypeCollection.It represents a collection of securable object types.
    /// </summary>
    /// <remarks>
    /// 	<para>
    /// 		<list type="table">
    /// 			<listheader>
    /// 				<description>modified</description>
    /// 				<description>by</description>
    /// 				<description>description</description>
    /// 			</listheader>
    /// 			<item>
    /// 				<description>9/19/2008</description>
    /// 				<description>Chamith</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class SecurableObjectTypeCollection : KeyedCollection<long, SecurableObjectType>
    {


        /// <summary>
        /// Initializes a new instance of the SecurableObjectTypeCollection class.
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/19/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public SecurableObjectTypeCollection()
        {
        }



        /// <summary>
        /// Initializes a new instance of the SecurableObjectTypeCollection class.
        /// </summary>
        /// <param name="securableObjectTypes">The securable object types,Ilist collection of SecurableObjectType class.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/19/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
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
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/19/2008</description>
        /// 				<description>chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        protected override long GetKeyForItem(SecurableObjectType item)
        {
            return item.Id;
        }
    }
}
