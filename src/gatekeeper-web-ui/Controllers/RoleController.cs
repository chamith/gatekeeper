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
    /// Summary of RoleController,it controls the actions which are related with roles.
    /// </summary>
    public class RoleController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(SecurableObjectTypeController));
        #endregion
        /// <summary>
        /// Handles the default action and display the default view of the project section.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        public void Default(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
           
            //Gets all the roles of a specified application.
            RoleCollection roles =
                GatekeeperFactory.RoleSvc.Get(application);

            ISecurableObjectTypeSvc sotSvc = GatekeeperFactory.SecurableObjectTypeSvc;

            //For every role object in roles colletion,gets the securableObjectType object of a specified application 
            //and securableObjectType.
            foreach (Role role in roles)
            {
                role.SecurableObjectType = sotSvc.Get(role.SecurableObjectType.Id);
            }

            //Creates the PropertyBag veriables.
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
        /// Adds the specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        public void Add(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            
            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            //Gets the collection of securableObjectType objects of a specified application.
            IList<SecurableObjectType> securableObjectTypes = GatekeeperFactory.SecurableObjectTypeSvc.Get(application);

            //Creates the Propertybag variables.
            this.PropertyBag["securableObjectTypes"] = securableObjectTypes;
            this.PropertyBag["role"] = new Role()
            {
                Application = application
            };

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }



        /// <summary>
        /// Saves the role object into system.
        /// </summary>
        /// <param name="role">The role.</param>
        public void SaveAdd([DataBind("role")]Role role)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Inserts the object role into the database.
            GatekeeperFactory.RoleSvc.Add(role);

            Hashtable args = new Hashtable();
            args["applicationId"] = role.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the specified role id.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        public void Display(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the role object of a specified roleId.
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);


            //Gets the application object of a specified application object.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Creates a Propertybag variable.
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
        /// Confirms the delete,it displays the delete view of role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        public void ConfirmDelete(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the role object of a specified roelId.
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);

            //Gets the application object of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Creates the PropertyBag role.
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

        /// <summary>
        /// Deletes the specified role from the system.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        public void Delete(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IRoleSvc roleSvc = GatekeeperFactory.RoleSvc;

            //Gets role object of a specified roleId.
            Role role = roleSvc.Get(roleId);

            //Deletes the role object from the database.
            roleSvc.Delete(role);

            Hashtable args = new Hashtable();
            args["applicationId"] = role.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Edits the specified role,displays the view of editing information on role object.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        public void Edit(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IRoleSvc roleSvc = GatekeeperFactory.RoleSvc;

            //Gets the role object of a specified roleId.
            Role role = roleSvc.Get(roleId);

            //Gets the application object of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets the list of securableObjectType objects of a specified applicatuion.
            IList<SecurableObjectType> securableObjectTypes = GatekeeperFactory.SecurableObjectTypeSvc.Get(application);
            SecurableObjectType securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(role.SecurableObjectType.Id);
            RightCollection rights =
    GatekeeperFactory.RightSvc.Get(securableObjectType);

            RoleRightAssignmentCollection roleRightAssignments =
                GatekeeperFactory.RoleRightAssignmentSvc.Get(role);

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

            //Creates the PropertyBag variables
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

        /// <summary>
        /// Saves the edit.
        /// </summary>
        /// <param name="role">The role.</param>
        public void SaveEdit([DataBind("role")]Role role)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Updates the changes in a role object in database.
            GatekeeperFactory.RoleSvc.Update(role);

            Hashtable args = new Hashtable();
            args["roleId"] = role.Id;
            this.RedirectToAction("display", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
    }
}
