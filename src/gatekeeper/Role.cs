using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{


	/// <summary>
	/// Summary of Role
	/// </summary>
	public class Role : BaseEntity
	{
		/// <summary>
		/// Gets or sets the name of the Role.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of Role.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the application,to which the role belongs.
		/// </summary>
		/// <value>The application.</value>
		public Application Application { get; set; }

		/// <summary>
		/// Gets or sets the type of the securable object,to which the role applies..
		/// </summary>
		/// <value>The type of the securable object.</value>
		public SecurableObjectType SecurableObjectType { get; set; }
		
	}
}
