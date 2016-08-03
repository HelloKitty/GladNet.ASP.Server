using GladNet.Payload;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladNet.ASP.Server
{
	/// <summary>
	/// Specifies an attribute route on a controller for GladNet messages.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public class PayloadRouteAttribute : RouteAttribute
	{
		public PayloadRouteAttribute() 
			: base("")
		{
			//provide nothing to base
			//we hack it
		}
	}
}
