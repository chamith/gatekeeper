using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{


	/// <summary>
	/// Summary of Role
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
	public class Role : BaseEntity
	{
		/// <summary>
		/// Gets or sets the name of the Role.
		/// </summary>
		/// <value>The name.</value>
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
		/// 				<description>Chamith Siriwardena</description>
		/// 				<description>initial code</description>
		/// 			</item>
		/// 		</list>
		/// 	</para>
		/// </remarks>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of Role.
		/// </summary>
		/// <value>The description.</value>
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
		/// 				<description>Chamith Siriwardena</description>
		/// 				<description>initial code</description>
		/// 			</item>
		/// 		</list>
		/// 	</para>
		/// </remarks>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the application,to which the role belongs.
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
		/// 				<description>9/19/2008</description>
		/// 				<description>Chamith Siriwardena</description>
		/// 				<description>initial code</description>
		/// 			</item>
		/// 		</list>
		/// 	</para>
		/// </remarks>
		public Application Application { get; set; }

		/// <summary>
		/// Gets or sets the type of the securable object,to which the role applies..
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
		/// 				<description>9/19/2008</description>
		/// 				<description>Chamith Siriwardena</description>
		/// 				<description>initial code</description>
		/// 			</item>
		/// 		</list>
		/// 	</para>
		/// </remarks>
		public SecurableObjectType SecurableObjectType { get; set; }
		
	}
}
