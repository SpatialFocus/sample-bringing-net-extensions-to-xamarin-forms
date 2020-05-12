// <copyright file="App.xaml.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.Configuration;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Services;

	public partial class App : Application
	{
		public App(Action<ConfigurationBuilder> configuration)
		{
			InitializeComponent();

			IConfigurationRoot configurationRoot = Setup.Configuration
				.ConfigureNetStandardProject()
				.ConfigurePlatformProject(configuration)
				.Build();

			// TODO: Store configuration root, bind configuration to concrete classes, ...
			string value = configurationRoot["Key2"];

			DependencyService.Register<MockDataStore>();
			MainPage = new AppShell();
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