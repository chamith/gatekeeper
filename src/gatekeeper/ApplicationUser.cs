using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
    public class ApplicationUser:BaseEntity
    {
        public Application Application { get; set; }

        public User User { get; set; }
		
		public Role Role {
			get;
			set;
		}
    }
}
