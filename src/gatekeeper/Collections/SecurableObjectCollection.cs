using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{
 
    /// <summary>
    /// Summary of  SecurableObjectCollection class.It represents a collection of securable objects.
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
    /// 				<description>09/18/2008</description>
    /// 				<description>Chamith</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class SecurableObjectCollection:List<ISecurableObject>
    {

        /// <summary>
        /// Initializes a new instance of the SecurableObjectCollection.
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
        /// 				<description>9/18/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public SecurableObjectCollection() { }


        /// <summary>
        /// Initializes a new instance of the SecurableObjectCollection class with securableObjects as parameters.
        /// </summary>
        /// <param name="securableObjects">The securableObject,Ilist collection of class ISecurableObject.</param>
        /// 
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/18/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public SecurableObjectCollection(IList<ISecurableObject> securableObjects)
        {
            this.AddRange(securableObjects);
        }
    }
}
