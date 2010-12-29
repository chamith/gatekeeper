
using System;
namespace Gatekeeper.Web.UI.Facades
{
    /// <summary>
    /// Summary of SecurityFacade class.
    /// </summary>
    public class SecurityFacade
    {

        /// <summary>
        /// Gets the application security context.
        /// </summary>
        /// <returns></returns>
        public ApplicationSecurityContext GetApplicationSecurityContext()
        {
			System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
			var appGuidstr = appSettingsReader.GetValue("gatekeeper-app-guid", typeof(string)) as string;
			var appGuid = new Guid(appGuidstr);
            return new ApplicationSecurityContext(appGuid);
        }
    }
}
