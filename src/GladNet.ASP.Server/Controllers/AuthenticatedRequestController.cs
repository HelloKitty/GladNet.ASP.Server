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
		/// The authenticated username of the remote peer.
		/// </summary>
		protected string IdentityName { get; private set; }

		/// <summary>
		/// The authenticated userid of the remote peer.
		/// </summary>
		protected int IdentityId { get; private set; }

		[Authorize] //override to mark Authorize
		public override async Task<IActionResult> Post([FromBody] RequestMessage gladNetRequest)
		{
			if (gladNetRequest == null) throw new ArgumentNullException(nameof(gladNetRequest));

			if (!User.Identity.IsAuthenticated)
				return Unauthorized(); //block unauthorized users from entering this critical section.

			//This now works, with the new Auth module in 2017
			//Initialize the gladlive username from the username claim.
			IdentityName = User.Identity.Name;
			string stringId = User.Claims.FirstOrDefault(c => c.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

			//TODO: Log?
			int result = 0;
			if(String.IsNullOrWhiteSpace(stringId))
				if (!Int32.TryParse(stringId, out result))
					return Unauthorized();

			IdentityId = result;

			//Let base handle the request
			return await base.Post(gladNetRequest);
		}
	}
}
