using System;
namespace Gatekeeper
{
	public class SecurableApplication:Application, ISecurableObject
	{
		public SecurableApplication()
		{
			this.Application = this;
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
	}
}

