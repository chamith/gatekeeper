using Castle.MonoRail.Framework;

namespace Gatekeeper.Web.UI.ViewComponents
{
    /// <summary>
    /// Composes the footer.
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
    public class RightListComponent:ViewComponent
    {
   		public override void Render ()
		{
			this.RenderView("../rightList");
		}
 }
}
