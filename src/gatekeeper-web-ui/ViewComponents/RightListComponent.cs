using Castle.MonoRail.Framework;

namespace Gatekeeper.Web.UI.ViewComponents
{
    /// <summary>
    /// Composes the footer.
    /// </summary>
    public class RightListComponent:ViewComponent
    {
   		public override void Render ()
		{
			this.RenderView("../rightList");
		}
 }
}
