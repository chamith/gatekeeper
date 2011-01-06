using System.Collections;
using System.Collections.Generic;
using Castle.MonoRail.Framework;
using log4net;
using membership = Gatekeeper;
using Gatekeeper.Web.UI.Logging;
using Gatekeeper.Web.UI.Models;


namespace Gatekeeper.Web.UI.Controllers
{

    /// <summary>
    /// Summary of SecurableObjectTypeController class,it controls all the actions related with SecurableObjectType.
    /// </summary>
    public class SecurableObjectTypeController : BaseController
    {
        #region Logger Initialization
        private static readonly ILog log = LogManager.GetLogger(typeof(SecurableObjectTypeController));
        #endregion

        /// <summary>
        /// Defaults view of the specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        public void Default(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            //Gets the Collection of SecurableObjectType object of a specified application.
            IList<SecurableObjectType> securableObjectTypes =
                GatekeeperFactory.SecurableObjectTypeSvc.Get(application);

            //Creates the PropertyBag variable.
            this.PropertyBag["securableObjectTypes"] = securableObjectTypes;
            this.PropertyBag["application"] = application;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString= string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Securable Object Types" });
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
        public void Display(long securableObjectTypeId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the SecurableObjectType object of a specified application and securableObjectTypeId
            SecurableObjectType securableObjectType =
                GatekeeperFactory.SecurableObjectTypeSvc.Get(securableObjectTypeId);

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(securableObjectType.Application.Id);

			//Creates the PropertyBag variable.
            this.PropertyBag["securableObjectType"] = securableObjectType;

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Securable Object Types", Controller = "securableObjectType", Action = "default", QueryString = string.Format("applicationId={0}", application.Id) });
            this.AddToBreadcrumbTrail(new Link() { Text = securableObjectType.Name });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

         /// <summary>
        /// Adds the specified application object into the system.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        public void Add(int applicationId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion

            //Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(applicationId);

            this.AddToBreadcrumbTrail(new Link() { Text = "Home", Controller = "home", Action = "default" });
            this.AddToBreadcrumbTrail(new Link() { Text = application.Name, Controller = "application", Action = "display", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "Securable Object Types", Controller = "securableObjectType", Action = "default", QueryString = string.Format("applicationId={0}", applicationId) });
            this.AddToBreadcrumbTrail(new Link() { Text = "New" });
            this.RenderBreadcrumbTrail();

            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
			
			this.PropertyBag["securableObjectType"] = new SecurableObjectType(){Application = application};
			this.RenderView("edit");
        }
		
		/// <summary>
        /// Adds the specified application object into the system.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
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
        public void SaveAdd([DataBind("securableObjectType")]SecurableObjectType securableObjectType,int ifIsIdErr)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion
            
            int isInsert = 1;
            string securableObjectTypeId = securableObjectType.Id.ToString();

            if (ifIsIdErr == 1)
            {    
                Flash["IdSum"] = "Please Enter the Id for the Securable Object Type!";
                RedirectToReferrer();

                isInsert = 0;
                this.PropertyBag["securableObjectType"] = securableObjectType;
                
            }
            
            if (securableObjectType.Name == null)
            {
                Flash["summary"] = "Please Enter a Name for the Securable Object Type!";
                RedirectToReferrer();

                isInsert = 0;
                ifIsIdErr = 1;
                
            }

            SecurableObjectType newSecurableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(securableObjectType.Id);

            if (newSecurableObjectType != null)
            {
                if (ifIsIdErr == 0)
                {
                    Flash["duplicate"] = "Error! The Id '" + securableObjectType.Id + "' is already being used by another Securable Object Type!";
                    RedirectToReferrer();

                    isInsert = 0;
                    ifIsIdErr = 1;
                }
            }
            else
            {
                IList<SecurableObjectType> securableObjectTypes = GatekeeperFactory.SecurableObjectTypeSvc.Get(securableObjectType.Application);

                foreach (SecurableObjectType one in securableObjectTypes)
                {
                    one.Name = one.Name.Replace(" ", "");
                    string securableObjectTypeName = securableObjectType.Name.Replace(" ", "");


                    if (one.Name.ToLower() == securableObjectTypeName.ToLower())
                    {
                        Flash["duplicate"] = "Error! The Name '" + securableObjectType.Name + "' is already being used by another Securable Object Type!";
                        RedirectToReferrer();

                        isInsert = 0;
                        ifIsIdErr = 1;
                        break;
                    }
                }
            }
            //if (newSecurableObjectType.Id == securableObjectType.Id && newSecurableObjectType.Application.Id == securableObjectType.Application.Id)
            //{ isInsert = 0; }

            //if (newSecurableObjectType.Name == securableObjectType.Name)
            //{ isInsert = 0; }

            

            if (isInsert == 1)
            {
                //Adds the SecurableObjectType object into the database.
                GatekeeperFactory.SecurableObjectTypeSvc.Add(securableObjectType);

                Hashtable args = new Hashtable();
                args["applicationId"] = securableObjectType.Application.Id;
                this.RedirectToAction("default", args);
            }
            else
            {
                Hashtable args = new Hashtable();
                args["applicationId"] = securableObjectType.Application.Id;
                args["isError"] = ifIsIdErr;
                args["securableObjectTypeId"] = securableObjectType.Id;
                args["securableObjectTypeName"] = securableObjectType.Name;
                this.RedirectToAction("add", args);    
            }
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodLeave);
            #endregion
        }

        /// <summary>
        /// Confirms the delete action of SecurableObjectType object.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        public void Edit(long securableObjectTypeId)
        {
            #region Logging
            if (log.IsDebugEnabled) log.Debug(Messages.MethodEnter);
            #endregion


            SecurableObjectType securableObjectType;
            
            //Gets the SecurableObjectType object of a specified application and securableObjectTypeId.
            securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(securableObjectTypeId);

			//Gets the application object of a specified applicationId.
            Application application = GatekeeperFactory.ApplicationSvc.Get(securableObjectType.Application.Id);

            //Creates PropertyBag variables.
            this.PropertyBag["securableObjectType"] = securableObjectType;


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
        /// Edits the specified application object.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
