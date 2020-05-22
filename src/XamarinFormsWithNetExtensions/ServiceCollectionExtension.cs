// <copyright file="ServiceCollectionExtension.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using System.Linq;
	using Microsoft.Extensions.DependencyInjection;

	public static class ServiceCollectionExtension
	{
		public static IServiceCollection ForClassesInSameNamespace<TClass>(this IServiceCollection serviceCollection,
			Action<Type> action)
		{
			typeof(TClass).Assembly.GetTypes()
				.Where(x => x.IsClass && !x.IsAbstract && x.Namespace.Contains(typeof(TClass).Namespace))
				.ToList()
				.ForEach(x => action(x));

			return serviceCollection;
		}
	}
}