// <copyright file="App.xaml.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Xamarin.Forms;

	public partial class App : Application
	{
		public App(Action<ConfigurationBuilder> configuration, Action<IServiceCollection, IConfigurationRoot> dependencyServiceConfiguration)
		{
			InitializeComponent();

			IConfigurationRoot configurationRoot = Setup.Configuration
				.ConfigureNetStandardProject()
				.ConfigurePlatformProject(configuration)
				.Build();

			IServiceProvider serviceProvider = Setup.DependencyInjection
				.ConfigureLogging(configurationRoot)
				.ConfigureNetStandardProject(configurationRoot)
				.ConfigurePlatformProject(configurationRoot, dependencyServiceConfiguration)
				.BuildServiceProvider();

			MainPage = new AppShell(serviceProvider);
		}

		protected override void OnResume()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnStart()
		{
		}
	}
}