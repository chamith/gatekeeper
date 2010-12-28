using Castle.MonoRail.Framework;

namespace Gatekeeper.Web.UI.Filters
{
    /// <summary>
    /// Summary of AuthenticationFilter class.
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

			context.Response.Redirect("session", "login");
            return false;
		}
		#endregion
		
    }
}
