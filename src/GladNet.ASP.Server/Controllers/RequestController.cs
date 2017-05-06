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
	public abstract class RequestController<TPayloadType> : Controller
		where TPayloadType : PacketPayload //must be packet payloads
	{
		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody]RequestMessage gladNetRequest)
		{
			if (!ModelState.IsValid)
				return new BadRequestResult();

			//This is an ASP server. We can ONLY send back to the original sender so we can enable routeback
			//This works because if there is anything in the routing stack it wasn't from this ASP server so we can enable
			//routeback and it'll be sent back through the system

			TPayloadType payload = gladNetRequest?.Payload?.Data as TPayloadType;

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
		protected abstract Task<PacketPayload> HandlePost(TPayloadType payloadInstance);
	}
}
