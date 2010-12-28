using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Gatekeeper.Collections
{
    /// <summary>
    /// Summary of  RightCollection.Represents a collection of rights.
    /// </summary>
    /// ///
    /// <remarks>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<description>modified</description>
    /// 			<description>by</description>
    /// 			<description>description</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<description>9/18/2008</description>
    /// 			<description>Chamith</description>
    /// 			<description>initial code</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    public class RightCollection: KeyedCollection<long,Right>
    {
        /// <summary>
        /// Initializes a new instance of the RightCollection class.
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
        public RightCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RightCollection class with rights as parameters.
        /// </summary>
        /// <param name="rights">The right,Ilist collection of class Right.</param>
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
        protected override long GetKeyForItem(Right item)
        {
            return item.Id;
        }
    }
}
