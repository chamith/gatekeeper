using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of Right,represents a right to perform an operation in an application.
    /// </summary>
    public class Right:BaseEntity
    { 
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name of the right.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description of the right.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the type of the securable object,to which the right applies..
        /// </summary>
        /// <value>The type of the securable object.</value>
        public SecurableObjectType SecurableObjectType { get; set; }
        /// <summary>
        /// Gets or sets the application,to which the right belongs..
        /// </summary>
        /// <value>The application.</value>
        public Application Application { get; set; }

    }
}
