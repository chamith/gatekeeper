using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using Gatekeeper.Domain;

namespace Gatekeeper
{
    public abstract class GatekeeperFactory
    {

        #region Singleton Implementation

        /// <summary>
        /// Returns a new instance of the <see cref="CustomerFactory"/> creational factory.
        /// </summary>
        /// <returns>
        /// An instance of the <see cref="CustomerFactory"/>.
        /// </returns>
        public static GatekeeperFactory Instance()
        {
            // Return a brand new instance
            return new DefaultGatekeeperFactoryFactory();
        }

        #endregion

        #region Factory Method
        public abstract IApplicationSvc GetApplicationSvc();
        public abstract IApplicationUserSvc GetApplicationUserSvc();
        public abstract IRightSvc GetRightSvc();
        public abstract IRoleRightAssignmentSvc GetRoleRightAssignmentSvc();
        public abstract IRoleSvc GetRoleSvc();
        public abstract ISecurableObjectSvc GetSecurableObjectSvc();
        public abstract ISecurableObjectTypeSvc GetSecurableObjectTypeSvc();
        public abstract IUserRoleAssignmentSvc GetUserRoleAssignmentSvc();
        public abstract IUserRightAssignmentSvc GetUserRightAssignmentSvc();
        public abstract IUserSvc GetUserSvc();
		
		public static IApplicationSvc ApplicationSvc
		{
			get
			{
				return Instance().GetApplicationSvc();
			}
		}
		
		public static IApplicationUserSvc ApplicationUserSvc
		{
			get
			{
				return Instance().GetApplicationUserSvc();
			}
		}
		
		public static IRightSvc RightSvc
		{
			get
			{
				return Instance().GetRightSvc();
			}
		}
		
		public static IRoleRightAssignmentSvc RoleRightAssignmentSvc
		{
			get
			{
				return Instance().GetRoleRightAssignmentSvc();
			}
		}
		
		public static IRoleSvc RoleSvc
		{
			get
			{
				return Instance().GetRoleSvc();
			}
		}
		
		public static ISecurableObjectSvc SecurableObjectSvc
		{
			get
			{
				return Instance().GetSecurableObjectSvc();
			}
		}
		
		public static ISecurableObjectTypeSvc SecurableObjectTypeSvc
		{
			get
			{
				return Instance().GetSecurableObjectTypeSvc();
			}
		}
		
		public static IUserRoleAssignmentSvc UserRoleAssignmentSvc
		{
			get
			{
				return Instance().GetUserRoleAssignmentSvc();
			}
		}
		
		public static IUserRightAssignmentSvc UserRightAssignmentSvc
		{
			get
			{
				return Instance().GetUserRightAssignmentSvc();
			}
		}
		public static IUserSvc UserSvc
		{
			get
			{
				return Instance().GetUserSvc();
			}
		}
		
        #endregion

        /// <summary>
        /// Contains the default implementation of <see cref="GatekeeperFactory"/>
        /// </summary>
        private sealed class DefaultGatekeeperFactoryFactory : GatekeeperFactory
        {
            private static ILog log = LogManager.GetLogger(typeof(DefaultGatekeeperFactoryFactory));

            public DefaultGatekeeperFactoryFactory()
            {
            }

            public override IApplicationSvc GetApplicationSvc()
            {
                return new ApplicationSvc();
            }
			
            public override IApplicationUserSvc GetApplicationUserSvc()
            {
                return new ApplicationUserSvc();
            }

			public override IRightSvc GetRightSvc()
            {
                return new RightSvc();
            }
			
			public override IRoleRightAssignmentSvc GetRoleRightAssignmentSvc()
            {
                return new RoleRightAssignmentSvc();
            }
			
			public override IUserRightAssignmentSvc GetUserRightAssignmentSvc()
            {
                return new UserRightAssignmentSvc();
            }
			
			public override IRoleSvc GetRoleSvc()
            {
                return new RoleSvc();
            }
			
			public override ISecurableObjectSvc GetSecurableObjectSvc()
            {
                return new SecurableObjectSvc();
            }
			
			public override ISecurableObjectTypeSvc GetSecurableObjectTypeSvc()
            {
                return new SecurableObjectTypeSvc();
            }
			
			public override IUserRoleAssignmentSvc GetUserRoleAssignmentSvc()
            {
                return new UserRoleAssignmentSvc();
            }
			
			public override IUserSvc GetUserSvc()
            {
                return new UserSvc();
            }
        }
    }
}
