using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of Application,represents an application which is to be secured.
    /// </summary>
    public class Application : BaseEntity
    {

      
        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the description of the application.
        /// </summary>
        /// <value>The description of the application.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        /// <value>The GUID.</value>
        public Guid Guid { get; set; }
    


	}
}
