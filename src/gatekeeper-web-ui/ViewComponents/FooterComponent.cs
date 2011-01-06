using Castle.MonoRail.Framework;

namespace BusinessLine.Web.UI.Reporting.ViewComponents
{
    /// <summary>
    /// Composes the footer.
    /// </summary>
    public class FooterComponent:ViewComponent
    {
  		public override void Render ()
		{
			this.RenderView("../footer");
		}
  	}
}
