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

    public class RoleRightAssociationController : BaseController
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
        public void DisplayRightsByRole(int roleId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets role object of a specified roleId.
            Role role = GatekeeperFactory.RoleSvc.Get(roleId);

            //Gets application object of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets collection of  RoleRightAssignment objects of a specified role.
            RoleRightAssignmentCollection roleRightAssignments =
                GatekeeperFactory.RoleRightAssignmentSvc.Get(role);

            //Creates PropertyBag variables.
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
        /// Associates the rights to role.
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
        public void AssociateRightsToRole(int roleId)
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

            //Gets collection of right of a specified securableObjectType.
            RightCollection rights =
                GatekeeperFactory.RightSvc.Get(securableObjectType);

            //Gets RoleRightAssignmentCollection of a specified role.
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

            //Creates PropertyBag variable.
            this.PropertyBag["rights"] = grantedRights;
            this.PropertyBag["application"] = application;
            this.PropertyBag["role"] = role;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Roles", Controller = "role", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = role.Name, Controller = "role", Action = "display", QueryString = string.Format("roleId={0}", roleId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Rights", Controller = "roleRightAssociation", Action = "displayRightsByRole", QueryString = string.Format("roleId={0}", roleId) });
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
        public void SaveAssociateRightsToRole([DataBind("role")]Role role, [DataBind("right.IsGranted")]int[] rightIds)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IRoleRightAssignmentSvc roleRightAssignmentSvc = GatekeeperFactory.RoleRightAssignmentSvc;
            
            //Gets role of a specified roleId.
            role = GatekeeperFactory.RoleSvc.Get(role.Id);

            //Gets application of a specified role.
            Application application = GatekeeperFactory.ApplicationSvc.Get(role.Application.Id);

            //Gets RoleRightAssignmentCollection of a specified role.
            RoleRightAssignmentCollection existingRoleRightAssignments = roleRightAssignmentSvc.Get(role);

            RoleRightAssignmentCollection selectedRoleRightAssignments = new RoleRightAssignmentCollection();

            foreach (int rightId in rightIds)
            {
                RoleRightAssignment rra = new RoleRightAssignment()
                {
                    Right = new Right() { Id = rightId },
                    Role = role,
                    Application = application,
					SecurableObjectType = role.SecurableObjectType
                };

                selectedRoleRightAssignments.Add(rra);
            }

            RoleRightAssignmentCollection newRoleRightAssignments = new RoleRightAssignmentCollection();
            RoleRightAssignmentCollection deletedRoleRightAssignments = new RoleRightAssignmentCollection();
            
            foreach(RoleRightAssignment existingRra in existingRoleRightAssignments)
            {
                if (!selectedRoleRightAssignments.Contains(existingRra))
                    deletedRoleRightAssignments.Add(existingRra);
            }

            foreach (RoleRightAssignment selectedRra in selectedRoleRightAssignments)
            {
                if (!existingRoleRightAssignments.Contains(selectedRra))
                    newRoleRightAssignments.Add(selectedRra);
            }

            //Adds newRoleRightAssignments into the system.
            roleRightAssignmentSvc.Add(newRoleRightAssignments);

            //Deletes roleRightAssignment from the system.
            roleRightAssignmentSvc.Delete(deletedRoleRightAssignments);

            Hashtable args = new Hashtable();
            args["roleId"] = role.Id;

            this.RedirectToAction("displayRightsByRole", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
    }
}
