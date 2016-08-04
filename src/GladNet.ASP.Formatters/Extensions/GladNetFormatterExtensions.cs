using GladNet.ASP.Formatters;
using GladNet.Serializer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//I know we shouldn't hijack Microsoft namespaces but it's so much easier for consumers
//to access these extensions this way
namespace Microsoft.AspNet.Builder
{
	/// <summary>
	/// Extensions for Fluent MvcBuilder interfaces.
	/// </summary>
	public static class GladNetFormatterExtensions
	{
		/// <summary>
		/// Adds the <see cref="GladNetInputFormatter"/> and <see cref="GladNetOutputFormatter"/> to the known formatters.
		/// Also registers the gladnet media header to map to these formatters.
		/// </summary>
		/// <param name="builder">Builder to chain off.</param>
		/// <returns>The fluent <see cref="IMvcCoreBuilder"/> instance.</returns>
		public static IMvcCoreBuilder AddGladNetFormatters(this IMvcCoreBuilder builder, ISerializerStrategy serializerStrat, IDeserializerStrategy deserializerStrat)
		{
			//Add the formatters to the options.
			return builder.AddMvcOptions(options =>
			{
				options.InputFormatters.Add(new GladNetInputFormatter(deserializerStrat));
				options.OutputFormatters.Add(new GladNetOutputFormatter(serializerStrat));
				options.FormatterMappings.SetMediaTypeMappingForFormat("GladNet", MediaTypeHeaderValue.Parse("application/gladnet"));
			});
		}

		/// <summary>
		/// Adds the <see cref="GladNetInputFormatter"/> and <see cref="GladNetOutputFormatter"/> to the known formatters.
		/// Also registers the gladnet media header to map to these formatters.
		/// </summary>
		/// <param name="builder">Builder to chain off.</param>
		/// <returns>The fluent <see cref="IMvcBuilder"/> instance.</returns>
		public static IMvcBuilder AddGladNetFormatters(this IMvcBuilder builder, ISerializerStrategy serializerStrat, IDeserializerStrategy deserializerStrat)
		{
			//Add the formatters to the options.
			return builder.AddMvcOptions(options =>
			{
				options.InputFormatters.Add(new GladNetInputFormatter(deserializerStrat));
				options.OutputFormatters.Add(new GladNetOutputFormatter(serializerStrat));
				options.FormatterMappings.SetMediaTypeMappingForFormat("GladNet", MediaTypeHeaderValue.Parse("application/gladnet"));
			});
		}
	}
}
