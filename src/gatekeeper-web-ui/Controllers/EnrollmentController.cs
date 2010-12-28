using System.Collections;
using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using membership = ECollegeSL.Enterprise.Membership;
using ECollegeSL.Enterprise.Membership.Web.UI.Logging;
using ECollegeSL.Enterprise.Membership.Collections;
using ECollegeSL.Enterprise.Membership.Web.UI.Models;

namespace ECollegeSL.Enterprise.Membership.Web.UI.Controllers
{
    /// <summary>
    /// Contains the actions related to the projects.
    /// </summary>
    [Layout("Default")]
    public class EnrollmentController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(SecurableObjectTypeController));
        #endregion

        public void Default(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            Application application = new ApplicationSvc().Get(applicationId);

            ApplicationUserCollection users = new ApplicationUserSvc().Get(application);
            this.PropertyBag["users"] = users;

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
        
        public void DisplayByUser(int userId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the project with a specified id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        public void Add()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            RegistrationInfo regInfo = new RegistrationInfo();
            this.PropertyBag["regInfo"] = regInfo;

            this.AddToBreadcrumbTrail(new Link() { Text = "Users", Controller = "user", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        public void SaveAdd([DataBind("regInfo")]RegistrationInfo regInfo)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            this.PropertyBag["regInfo"] = regInfo;

            membership.User user = new membership.User()
            {
                FirstName = regInfo.FirstName,
                LastName = regInfo.LastName,
                Email = regInfo.Email
            };

            new UserSvc().Add(user, regInfo.Password);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        public void Display(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            Role role = new RoleSvc().Get(roleId);
            Application application = new ApplicationSvc().Get(role.Application.Id);

            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
        /// <summary>
        /// Displays the edit view of the project with a specified id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        public void ConfirmDelete(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            Role role = new RoleSvc().Get(roleId);
            Application application = new ApplicationSvc().Get(role.Application.Id);

            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Delete" });
            this.RenderBreadcrumbTrail();

            this.RenderView("delete");

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        public void Delete(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            RoleSvc roleSvc = new RoleSvc();

            Role role = roleSvc.Get(roleId);

            roleSvc.Delete(role);

            Hashtable args = new Hashtable();
            args["applicationId"] = role.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        public void Edit(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            RoleSvc roleSvc = new RoleSvc();
            Role role = roleSvc.Get(roleId);
            Application application = new ApplicationSvc().Get(role.Application.Id);
            IList<SecurableObjectType> securableObjectTypes = new SecurableObjectTypeSvc().Get(application);
            SecurableObjectType securableObjectType = new SecurableObjectTypeSvc().Get(role.Application, role.SecurableObjectType.Id);
            RightCollection rights =
    new RightSvc().Get(securableObjectType);

            RoleRightAssignmentCollection roleRightAssignments =
                new RoleRightAssignmentSvc().Get(role);

            IList<GrantedRight> grantedRights = new List<GrantedRight>();

            foreach (Right right in rights)
            {
                GrantedRight grantedRight = new GrantedRight()
                {
                    Id = right.Id,
                    Name = right.Name,
                    Description = right.Description,
                    Application = right.Application,
                    SecurableObjectType = right.SecurableObjectType
                };

                foreach (RoleRightAssignment rra in roleRightAssignments)
                {
                    if (rra.Right.Id == right.Id)
                    {
                        grantedRight.IsGranted = true;
                        break;
                    }
                }

                grantedRights.Add(grantedRight);
            }

            this.PropertyBag["rights"] = grantedRights;
            this.PropertyBag["role"] = role;
            this.PropertyBag["securableObjectTypes"] = securableObjectTypes;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Edit" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        public void SaveEdit([DataBind("role")]Role role)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            new RoleSvc().Update(role);

            Hashtable args = new Hashtable();
            args["roleId"] = role.Id;
            this.RedirectToAction("display", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
    }
}
