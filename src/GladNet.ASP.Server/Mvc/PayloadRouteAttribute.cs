using GladNet.Payload;
using Microsoft.AspNetCore.Mvc;
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
		public PayloadRouteAttribute(Type payloadType) 
			: base($"api/{payloadType.Name}")
		{
			//If it's not a child type then throw
			if (!typeof(PacketPayload).IsAssignableFrom(payloadType))
				throw new InvalidOperationException($"Provided Type is not a child of {nameof(PacketPayload)}. Type is: {payloadType?.FullName}.");
		}
	}
}
