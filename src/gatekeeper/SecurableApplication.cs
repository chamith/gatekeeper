using System;
namespace Gatekeeper
{
	public class SecurableApplication:Application, ISecurableObject
	{
		public SecurableApplication()
		{
			this.Application = this;
		}
		
		public SecurableApplication(Application application)
		{
			this.Application = application;
			this.CopyFrom(application);
		}
		
		#region ISecurableObject implementation
		public SecurableObjectType SecurableObjectType {
			get;
			set;
		}

		public Guid SecurableObjectGuid {
			get{return this.Guid;}
			set{}
		}

		public Application Application {
			get ;
			set ;
		}
	
		public long SecurableObjectId {
			get;
			set;
		}
		#endregion
		
		public void CopyFrom(Application application)
		{
			this.Id = application.Id;
			this.Name = application.Name;
			this.Description = application.Description;
			this.Guid = application.Guid;
		}
	}
}

