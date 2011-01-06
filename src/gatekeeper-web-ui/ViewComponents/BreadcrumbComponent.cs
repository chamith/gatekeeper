using Castle.MonoRail.Framework;

namespace BusinessLine.Web.UI.Reporting.ViewComponents
{

    /// <summary>
    /// Composes the header.
    /// </summary>
    public class BreadcrumbComponent:ViewComponent
    {
		public override void Render ()
		{
			this.RenderView("../breadcrumb");
		}
    }
}