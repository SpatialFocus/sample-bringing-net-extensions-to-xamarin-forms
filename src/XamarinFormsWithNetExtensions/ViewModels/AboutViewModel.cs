﻿// <copyright file="AboutViewModel.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.ViewModels
{
	using System.Windows.Input;
	using Microsoft.Extensions.Logging;
	using Xamarin.Essentials;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.Services;

	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel(IDataStore<Item> dataStore, ILogger<AboutViewModel> logger) : base(dataStore)
		{
			Title = "About";
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));

			logger.LogWarning($"Hello from {nameof(AboutViewModel)}");
		}

		public ICommand OpenWebCommand { get; }
	}
}