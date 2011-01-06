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
    /// Summary of RightController class,it contains the actions of rights related to the projects.
    /// </summary>
    public class RightController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(RightController));
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

            //Gets all the Right objects of a specified application from the database and puts those into RightCollection-rights..
            RightCollection rights =
                GatekeeperFactory.RightSvc.Get(application);

            ISecurableObjectTypeSvc sotSvc = GatekeeperFactory.SecurableObjectTypeSvc;

           //Gets the SecurableObjectType  of a specified application and SecurableObjectTypeId of every Right object in rights collection.
            foreach (Right right in rights)
            {
                right.SecurableObjectType = sotSvc.Get(right.SecurableObjectType.Id);
            }

            //Creates the PropertyBag variables rights and application.
            this.PropertyBag["rights"] = rights;
            this.PropertyBag["application"] = application;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights" });
            this.RenderBreadcrumbTrail(); 

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the by role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        public void DisplayByRole(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the role object of specified roleId.
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);

            //Gets the application object of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets RoleRightAssignmentCollection of a specified role object.
            RoleRightAssignmentCollection roleRightAssignments =
                GatekeeperFactory.RoleRightAssignmentSvc.Get(role);

            //Creates PropertyBag variables roleRightAssignments,application and role.
            this.PropertyBag["roleRightAssignments"] = roleRightAssignments;
            this.PropertyBag["application"] = application;
            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles" , Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Associates with role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        public void AssociateWithRole(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets role object of specified roleId
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);

            //Gets application object of a specified role object.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets securableObjectType object of a specified application and role.
            SecurableObjectType securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(role.SecurableObjectType.Id);

            //Gets the RightCollection of a specified securableObjectType.
            RightCollection rights =
                GatekeeperFactory.RightSvc.Get(securableObjectType);

            //Gets the RoleRightAssignmentCollection of a specified role.
            RoleRightAssignmentCollection roleRightAssignments =
                GatekeeperFactory.RoleRightAssignmentSvc.Get(role);

            //Creates a Ilist collection of GrantedRight objects.
            IList<GrantedRight> grantedRights = new List<GrantedRight>();


            //Initializes right objects.
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

                //Checking whether a particular rights is in RoleRightAssignment. 
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

            //Creates PropertyBag variables rights,application and role.
            this.PropertyBag["rights"] = grantedRights;
            this.PropertyBag["application"] = application;
            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights", Controller = "right", Action = "displayByRole", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Grant" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the associate with role.
        /// </summary>
        public void SaveAssociateWithRole()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion


            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        ///Displays the project with a specified id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        public void Add(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
            //Gets the collection of SecurableObjectType objects of a specified application object.
            IList<SecurableObjectType> securableObjectTypes = GatekeeperFactory.SecurableObjectTypeSvc.Get(application);

            //Creates PropertyBag variables securableObjectTypes and right.
            this.PropertyBag["securableObjectTypes"] = securableObjectTypes;
            this.PropertyBag["right"] = new Right()
            {
                Application = application
            };

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights", Controller = "right", Action = "default", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the contents of right into the database.
        /// </summary>
        /// <param name="right">The right.</param>
        public void SaveAdd([DataBind("right")]Right right)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Adds the object right into the database.
            GatekeeperFactory.RightSvc.Add(right);

            Hashtable args = new Hashtable();
            args["applicationId"] = right.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the delete view of the right.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        public void ConfirmDelete(int rightId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets object right of a specified rightId
            Right right = GatekeeperFactory.RightSvc.Get(rightId);

            //Gets application object of a specified right.
            Application application = GatekeeperFactory.ApplicationSvc.Get(right.Application.Id);

            //Creates PropertyBag right.
            this.PropertyBag["right"] = right;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights", Controller = "right", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = right.Name, Controller = "right", Action = "display", QueryString = string.Format("rightId={0}", rightId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Delete" });
            this.RenderBreadcrumbTrail();

            this.RenderView("delete");

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Deletes the specified right from the database.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        public void Delete(int rightId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IRightSvc rightSvc = GatekeeperFactory.RightSvc;

            //Gets right object of a specified rightId.
            Right right = rightSvc.Get(rightId);

            //Deletes a rightobject from the database.
            rightSvc.Delete(right);

            Hashtable args = new Hashtable();
            args["applicationId"] = right.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Edits the specified right id.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        public void Edit(int rightId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the right object of a specified rightId.
            Right right = GatekeeperFactory.RightSvc.Get(rightId);

            //Gets the application object of a specified right.
            Application application = GatekeeperFactory.ApplicationSvc.Get(right.Application.Id);

            //Gets the list of SecurableObjectType objects of a specified application object.
            IList<SecurableObjectType> securableObjectTypes = GatekeeperFactory.SecurableObjectTypeSvc.Get(application);

            this.PropertyBag["securableObjectTypes"] = securableObjectTypes;
            this.PropertyBag["right"] = right;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights", Controller = "right", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = right.Name, Controller = "right", Action = "display", QueryString = string.Format("rightId={0}", rightId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Edit" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the edit.
        /// </summary>
        /// <param name="right">The right.</param>
        public void SaveEdit([DataBind("right")]Right right)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Updates the object right in database.
            GatekeeperFactory.RightSvc.Update(right);

            Hashtable args = new Hashtable();
            args["applicationId"] = right.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the specified right id.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        public void Display(int rightId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets object right of a specified rightId.
            Right right = GatekeeperFactory.RightSvc.Get(rightId);

            //Gets object application of a specified right.
            Application application = GatekeeperFactory.ApplicationSvc.Get(right.Application.Id);

            this.PropertyBag["right"] = right;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights", Controller = "right", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = right.Name });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the type of the by securable object.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
        [AjaxAction]
        public void DisplayBySecurableObjectType(int applicationId, int securableObjectTypeId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IRightSvc rightSvc = GatekeeperFactory.RightSvc;
            RightCollection rights = rightSvc.Get(new SecurableObjectType(){Application = new Application(){Id = applicationId}, Id = securableObjectTypeId});
            this.PropertyBag["rights"] = rights;
            this.RenderView("../components/rightList", true);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
    }
}
