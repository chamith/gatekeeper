using Castle.MonoRail.Framework;
using Gatekeeper.Web.UI.Models;
using System.Drawing;
using Gatekeeper.Web.UI.Filters;

namespace Gatekeeper.Web.UI.Controllers
{
    /// <summary>
    /// Implements the base controller.
    /// </summary>
    [Filter(ExecuteWhen.BeforeAction, typeof(AuthenticationFilter))]
    [Layout("default")]
	public abstract class BaseController : SmartDispatcherController
    {
        BreadcrumbTrail breadcrumbTrail = null;

        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
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
        public BaseController()
        {
            this.InitializeBreadcrumbTrail();
        }

        /// <summary>
        /// Adds to breadcrumb trail.
        /// </summary>
        /// <param name="link">The link.</param>
        protected void AddToBreadcrumbTrail(Link link)
        {
            this.breadcrumbTrail.Add(breadcrumbTrail.Count, link);
        }

        /// <summary>
        /// Gets the breadcrumb trail.
        /// </summary>
        /// <value>The breadcrumb trail.</value>
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
        public override void PreSendView(object view)
        {
            base.PreSendView(view);
        }

        /// <summary>
        /// Renders the breadcrumb trail.
        /// </summary>
        protected void RenderBreadcrumbTrail()
        {
            this.PropertyBag["breadcrumbTrail"] = this.breadcrumbTrail;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="id">The id.</param>
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
