using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper
{
    /// <summary>
    /// Defines the attributes which should be in an application object that is to be secured.
    /// </summary>
    public interface ISecurableObject
    {   /// <summary>
        /// Gets or sets the type of the securable object.
        /// </summary>
        /// <value>The type of the securable object.</value>
        SecurableObjectType SecurableObjectType { get; set; }

        /// <summary>
        /// Gets or sets the application,to which the ISecurableObject belongs.
        /// </summary>
        /// <value>The application.</value>
        Application Application { get; set; }
		
		Guid SecurableObjectGuid {
			get;
			set;
		}
		
		long SecurableObjectId{get;set;}
    }
}
