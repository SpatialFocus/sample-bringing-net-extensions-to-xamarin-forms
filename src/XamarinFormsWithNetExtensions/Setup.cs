// <copyright file="Setup.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.FileProviders;
	using Serilog;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.Services;
	using XamarinFormsWithNetExtensions.ViewModels;
	using XamarinFormsWithNetExtensions.Views;

	public static class Setup
	{
		public static ConfigurationBuilder Configuration => new ConfigurationBuilder();

		public static IServiceCollection DependencyInjection => new ServiceCollection();

		public static IServiceCollection AddViewModels<T>(this IServiceCollection serviceCollection)
		{
			// https://github.com/khellang/Scrutor can simplify things when setting up service registrations
			return serviceCollection.Scan(selector =>
				selector.FromAssemblies(typeof(T).Assembly)
					.AddClasses(filter => filter.InNamespaceOf(typeof(T)))
					.AsSelf()
					.WithTransientLifetime());
		}

		public static IServiceCollection AddViews(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddView<AboutPage, AboutViewModel>()
				.AddView<ItemsPage, ItemsViewModel>()
				.AddView<ItemDetailPage>()
				.AddView<NewItemPage>();

			return serviceCollection;
		}

		public static IServiceCollection ConfigureLogging(this IServiceCollection serviceCollection, IConfigurationRoot configurationRoot)
		{
			return serviceCollection.AddLogging(builder =>
			{
				builder.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(configurationRoot.GetSection("Logging"))
					.CreateLogger());
			});
		}

		public static IServiceCollection ConfigureLocalization(this IServiceCollection serviceCollection, IConfigurationRoot configurationRoot)
		{
			return serviceCollection.AddLocalization(options =>
			{
				options.ResourcesPath = configurationRoot.GetSection("Localization")["ResourcesPath"];
			});
		}

		public static ConfigurationBuilder ConfigureNetStandardProject(this ConfigurationBuilder builder)
		{
			builder.AddJsonFile(new EmbeddedFileProvider(typeof(Setup).Assembly), "appsettings.json", false, false);

			return builder;
		}

		public static IServiceCollection ConfigureNetStandardProject(this IServiceCollection serviceCollection,
			IConfigurationRoot configurationRoot)
		{
			serviceCollection.AddTransient(typeof(MyRouteFactory<>))
				.AddTransient<IDataStore<Item>, MockDataStore>()
				.AddViews()
				.AddViewModels<BaseViewModel>();

			return serviceCollection;
		}

		public static ConfigurationBuilder ConfigurePlatformProject(this ConfigurationBuilder builder,
			Action<ConfigurationBuilder> configure)
		{
			configure(builder);

			return builder;
		}

		public static IServiceCollection ConfigurePlatformProject(this IServiceCollection serviceCollection,
			IConfigurationRoot configurationRoot, Action<IServiceCollection, IConfigurationRoot> configure)
		{
			configure(serviceCollection, configurationRoot);

			return serviceCollection;
		}

		private static IServiceCollection AddView<TView, TViewModel>(this IServiceCollection serviceCollection) where TView : Page
		{
			return serviceCollection.AddTransient<TView>(serviceProvider =>
			{
				TView view = ActivatorUtilities.CreateInstance<TView>(serviceProvider);

				// Autobind specified view model
				view.BindingContext = serviceProvider.GetRequiredService<TViewModel>();

				view.Appearing += (sender, args) => (((BindableObject)sender).BindingContext as IPageLifeCycleAware)?.OnAppearing();
				view.Disappearing += (sender, args) => (((BindableObject)sender).BindingContext as IPageLifeCycleAware)?.OnDisappearing();

				return view;
			});
		}

		private static IServiceCollection AddView<TView>(this IServiceCollection serviceCollection) where TView : Page
		{
			return serviceCollection.AddTransient<TView>(serviceProvider =>
			{
				TView view = ActivatorUtilities.CreateInstance<TView>(serviceProvider);

				view.Appearing += (sender, args) => (((BindableObject)sender).BindingContext as IPageLifeCycleAware)?.OnAppearing();
				view.Disappearing += (sender, args) => (((BindableObject)sender).BindingContext as IPageLifeCycleAware)?.OnDisappearing();

				return view;
			});
		}
	}
}