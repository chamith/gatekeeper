using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of Right,represents a right to perform an operation in an application.
    /// </summary>
    /// <remarks>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<description>modified</description>
    /// 			<description>by</description>
    /// 			<description>description</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<description>9/19/2008</description>
    /// 			<description>Chamith Siriwardena</description>
    /// 			<description>initial code</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    public class Right:BaseEntity
    { 
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name of the right.</value>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/22/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description of the right.</value>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/22/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the type of the securable object,to which the right applies..
        /// </summary>
        /// <value>The type of the securable object.</value>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/22/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public SecurableObjectType SecurableObjectType { get; set; }
        /// <summary>
        /// Gets or sets the application,to which the right belongs..
        /// </summary>
        /// <value>The application.</value>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/22/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public Application Application { get; set; }

    }
}
