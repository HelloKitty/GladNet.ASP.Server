using GladNet.Payload;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladNet.ASP.Server
{
	[PayloadRoute]
	public abstract class RequestController<TPayloadType> : Controller
		where TPayloadType : PacketPayload
	{
		public RequestController()
		{
			//We have to do some attribute hacking here to get this routing to work
			//See https://github.com/aspnet/Mvc/blob/a78f77afde003c4a3fcf5dd7b6dc13dd9c85f825/src/Microsoft.AspNetCore.Mvc.Core/RouteAttribute.cs
			//for attribute source

			PayloadRouteAttribute attri = this.GetType().GetCustomAttributes(typeof(PayloadRouteAttribute), true)
				.Select(x => x as PayloadRouteAttribute)
				.First(); //we can use first; we know it's marked

			//Once we have a ref to the attribute we need to change the template
			typeof(PayloadRouteAttribute).GetProperty(nameof(PayloadRouteAttribute.Template))
				.SetValue(attri, $"api/{typeof(TPayloadType).Name}"); //set the routing template

			//Now the attribute should have the valid routing
		}
	}
}
