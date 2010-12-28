using System;

namespace Gatekeeper.Core
{
    /// <summary>
    /// Summary of BaseEntity class.
    /// </summary>
    public abstract class BaseEntity
    {
        public long Id {
        	get;
        	set;
        }
		public bool IsNew {
			get{return this.Id == 0;}
		}
    }
}
