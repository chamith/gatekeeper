
using System;
namespace Gatekeeper.Web.UI.Facades
{
    /// <summary>
    /// Summary of SecurityFacade class.
    /// </summary>
    /// <remarks>
    /// 	<para>
    /// 		<list type="table">
    /// 			<listheader>
    /// 				<description>modified</description>
    /// 				<description>by</description>
    /// 				<description>description</description>
    /// 			</listheader>
    /// 			<item>
    /// 				<description>9/30/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class SecurityFacade
    {
        static Guid ApplicationGUID = new Guid("bb9431d0-9997-461a-8356-b92b876cb7cd");

        /// <summary>
        /// Gets the application security context.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/30/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public ApplicationSecurityContext GetApplicationSecurityContext()
        {
            return new ApplicationSecurityContext(ApplicationGUID);
        }
    }
}
