using System;
using Gatekeeper.Web.UI.Facades;
using System.Web;
using log4net;
using Gatekeeper.Web.UI.Logging;
using Castle.MonoRail.Framework.Routing;

namespace Gatekeeper.Web.UI
{
    /// <summary>
    /// Summary of Global class.
    /// </summary>
    public class Global : System.Web.HttpApplication{
           #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(Global));
        #endregion

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

			RoutingRules.Register(RoutingModuleEx.Engine);

			if (this.Application["securityContext"] == null)
                this.Application["securityContext"] = new SecurityFacade().GetApplicationSecurityContext();
        
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion

		}

        /// <summary>
        /// Handles the Start event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Session_Start(object sender, EventArgs e)
        {
//            ApplicationSecurityContext applicationSecurityContext = HttpContext.Current.Application["securityContext"] as ApplicationSecurityContext;
//			log.Debug(this.User.Identity.Name);
//            UserSecurityContext userSecurityContext = new UserSecurityContext("chamith", applicationSecurityContext);
//            this.Context.Session["userSecurityContext"] = userSecurityContext;
//            this.Context.Session["userSecurityPrincipal"] = new Principal(userSecurityContext);

        }

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
			log.Debug(this.Request.Url.AbsoluteUri);
        }

        /// <summary>
        /// Handles the AuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the End event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Session_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the End event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}