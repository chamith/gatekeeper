using Castle.MonoRail.Framework;
using System.Collections;

namespace Gatekeeper.Web.UI.Filters
{
    /// <summary>
    /// Summary of AuthenticationFilter class.
    /// </summary>
    public class AuthenticationFilter:IFilter
	{
		
		#region IFilter implementation
		
		public bool Perform (ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
		{
			if (context.Session.Contains("userSecurityPrincipal"))
            {
                System.Threading.Thread.CurrentPrincipal = context.Session["userSecurityPrincipal"] as Principal;
                return true;
            }

			context.Response.Redirect("session", "login", new Hashtable(){{"redirectUrl", context.Request.Url}});
            return false;
		}
		
		#endregion

    }
}
