// <copyright file="AppShell.xaml.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Views;

	public partial class AppShell : Shell
	{
		public AppShell(IServiceProvider serviceProvider)
		{
			ServiceProvider = serviceProvider;

			// Show how .NET extensions DependencyInjection can be used together with URI based shell navigation
			Routing.RegisterRoute("NewItem", ServiceProvider.GetRequiredService<MyRouteFactory<NewItemPage>>());
			Routing.RegisterRoute("ItemDetail", ServiceProvider.GetRequiredService<MyRouteFactory<ItemDetailPage>>());

			InitializeComponent();
		}

		public IServiceProvider ServiceProvider { get; }
	}
}