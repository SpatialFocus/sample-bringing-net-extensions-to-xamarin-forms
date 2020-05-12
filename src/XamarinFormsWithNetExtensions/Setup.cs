// <copyright file="Setup.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.FileProviders;

	public static class Setup
	{
		public static ConfigurationBuilder Configuration => new ConfigurationBuilder();

		public static ConfigurationBuilder ConfigureNetStandardProject(this ConfigurationBuilder builder)
		{
			builder.AddJsonFile(new EmbeddedFileProvider(typeof(Setup).Assembly), "appsettings.json", false, false);

			return builder;
		}

		public static ConfigurationBuilder ConfigurePlatformProject(this ConfigurationBuilder builder,
			Action<ConfigurationBuilder> configure)
		{
			configure(builder);

			return builder;
		}
	}
}