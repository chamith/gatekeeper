using Castle.MonoRail.Framework;
using Gatekeeper.Web.UI.Models;
using System.Drawing;
using Gatekeeper.Web.UI.Filters;

namespace Gatekeeper.Web.UI.Controllers
{
    /// <summary>
    /// Implements the base controller.
    /// </summary>
    /// <remarks>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<description>modified</description>
    /// 			<description>by</description>
    /// 			<description>description</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<description>5/20/2008</description>
    /// 			<description>Chamith</description>
    /// 			<description>initial code</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    //[Filter(ExecuteWhen.BeforeAction, typeof(AuthenticationFilter))]
    [Layout("default")]
	public abstract class BaseController : SmartDispatcherController
    {
        BreadcrumbTrail breadcrumbTrail = null;

        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
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
        public Application Application
        {
            get
            {
                ApplicationSecurityContext applicationSecurityContext =
                    this.HttpContext.Application["securityContext"] as ApplicationSecurityContext;
                return applicationSecurityContext.Application;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
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
        public BaseController()
        {
            this.InitializeBreadcrumbTrail();
        }

        /// <summary>
        /// Adds to breadcrumb trail.
        /// </summary>
        /// <param name="link">The link.</param>
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
        protected void AddToBreadcrumbTrail(Link link)
        {
            this.breadcrumbTrail.Add(breadcrumbTrail.Count, link);
        }

        /// <summary>
        /// Gets the breadcrumb trail.
        /// </summary>
        /// <value>The breadcrumb trail.</value>
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
        protected BreadcrumbTrail BreadcrumbTrail
        {
            get
            {
                return this.breadcrumbTrail;
            }
        }

        /// <summary>
        /// Initializes the breadcrumb trail.
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
        protected virtual void InitializeBreadcrumbTrail()
        {
            if(this.breadcrumbTrail == null)
                this.breadcrumbTrail = new BreadcrumbTrail();
        }

        /// <summary>
        /// Invoked by the view engine to perform
        /// any logic before the view is sent to the client.
        /// </summary>
        /// <param name="view"></param>
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
        public override void PreSendView(object view)
        {
            base.PreSendView(view);
        }

        /// <summary>
        /// Renders the breadcrumb trail.
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
        protected void RenderBreadcrumbTrail()
        {
            this.PropertyBag["breadcrumbTrail"] = this.breadcrumbTrail;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="id">The id.</param>
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
        public void GetImage(int id)
        {
            this.CancelLayout();
            this.CancelView();
            Response.ContentType = "image/png";
            //Bitmap image = new Bitmap(@"D:\Office\SoftCreations\Frameworks\Gatekeeper\src\Gatekeeper\Web\UI\Content\images\google.jpg");
            System.IO.StreamReader imageReader = new System.IO.StreamReader(@"D:\Office\SoftCreations\Frameworks\Gatekeeper\src\Gatekeeper\Web\UI\Content\images\logo_plain.png");
            byte[] image = new byte[imageReader.BaseStream.Length];
            imageReader.BaseStream.Read(image, 0, (int)imageReader.BaseStream.Length);
            Response.BinaryWrite(image);
        }
    }
}
