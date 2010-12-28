using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using Gatekeeper;
using Gatekeeper.Web.UI.Logging;
using Gatekeeper.Web.UI.Models;

namespace Gatekeeper.Web.UI.Controllers
{

    /// <summary>
    /// Contains the actions related to the site's home.
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
    /// 				<description>5/17/2008</description>
    /// 				<description>Chamith</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class HomeController:BaseController
    {

        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));
        #endregion

        /// <summary>
        /// Handles the default action and displays the default page.
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
        /// 				<description>5/17/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Default()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets all the application from the database and put those into applications collection.
            IList<Application> applications = GatekeeperFactory.ApplicationSvc.Get();
            //Creates a PropertyBag variable applications and assign applications collection to that variable.
            this.PropertyBag["applications"] = applications;

            this.RenderBreadcrumbTrail();
            

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
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
        protected override void InitializeBreadcrumbTrail()
        {
            base.InitializeBreadcrumbTrail();
            this.AddToBreadcrumbTrail(new Link() { Text = "Home" });
        }
    }
}
