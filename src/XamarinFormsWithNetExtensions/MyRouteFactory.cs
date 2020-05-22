// <copyright file="MyRouteFactory.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Xamarin.Forms;

	public class MyRouteFactory<T> : RouteFactory where T : Element
	{
		public MyRouteFactory(IServiceProvider serviceProvider)
		{
			ServiceProvider = serviceProvider;
		}

		protected IServiceProvider ServiceProvider { get; }

		public override Element GetOrCreate() => ServiceProvider.GetRequiredService<T>();
	}
}