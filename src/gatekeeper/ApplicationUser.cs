using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{

	/// <summary>
	/// Represents a user of an Application. 
	/// </summary>
	public class ApplicationUser : BaseEntity
	{
		/// <summary>
		/// Gets or sets the Application. 
		/// </summary>
		public Application Application { get; set; }

		/// <summary>
		/// Gets or sets the User. 
		/// </summary>
		public User User { get; set; }

		/// <summary>
		/// Gets or sets the Role. 
		/// </summary>
		public Role Role { get; set; }
	}
}
