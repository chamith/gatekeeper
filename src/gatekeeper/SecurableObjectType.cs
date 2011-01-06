using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of SecurableObjectType,represents the type of a securable object.
    /// </summary>
    public class SecurableObjectType:BaseEntity
    {

        /// <summary>
        /// Gets or sets the name of the securable object type.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the securable object type.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
       
        /// <summary>
        /// Gets or sets the application,to which the securable object type belongs..
        /// </summary>
        /// <value>The application.</value>
        public Application Application { get; set; }

    }
}
