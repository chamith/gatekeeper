using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using Gatekeeper;
using Gatekeeper.Web.UI.Logging;
using Gatekeeper.Web.UI.Models;
using Gatekeeper.Web.UI.Filters;

namespace Gatekeeper.Web.UI.Controllers
{

    /// <summary>
    /// Contains the actions related to the site's home.
    /// </summary>
    public class SessionController:BaseController
    {

        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(SessionController));
        #endregion

        /// <summary>
        /// Handles the default action and displays the default page.
        /// </summary>
        [SkipFilter(typeof(AuthenticationFilter))]
        public void Login(string redirectUrl)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

          
            this.RenderBreadcrumbTrail();
			
			if(string.IsNullOrEmpty(redirectUrl))
				redirectUrl = "/";
			
            this.PropertyBag["redirectUrl"] = redirectUrl;

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        [SkipFilter(typeof(AuthenticationFilter))]
		public void Login(string username, string password, string redirectUrl, int loginAttempts)
		{
			if(new AuthenticationSvc().IsValidUser(username, password))
			{
				ApplicationSecurityContext applicationSecurityContext = this.HttpContext.Application["securityContext"] as ApplicationSecurityContext;
				log.Debug(username);
            	UserSecurityContext userSecurityContext = new UserSecurityContext(username, applicationSecurityContext);
            	this.Context.Session["userSecurityContext"] = userSecurityContext;
            	this.Context.Session["userSecurityPrincipal"] = new Principal(userSecurityContext);
			
				if(string.IsNullOrEmpty(redirectUrl))
					redirectUrl = "/";

				this.RedirectToUrl(redirectUrl);
			}
			
			PropertyBag["loginAttempts"] = loginAttempts + 1;
			
			
		}
        /// <summary>
        /// Initializes the breadcrumb trail.
        /// </summary>
        protected override void InitializeBreadcrumbTrail()
        {
            base.InitializeBreadcrumbTrail();
            this.AddToBreadcrumbTrail(new Link() { Text = "Home" });
        }
    }
}
