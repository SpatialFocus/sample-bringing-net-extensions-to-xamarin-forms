// <copyright file="ServiceProviderExtension.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Microsoft.Extensions.DependencyInjection;

	public static class ServiceProviderExtension
	{
		public static T GetRequiredServiceWithParameters<T>(this IServiceProvider serviceProvider, params object[] parameters)
		{
			return ActivatorUtilities.CreateInstance<T>(serviceProvider, parameters);
		}
	}
}