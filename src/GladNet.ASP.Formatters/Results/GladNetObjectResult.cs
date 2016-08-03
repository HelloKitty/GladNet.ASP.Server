using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladNet.ASP
{
	/// <summary>
	/// An <see cref="ObjectResult"/> with a gladnet Content-Type header.
	/// </summary>
	public class GladNetObjectResult : ObjectResult
	{
		/// <summary>
		/// Creates an <see cref="ObjectResult"/> object with a gladnet content header.
		/// </summary>
		/// <param name="value">GladNet serializable object value.</param>
		public GladNetObjectResult(object value)
			: base(value)
		{
			//Writes the content types to be only the protobuf-net content type
			this.ContentTypes.Clear();
			ContentTypes.Add(new MediaTypeHeaderValue("application/gladnet"));
		}
	}
}
