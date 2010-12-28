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
    public class SessionController:BaseController
    {

        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(SessionController));
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
        [SkipFilter(typeof(AuthenticationFilter))]
        public void Login()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

          
            this.RenderBreadcrumbTrail();
            this.PropertyBag["redirectUrl"] = this.Request.UrlReferrer;

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
			
				this.RedirectToUrl(redirectUrl);
			}
			
			PropertyBag["loginAttempts"] = loginAttempts + 1;
			
			
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
