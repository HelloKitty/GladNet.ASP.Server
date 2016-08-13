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
			: base($"api/{GetNameWithoutGenericArity(payloadType).TrimEnd("Payload".ToArray())}") //basically maps to api/PayloadName without generic stuff like '1 or the Payload identifier at the end of the TypeName.
		{
			//If it's not a child type then throw
			if (!typeof(PacketPayload).IsAssignableFrom(payloadType))
				throw new InvalidOperationException($"Provided Type is not a child of {nameof(PacketPayload)}. Type is: {payloadType?.FullName}.");
		}

		//based on: http://stackoverflow.com/questions/6386202/get-type-name-without-any-generics-info
		private static string GetNameWithoutGenericArity(Type t)
		{
			string name = t.Name;
			int index = name.IndexOf('`');
			return index == -1 ? name : name.Substring(0, index);
		}
	}
}
