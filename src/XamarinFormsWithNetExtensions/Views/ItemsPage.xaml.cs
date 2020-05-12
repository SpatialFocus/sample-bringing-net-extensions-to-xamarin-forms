// <copyright file="ItemsPage.xaml.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.Views
{
	using System;
	using System.ComponentModel;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.ViewModels;

	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		private readonly ItemsViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = this.viewModel = new ItemsViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (this.viewModel.Items.Count == 0)
			{
				this.viewModel.IsBusy = true;
			}
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
		}

		private async void OnItemSelected(object sender, EventArgs args)
		{
			BindableObject layout = (BindableObject)sender;
			Item item = (Item)layout.BindingContext;
			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
		}
	}
}