// <copyright file="ItemsPage.xaml.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.Views
{
	using System;
	using System.ComponentModel;
	using Microsoft.Extensions.DependencyInjection;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.ViewModels;

	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		public ItemsPage()
		{
			InitializeComponent();

			// Since the page is created by DI, BindingContext will be automatically set
			////BindingContext = this.viewModel = new ItemsViewModel();
		}

		protected ItemsViewModel ViewModel => BindingContext as ItemsViewModel;

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (ViewModel.Items.Count == 0)
			{
				ViewModel.IsBusy = true;
			}
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(Shell.Current.ServiceProvider().GetRequiredService<NewItemPage>());
		}

		private async void OnItemSelected(object sender, EventArgs args)
		{
			BindableObject layout = (BindableObject)sender;
			Item item = (Item)layout.BindingContext;

			// Let the page be created by our custom RouteFactory
			await Shell.Current.GoToAsync($"ItemDetail?id={item.Id}");
			////await Navigation.PushAsync(new ItemDetailPage(Shell.Current.ServiceProvider().GetRequiredServiceWithParameters<ItemDetailViewModel>(item)));
		}
	}
}