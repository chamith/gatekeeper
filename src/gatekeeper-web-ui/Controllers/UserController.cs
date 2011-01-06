using System.Collections;
using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using membership = Gatekeeper;
using Gatekeeper.Web.UI.Logging;
using Gatekeeper.Collections;
using Gatekeeper.Web.UI.Models;

namespace Gatekeeper.Web.UI.Controllers
{
    /// <summary>
    /// Summary of UserController class,it controls all the actions related with User.
    /// </summary>
    public class UserController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(SecurableObjectTypeController));
        #endregion

        /// <summary>
        /// Summary of UserController class,it controls all the actions related with User.
        /// </summary>
        public void Default()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            UserCollection users = GatekeeperFactory.UserSvc.Get();
            this.PropertyBag["users"] = users;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users"});
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Handles the default action and display the default view of the project section.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        public void Default(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
            RoleCollection roles =
                GatekeeperFactory.RoleSvc.Get(application);

            ISecurableObjectTypeSvc sotSvc = GatekeeperFactory.SecurableObjectTypeSvc;

            foreach (Role role in roles)
            {
                role.SecurableObjectType = sotSvc.Get(role.SecurableObjectType.Id);
            }
            this.PropertyBag["roles"] = roles;
            this.PropertyBag["application"] = application;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Adds user.
        /// </summary>
        public void Add()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            User user = new User();
            this.PropertyBag["user"] = user;

            this.AddToBreadcrumbTrail(new Link() { Text = "Users", Controller = "user", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the add.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Save([DataBind("user")]User user, string password, string passwdConf)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            new AuthenticationSvc().AddUser(user.LoginName, password, user.FirstName, user.LastName);
			
            this.RedirectToAction("default");
			#region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the specified user object.
        /// </summary>
        /// <param name="userId">The user id.</param>
        public void Display(int userId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            User user = GatekeeperFactory.UserSvc.Get(userId);

            this.PropertyBag["user"] = user;
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users", Controller = "user", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = string.Format("{0} {1}", user.FirstName, user.LastName)});
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
        /// <summary>
        /// Confirms the delete.
        /// </summary>
        /// <param name="userId">The user id.</param>
        public void ConfirmDelete(int userId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            User user = GatekeeperFactory.UserSvc.Get(userId);

            this.PropertyBag["user"] = user;
            this.RenderView("delete");

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users", Controller = "user", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = string.Format("{0} {1}", user.FirstName, user.LastName), Controller = "user", Action = "display" });
            this.AddToBreadcrumbTrail(new Link() { Text = "Delete" });
            this.RenderBreadcrumbTrail();
            
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }


        /// <summary>
        /// Deletes the specified user object.
        /// </summary>
        /// <param name="userId">The user id.</param>
        public void Delete(int userId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            GatekeeperFactory.UserSvc.Delete(new User() { Id = userId });
            this.RedirectToAction("default");
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Edits the specified user object.
        /// </summary>
        /// <param name="userId">The user id.</param>
        public void Edit(int userId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            membership.User user = GatekeeperFactory.UserSvc.Get(userId);

            this.PropertyBag["user"] = user;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users", Controller = "user", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = string.Format("{0} {1}", user.FirstName, user.LastName), Controller = "user", Action = "display", QueryString=string.Format("userId={0}", user.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Edit" });
            this.RenderBreadcrumbTrail();


            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }


        /// <summary>
        /// Saves the edit action.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Save([DataBind("user")]User user)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            GatekeeperFactory.UserSvc.UpdateDetails(user);
            this.RedirectToAction("default");

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
    }
}
