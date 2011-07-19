using System;
using Castle.MonoRail.Framework.Routing;
namespace Gatekeeper.Web.UI
{
	public class RoutingRules
	{
		public RoutingRules ()
		{
		}
      	public static void Register(IRoutingRuleContainer rules)  
        {  
  			rules.Add(new PatternRoute("home_default", "/").DefaultForArea().IsEmpty.DefaultForController().Is("home").DefaultForAction().Is("default"));			
		}  
	}
}

