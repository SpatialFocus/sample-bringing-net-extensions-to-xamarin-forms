// <copyright file="IPageLifeCycleAware.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	public interface IPageLifeCycleAware
	{
		void OnAppearing();

		void OnDisappearing();
	}
}