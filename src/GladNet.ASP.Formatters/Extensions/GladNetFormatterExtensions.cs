﻿using GladNet.ASP.Formatters;
using GladNet.Serializer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

//I know we shouldn't hijack Microsoft namespaces but it's so much easier for consumers
//to access these extensions this way
namespace Microsoft.Extensions.DependencyInjection
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
		/// <param name="serializerStrat">Serialization strategy</param>
		/// <param name="deserializerStrat">Deserialization strategy.</param>
		/// <returns>The fluent <see cref="IMvcCoreBuilder"/> instance.</returns>
		public static IMvcCoreBuilder AddGladNetFormatters([NotNull] this IMvcCoreBuilder builder, [NotNull] ISerializerStrategy serializerStrat, [NotNull] IDeserializerStrategy deserializerStrat)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (serializerStrat == null) throw new ArgumentNullException(nameof(serializerStrat));
			if (deserializerStrat == null) throw new ArgumentNullException(nameof(deserializerStrat));

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
		/// <param name="serializerStrat">Serialization strategy</param>
		/// <param name="deserializerStrat">Deserialization strategy.</param>
		/// <returns>The fluent <see cref="IMvcCoreBuilder"/> instance.</returns>
		public static IMvcBuilder AddGladNetFormatters([NotNull] this IMvcBuilder builder, [NotNull] ISerializerStrategy serializerStrat, [NotNull] IDeserializerStrategy deserializerStrat)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (serializerStrat == null) throw new ArgumentNullException(nameof(serializerStrat));
			if (deserializerStrat == null) throw new ArgumentNullException(nameof(deserializerStrat));

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
