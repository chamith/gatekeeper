using System;
using System.Collections.Generic;

using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
   public class SecurableObject:BaseEntity
    {
       public SecurableObjectType SecurableObjectType { get; set; }
       public Application Application { get; set; }
       public Guid Guid { get; set; }
	}
}
