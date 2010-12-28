using System.Collections;
using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using membership = Gatekeeper;
using Gatekeeper.Web.UI.Logging;
using Gatekeeper.Web.UI.Models;
using Gatekeeper.Collections;


namespace Gatekeeper.Web.UI.Controllers
{

    /// <summary>
    /// Summary of SecurableObjectTypeController class,it controls all the actions related with SecurableObjectType.
    /// </summary>
    /// <remarks>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<description>modified</description>
    /// 			<description>by</description>
    /// 			<description>description</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<description>9/30/2008</description>
    /// 			<description>Chamith Siriwardena</description>
    /// 			<description>initial code</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>

    public class ApplicationUserController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(ApplicationController));
        #endregion

        /// <summary>
        /// Defaults view of the specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
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
        public void Default(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            //Gets the Collection of SecurableObjectType object of a specified application.
            IList<ApplicationUser> applicationUsers =
                GatekeeperFactory.ApplicationUserSvc.Get(application);

            //Creates the PropertyBag variable.
            this.PropertyBag["applicationUsers"] = applicationUsers;
            this.PropertyBag["application"] = application;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString= string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Users" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        public void Display(long applicationUserId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the SecurableObjectType object of a specified application and securableObjectTypeId
            ApplicationUser applicationUser =
                GatekeeperFactory.ApplicationUserSvc.Get(applicationUserId);

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationUser.Application.Id);

			//Creates the PropertyBag variable.
            this.PropertyBag["applicationUser"] = applicationUser;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Application Users", Controller = "applicationUser", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = applicationUser.User.LoginName });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

         /// <summary>
        /// Adds the specified application object into the system.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
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
        public void Add(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
			UserCollection users = GatekeeperFactory.UserSvc.Get();
			RoleCollection roles = GatekeeperFactory.RoleSvc.Get(application);
			
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Application Users", Controller = "applicationUser", Action = "default", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
			
			this.PropertyBag["users"] = users;
			this.PropertyBag["roles"] = roles;
			this.PropertyBag["applicationUser"] = new ApplicationUser { Application = application };
			this.RenderView("edit");
        } 
		/// <summary>
        /// Adds the specified application object into the system.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
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
        public void Add(int applicationId, int isError, int securableObjectTypeId, string securableObjectTypeName)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            if (isError == 1)
            {
                //this.PropertyBag["securableObjectType"] = GatekeeperFactory.SecurableObjectTypeSvc.Get(application, securableObjectTypeId);//securableObjectType;
                SecurableObjectType securableObjectType = new SecurableObjectType()
                {
                    Id = securableObjectTypeId,
                    Name = securableObjectTypeName,
                    Application = application
                };
                
                this.PropertyBag["securableObjectType"] = securableObjectType;

            }
            else
            {
                //Creates the PropertyBag variable.
                this.PropertyBag["securableObjectType"] = new SecurableObjectType()
                {
                    Application = application
                };
            }

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Securable Object Types", Controller = "securableObjectType", Action = "default", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the SecurableObjectType objects into the system.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
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
        public void Save([DataBind("applicationUser")]ApplicationUser applicationUser)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            
			GatekeeperFactory.ApplicationUserSvc.Save(applicationUser);
			
			Hashtable args = new Hashtable();
            args["applicationId"] = applicationUser.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Confirms the delete action of SecurableObjectType object.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        public void ConfirmDelete(int applicationId, int securableObjectTypeId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            //Gets the SecurableObjectType object of a specified application and securableObjectTypeId.
            SecurableObjectType securableObjectType = 
                GatekeeperFactory.SecurableObjectTypeSvc.Get(securableObjectTypeId);

            //Creates the PropertyBag variable.
            this.PropertyBag["securableObjectType"] = securableObjectType;
                
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Securable Object Types", Controller = "securableObjectType", Action = "default", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = securableObjectType.Name, Controller = "securableObjectType", Action = "display", QueryString = string.Format("applicationId={0}&securableObjectTypeId={1}", applicationId, securableObjectTypeId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Delete" });
            this.RenderBreadcrumbTrail();
            
            this.RenderView("delete");

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Deletes the specified application object form the system.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        public void Delete(int applicationId, int securableObjectTypeId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
                    
            ISecurableObjectTypeSvc securableObjectTypeSvc = GatekeeperFactory.SecurableObjectTypeSvc;

            //Gets SecurableObjectType object of a specified application and securableObjectTypeId. 
            SecurableObjectType securableObjectType = securableObjectTypeSvc.Get(securableObjectTypeId);

            //Deletes a specified SecurableObjectType object from the database.
            securableObjectTypeSvc.Delete(securableObjectType);

            Hashtable args = new Hashtable();
            args["applicationId"] = securableObjectType.Application.Id;
            this.RedirectToAction("default", args);

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Edits the specified application object.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        public void Edit(long applicationUserId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
			ApplicationUser applicationUser = GatekeeperFactory.ApplicationUserSvc.Get(applicationUserId);
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationUser.Application.Id);
			UserCollection users = GatekeeperFactory.UserSvc.Get();
			RoleCollection roles = GatekeeperFactory.RoleSvc.Get(application);
			
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Application Users", Controller = "applicationUser", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = applicationUser.User.LoginName });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
			
			this.PropertyBag["users"] = users;
			this.PropertyBag["roles"] = roles;
			this.PropertyBag["applicationUser"] = applicationUser;
			//this.RenderView("edit");
        }
		
        /// <summary>
        /// Edits the specified application object.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        public void Edit(int securableObjectTypeId, [DataBind("securableObjectType")]SecurableObjectType securableObjectType)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
      
                //Creates PropertyBag variables.
                this.PropertyBag["securableObjectType"] = securableObjectType;
			
             //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(securableObjectType.Application.Id);
	           this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Securable Object Types", Controller = "securableObjectType", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = securableObjectType.Name, Controller = "securableObjectType", Action = "display", QueryString = string.Format("securableObjectTypeId={0}", securableObjectTypeId)});
            this.AddToBreadcrumbTrail(new Link() { Text = "Edit"});
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the edit.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
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
        public void Save([DataBind("securableObjectType")]SecurableObjectType securableObjectType)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
			
           	GatekeeperFactory.SecurableObjectTypeSvc.Save(securableObjectType);
   			
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
			
			this.RedirectToAction("display", string.Format("securableObjectTypeId={0}", securableObjectType.Id));
        }
    }
}
