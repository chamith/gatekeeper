using System.Collections;
using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using membership = ECollegeSL.Enterprise.Membership;
using ECollegeSL.Enterprise.Membership.Web.UI.Logging;
using ECollegeSL.Enterprise.Membership.Web.UI.Models;
using ECollegeSL.Enterprise.Membership.Web.UI.Filters;

namespace ECollegeSL.Enterprise.Membership.Web.UI.Controllers
{
    /// <summary>
    /// Contains the actions related to the projects.
    /// </summary>
    [Layout("Default")]
    public class MembershipController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(ApplicationController));
        #endregion 

        [SkipFilter(typeof(AuthenticationFilter))]
        public void Login()
        {
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.RedirectUrl = this.Context.UrlReferrer;

            this.PropertyBag["loginInfo"] = loginInfo;
        }

        [SkipFilter(typeof(AuthenticationFilter))]
        public void Login([DataBind("loginInfo")]LoginInfo loginInfo)
        {

            bool isValid = new UserSvc().IsValidUser(loginInfo.Email, loginInfo.Password);

            if (isValid)
            {
                ApplicationSecurityContext applicationSecurityContext = HttpContext.Application["securityContext"] as ApplicationSecurityContext;
                UserSecurityContext userSecurityContext = new UserSecurityContext(loginInfo.Email, applicationSecurityContext);
                this.Context.Session["userSecurityContext"] = userSecurityContext;
                this.Context.Session["userSecurityPrincipal"] = new Principal(userSecurityContext);
                this.Redirect(loginInfo.RedirectUrl);
                return;
            }

            this.PropertyBag["loginInfo"] = loginInfo;
        }

        [SkipFilter(typeof(AuthenticationFilter))]
        public void Register()
        {
            RegistrationInfo regInfo = new RegistrationInfo();
            this.PropertyBag["regInfo"] = regInfo;
        }

        [SkipFilter(typeof(AuthenticationFilter))]
        public void Register([DataBind("regInfo")]RegistrationInfo regInfo)
        {
            this.PropertyBag["regInfo"] = regInfo;
            membership.User user = new membership.User()
            {
                FirstName = regInfo.FirstName,
                LastName = regInfo.LastName,
                Email = regInfo.Email
            };

            new UserSvc().Add(user);
        }

    }
}
