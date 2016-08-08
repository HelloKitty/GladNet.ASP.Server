using GladNet.Message;
using GladNet.Payload;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladNet.ASP.Server
{
	/// <summary>
	/// Base controller for GladNet message controllers
	/// </summary>
	/// <typeparam name="TPayloadType">Type of packet payload the controller handles.</typeparam>
	[PayloadRoute]
	public abstract class RequestController<TPayloadType> : Controller
		where TPayloadType : PacketPayload //must be packet payloads
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

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]RequestMessage gladNetRequest)
		{
			//This is an ASP server. We can ONLY send back to the original sender so we can enable routeback
			//This works because if there is anything in the routing stack it wasn't from this ASP server so we can enable
			//routeback and it'll be sent back through the system

			TPayloadType payload = gladNetRequest.Payload.Data as TPayloadType;

			if (payload == null)
				return new BadRequestResult();

			PacketPayload responsePayload = await HandlePost(payload);

			ResponseMessage responseMessage = new ResponseMessage(responsePayload);

			//Now check routeback info
			if(gladNetRequest.isMessageRoutable)
			{
				gladNetRequest.ExportRoutingDataTo(responseMessage);
				responseMessage.isRoutingBack = true;
			}

			//Return an ASP result
			return new GladNetObjectResult(responseMessage);
		}

		/// <summary>
		/// Async/Task-based handler for HttpPost requests for GladNet.
		/// </summary>
		/// <param name="payloadInstance">Provided internally parsed instance.</param>
		/// <returns>An awaitable PacketPayload result.</returns>
		public abstract Task<PacketPayload> HandlePost(TPayloadType payloadInstance);
	}
}
