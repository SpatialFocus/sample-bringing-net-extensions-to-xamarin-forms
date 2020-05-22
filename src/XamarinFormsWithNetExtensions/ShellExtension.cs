// <copyright file="ShellExtension.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using Xamarin.Forms;

	public static class ShellExtension
	{
		public static IServiceProvider ServiceProvider(this Shell shell)
		{
			return (shell as AppShell)?.ServiceProvider;
		}
	}
}