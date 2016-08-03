using GladNet.Message;
using GladNet.Serializer;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GladNet.ASP.Formatters
{
	/// <summary>
	/// Input formatter for GladNet serialization.
	/// </summary>
	public class GladNetInputFormatter<TDeserializationStrategy> : InputFormatter
		where TDeserializationStrategy : IDeserializerStrategy
	{
		/// <summary>
		/// Strategy to use for deserialization.
		/// </summary>
		private IDeserializerStrategy deserializerStrategy { get; }

		public GladNetInputFormatter(IDeserializerStrategy deserializationStrategy)
		{
			if (deserializationStrategy == null)
				throw new ArgumentNullException(nameof(deserializationStrategy), $"Input formatter requires a deserialization strategy.");

			deserializerStrategy = deserializationStrategy;
		}

		/// <summary>
		/// Determines if the <see cref="GladNetInputFormatter{TDeserializationStrategy}"/> can read the request
		/// in the context.
		/// </summary>
		/// <param name="context">Formatter context.</param>
		/// <returns>True if the formatter can format the context.</returns>
		public override bool CanRead(InputFormatterContext context)
		{
			//This parses the Content-Type from the HTML header
			//It looks for Protobuf-Net
			IList<MediaTypeHeaderValue> mediaTypes = null;
			MediaTypeHeaderValue.TryParseList(context.HttpContext.Request.ContentType.Split(','), out mediaTypes);

			//If it has application/gladnet then we can probably read it
			return mediaTypes.Select(x => x.MediaType).Contains("application/gladnet");
		}

		/// <summary>
		/// Reads and formats the request body based on the gladnet specifications.
		/// </summary>
		/// <param name="context">Formatter context.</param>
		/// <returns>Waitable formatter result.</returns>
		public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
		{
			try
			{
				//we expect a request message to ASP servers so we should deserialize as a request message.
				return InputFormatterResult.SuccessAsync(deserializerStrategy.Deserialize<RequestMessage>(context.HttpContext.Request.Body));
			}
			catch (Exception)
			{
				return InputFormatterResult.FailureAsync();
			}

		}
	}
}
