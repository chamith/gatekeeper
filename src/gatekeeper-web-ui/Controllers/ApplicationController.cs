using System.Collections;
using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using membership = Gatekeeper;
using Gatekeeper.Web.UI.Logging;
using Gatekeeper.Web.UI.Models;
using Gatekeeper.Collections;
using Gatekeeper.Domain;
using Gatekeeper.Web.UI.Filters;

namespace Gatekeeper.Web.UI.Controllers
{
    /// <summary>
    /// Summary of ApplicationController,contains the actions related to the projects.
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
	//[Filter(ExecuteWhen.BeforeAction, typeof(AuthenticationFilter))]
    public class ApplicationController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(ApplicationController));
        #endregion 

        /// <summary>
        /// Handles the default action and display the default view of the project section.
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
        public void Default()
        {

			
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets all the applications from the database and save that to collection-applications.
            IList<Application> applications = GatekeeperFactory.ApplicationSvc.Get();
            this.PropertyBag["applications"] = applications;

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }


        /// <summary>
        /// Displays the project with a specified application id.
        /// </summary>
        /// <param name="applicationId">The application id,identifier of a application.</param>
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
        public void Display(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

           	SecurableApplication obj = new SecurableApplication(this.Application);

			new Permission(obj, "view_system").Demand();

            //Gets the application object of applicationId from database.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
            this.PropertyBag["application"] = application;

            #region BreadcrumbTrail
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name});
            this.RenderBreadcrumbTrail();
            #endregion

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        } 

        /// <summary>
        /// Creating a property bag variable and assign application object to that variable.
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
        public void Add()
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            this.PropertyBag["application"] = new Application();

            #region BreadcrumbTrail
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = "New Application" });
            this.RenderBreadcrumbTrail();
            #endregion

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Displays the application save view,gets the application name and description of a application object from user and save those into database.
        /// </summary>
        /// <param name="application">The application.</param>
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
        public void SaveAdd([DataBind("application")]Application application)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

			GatekeeperFactory.ApplicationSvc.Add(application);


            this.Redirect("home", "default");
            

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }


        /// <summary>
        /// Edits the specified application id.
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
        public void Edit(int applicationId, string applicationName, string applicationDescription)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

//            //Creates a ObjectRight object.
//            ObjectRight or1 = new ObjectRight(this.Application, "Administer_System");
//            //ObjectRight or2 = new ObjectRight(myObject, "Edit_MyObject");
//
//            //Creates a ObjectRightCollection.
//            ObjectRightCollection objectRights = new ObjectRightCollection();
//
//            //Adds object or1 into ObjectRightCollection.
//            objectRights.Add(or1);
//            //objectRights.Add(or2);
//            new Permission(objectRights).Demand();

            Application application;

            if (applicationDescription == null || applicationName == null)
            {
                //Gets the Application object of that particular applicationId.
                application = GatekeeperFactory.ApplicationSvc.Get(applicationId);
            }
            else
            {
                application = new Application()
                {
                    Name = applicationName,
                    Description = applicationName
                };
            }

            //Creates a PropertyBag variable application. 
            this.PropertyBag["application"] = application;

            #region BreadcrumbTrail
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Edit" });
            this.RenderBreadcrumbTrail();
            #endregion

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Saves the edit of a specified application object..
        /// </summary>
        /// <param name="application">The application.</param>
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
        public void SaveEdit([DataBind("application")]Application application)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            int isUpdate = 1;
            
            if (application.Name == null)
            {
                Flash["NoName"] = "Please Enter the Name for the Application!";
                RedirectToReferrer();

                isUpdate = 0;
            }

            if (application.Description == null)
            {
                Flash["NoDesc"] = "Please Enter the Description for the Application!";
                RedirectToReferrer();

                isUpdate = 0;
            }

            Application newApp = GatekeeperFactory.ApplicationSvc.Get(application.Id);

            if (newApp != null)
            {
                if (application.Name != newApp.Name)
                {
                    IList<Application> applications = GatekeeperFactory.ApplicationSvc.Get();

                    foreach (Application one in applications)
                    {
                        one.Name = one.Name.Replace(" ", "");
                        string applicationName = application.Name.Replace(" ", "");

                        if (one.Name.ToLower() == application.Name.ToLower())
                        {
                            Flash["Duplicate"] = "Error! The Name '" + application.Name + "' Already exists! Please Use a Different Name!";
                            RedirectToReferrer();

                            isUpdate = 0;
                        }
                    }
                }
            }

            if (isUpdate == 1)
            {
                //Updates the object application with changes in database.
                GatekeeperFactory.ApplicationSvc.Update(application);

                Hashtable args = new Hashtable();
                args["applicationId"] = application.Id;

                this.Redirect("application", "display", args);
            }
            else
            {
                Hashtable args = new Hashtable();
                args["applicationId"] = application.Id;
                args["applicationName"] = application.Name;
                args["applicationDescription"] = application.Description;

                this.Redirect("application", "edit", args);
            }

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Confirms the delete of a specified application..
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
        public void ConfirmDelete(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IApplicationSvc applicationSvc = GatekeeperFactory.ApplicationSvc;

            //Gets the application object of specified applicationId.
            Application application = applicationSvc.Get(applicationId);
            this.PropertyBag["application"] = application;

            #region BreadcrumbTrail
            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Delete" });
            this.RenderBreadcrumbTrail();
            #endregion

            this.RenderView("delete");

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Deletes the application object of a specified application id.
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
        public void Delete(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            IApplicationSvc applicationSvc = GatekeeperFactory.ApplicationSvc;

            //Gets the application object of specified applicationId.
            Application application = applicationSvc.Get(applicationId);

            //Deletes the specified application object from the database.
            applicationSvc.Delete(application);

            this.Redirect("home", "default");

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }
    }
}
