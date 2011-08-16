using Castle.MonoRail.Framework;

namespace Gatekeeper.Web.UI.Reporting.ViewComponents
{
    /// <summary>
    /// Composes the user advisory component.
    /// </summary>
    public class UserAdvisoryComponent:ViewComponent
    {
		public override void Render ()
		{
			this.RenderView("../userAdvisory");
		}
    }
}
