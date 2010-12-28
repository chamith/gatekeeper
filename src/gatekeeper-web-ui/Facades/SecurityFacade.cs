
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
        static Guid ApplicationGUID = new Guid("8047b7b4-3a5c-47dd-aa73-88b04f09bfca");

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
