// <copyright file="Setup.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.Droid
{
	using System;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.FileProviders;

	public class Setup
	{
		public static Action<ConfigurationBuilder> Configuration =>
			(builder) =>
			{
				builder.AddJsonFile(new EmbeddedFileProvider(typeof(Setup).Assembly, typeof(Setup).Namespace), "appsettings.json", false,
					false);
			};

		public static Action<IServiceCollection, IConfigurationRoot> DependencyInjection =>
			(serviceCollection, configurationRoot) =>
			{
			};
	}
}