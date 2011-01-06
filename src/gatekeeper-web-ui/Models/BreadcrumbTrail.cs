using System;
using System.Collections.Generic;
using Gatekeeper;

namespace Gatekeeper.Web.UI.Models
{
    /// <summary>
    /// Summary of BreadcrumbTrail class.
    /// </summary>
    public class BreadcrumbTrail: SortedList<int, Link>
    {
    }

    /// <summary>
    /// Summary of Link class.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>The controller.</value>
        public string Controller { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        /// <value>The query string.</value>
        public string QueryString { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
    }
}
