using Castle.MonoRail.Framework;

namespace BusinessLine.Web.UI.Reporting.ViewComponents
{
    /// <summary>
    /// Composes the user advisory component.
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
    /// 				<description>5/20/2008</description>
    /// 				<description>Chamith</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class UserAdvisoryComponent:ViewComponent
    {
		public override void Render ()
		{
			this.RenderView("../userAdvisory");
		}
    }
}
