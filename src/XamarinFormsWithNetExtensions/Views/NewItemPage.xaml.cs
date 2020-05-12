// <copyright file="NewItemPage.xaml.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.Views
{
	using System;
	using System.ComponentModel;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Models;

	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class NewItemPage : ContentPage
	{
		public NewItemPage()
		{
			InitializeComponent();

			Item = new Item { Text = "Item name", Description = "This is an item description." };

			BindingContext = this;
		}

		public Item Item { get; set; }

		private async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		private async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopModalAsync();
		}
	}
}