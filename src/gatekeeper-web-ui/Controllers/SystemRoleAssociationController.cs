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
    /// Summary of RoleRightAssociationController class,it controls all actions related with RoleRightAssociation.
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

    public class SystemRoleAssociationController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(RightController));
        #endregion

        /// <summary>
        /// Displays the rights by role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
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
        public void DisplayUsersBySystemRole(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets role object of a specified roleId.
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);

            //Gets application object of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets collection of  UserRoleAssignment objects of a specified role.
            UserRoleAssignmentCollection userRoleAssignments =
                GatekeeperFactory.UserRoleAssignmentSvc.Get(application, role, application.Guid);

            //Creates PropertyBag variables.
            this.PropertyBag["userRoleAssignments"] = userRoleAssignments;
            this.PropertyBag["application"] = application;
            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "System Roles" , Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }



        /// <summary>
        /// Associates the users to role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>1/30/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 			<item>
        /// 				<description>09/01/2009</description>
        /// 				<description>firazm</description>
        /// 				<description>modification</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void AssociateSystemRoleToUsers(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets role object of a specified roleId.
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);

            //Gets application object of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets securableObjectType object of a specified application and role.
            SecurableObjectType securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(role.SecurableObjectType.Id);

            //Gets All Users
            UserCollection users = GatekeeperFactory.UserSvc.Get();
                        

            //Gets UserRoletAssignmentCollection of a specified role for an application.
            UserRoleAssignmentCollection userRoleAssignments = null;//GatekeeperFactory.UserRoleAssignmentSvc.Get(application, role, application.SecurableObjectGuid);

            IList<GrantedUser> grantedUsers = new List<GrantedUser>();

           foreach (User user in users)
            {
                GrantedUser grantedUser = new GrantedUser()
                {
                    Id = user.Id,
                    LoginName = user.LoginName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                foreach (UserRoleAssignment ura in userRoleAssignments)
                {
                    if (ura.User.Id == user.Id)
                    {
                        grantedUser.IsGranted = true;
                        break;
                    }
                }

                grantedUsers.Add(grantedUser);
            }

            //Creates PropertyBag variable.
            this.PropertyBag["users"] = grantedUsers;
            this.PropertyBag["application"] = application;
            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users", Controller = "systemRoleAssociation", Action = "displayUsersBySystemRole", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Grant" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the associate rights to role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="rightIds">The right ids.</param>
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
        public void SaveAssociateSystemRoleToUsers([DataBind("role")]Role role, [DataBind("user.IsGranted")]int[] userIds)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IUserRoleAssignmentSvc userRoleAssignmentSvc = GatekeeperFactory.UserRoleAssignmentSvc;
         
            
            //Gets role of a specified roleId.

            role = GatekeeperFactory.RoleSvc.Get(role.Id);

            //Gets application of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets UserRoleAssignmentCollection of a specified role.
            
            UserRoleAssignmentCollection existingUserRoleAssignments = userRoleAssignmentSvc.Get(application,role,application.Guid);
            

            UserRoleAssignmentCollection selectedUserRoleAssignments = new UserRoleAssignmentCollection();
            
           
            SecurableObject securableobject = GatekeeperFactory.SecurableObjectSvc.Get(application.Guid);
         
           
            foreach (int userId in userIds)
            {
                UserRoleAssignment ura = new UserRoleAssignment()
                {
                    User = new User() { Id = userId },              
                    Application = application,
                    SecurableObjectId = securableobject.Id,
                    //SecurableObjectType = new SecurableObjectType() { Id=application.SecurableObjectType.Id},
                    Role=role

              };

             
               
               
                selectedUserRoleAssignments.Add(ura);
                
            }

           
            UserRoleAssignmentCollection newRoleUserAssignments = new UserRoleAssignmentCollection();
           
            UserRoleAssignmentCollection deletedRoleUserAssignments = new UserRoleAssignmentCollection();

            foreach(UserRoleAssignment existingUra in existingUserRoleAssignments)
            {
                if (!selectedUserRoleAssignments.Contains(existingUra))
                    deletedRoleUserAssignments.Add(existingUra);
               
            }

            foreach (UserRoleAssignment selectedUra in selectedUserRoleAssignments)
            {
                if (!existingUserRoleAssignments.Contains(selectedUra))
                    newRoleUserAssignments.Add(selectedUra);
             
            }

            //Adds newUserRoleAssignments into the system.
            userRoleAssignmentSvc.Add(newRoleUserAssignments);

          

            //Deletes UserRoleAssignment from the system.
            userRoleAssignmentSvc.Delete(deletedRoleUserAssignments);
          
            Hashtable args = new Hashtable();
            args["roleId"] = role.Id;

            this.RedirectToAction("DisplayUsersBySystemRole", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        public void DisplayUsersByApplication(int applicationId)
        {
            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            this.PropertyBag["application"] = application;

            UserRoleAssignmentCollection userRoleAssignments = GatekeeperFactory.UserRoleAssignmentSvc.GetUsersByApplication(application);

            ISecurableObjectTypeSvc secObjType = GatekeeperFactory.SecurableObjectTypeSvc;
            //UserSvc user = new UserSvc();

            foreach (UserRoleAssignment userRoleAssignment in userRoleAssignments)
            {
                userRoleAssignment.SecurableObjectType = secObjType.Get(userRoleAssignment.SecurableObjectType.Id);
                //userRoleAssignment.User.Name = user.Get(System.Convert.ToInt32(userRoleAssignment.User.Id));

                User user = GatekeeperFactory.UserSvc.Get(System.Convert.ToInt32(userRoleAssignment.User.Id));
                
                userRoleAssignment.User.FirstName = user.FirstName;
                userRoleAssignment.User.LastName = user.LastName;
                

            }

            this.PropertyBag["userRoleAssignments"] = userRoleAssignments;
        }

        

    }
}
