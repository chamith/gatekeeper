using Gatekeeper;

namespace Gatekeeper.Web.UI.Models
{
    /// <summary>
    /// Summary of GrantedRight class.
    /// </summary>
    public class GrantedRight:Right
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is granted.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is granted; otherwise, <c>false</c>.
        /// </value>
        public bool IsGranted { get; set; }
    }
}
