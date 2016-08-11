using GladNet.Message;
using GladNet.Payload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladNet.ASP.Server
{
	/// <summary>
	/// Base controller for GladNet authenticated message controllers
	/// </summary>
	/// <typeparam name="TPayloadType">Type of packet payload the controller handles.</typeparam>
	public abstract class AuthenticatedRequestController<TPayloadType> : RequestController<TPayloadType>
		where TPayloadType : PacketPayload //must be packet payloads
	{
		/// <summary>
		/// The GladLive username of the remote peer.
		/// </summary>
		protected string GladLiveUserName { get; private set; }

		[Authorize] //override to mark Authorize
		public override Task<IActionResult> Post([FromBody] RequestMessage gladNetRequest)
		{
			//Initialize the gladlive username from the username claim.
			GladLiveUserName = User.Claims.Where(x => x.Type.ToLower() == "username").Select(x => x.Value).FirstOrDefault();

			//Let base handle the request
			return base.Post(gladNetRequest);
		}
	}
}
