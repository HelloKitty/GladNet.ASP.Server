using GladNet.Message;
using GladNet.Serializer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladNet.ASP.Formatters
{
	/// <summary>
	/// Input formatter for GladNet serialization.
	/// </summary>
	public class GladNetOutputFormatter : OutputFormatter
	{
		/// <summary>
		/// Strategy to use for serialization.
		/// </summary>
		private ISerializerStrategy serializerStrategy { get; }

		public GladNetOutputFormatter(ISerializerStrategy serializationStrategy)
		{
			if (serializationStrategy == null)
				throw new ArgumentNullException(nameof(serializationStrategy), $"Input formatter requires a serialization strategy.");

			serializerStrategy = serializationStrategy;

			SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/gladnet"));
		}

		/// <summary>
		/// Formats and writes the response body based on the gladnet specifications.
		/// </summary>
		/// <param name="context">Formatter context.</param>
		/// <returns>Waitable writing <see cref="Task"/></returns>
		public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
		{
			//We need to check if the message contains a payload as we must
			//manually serialize that field
			IPayloadContainer container = context.Object as IPayloadContainer;

			if(container != null)
			{
				container.Payload.Serialize(serializerStrategy);
			}

			//Serializes the Object into the response stream
			serializerStrategy.Serialize(context.HttpContext.Response.Body, context.Object);

			return Task.FromResult(context.HttpContext.Response);
		}

		/// <summary>
		/// Determines if the <see cref="ProtobufNetOutputFormatter"/> can write/format the result
		/// in the context.
		/// </summary>
		/// <param name="context">Formatter context.</param>
		/// <returns>True if the formatter can write/format the context.</returns>
		public override bool CanWriteResult(OutputFormatterCanWriteContext context)
		{
			//Checks if the message is a NetworkMessage and thus serializable.
			if (!typeof(NetworkMessage).IsAssignableFrom(context.ObjectType))
				return false;

			context.ContentType = new Microsoft.Extensions.Primitives.StringSegment(@"application/gladnet");

			return true;
		}
	}
}
