// <copyright file="ItemsViewModel.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics;
	using System.Threading.Tasks;
	using Xamarin.Forms;
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.Services;
	using XamarinFormsWithNetExtensions.Views;

	public class ItemsViewModel : BaseViewModel
	{
		public ItemsViewModel(IDataStore<Item> dataStore) : base(dataStore)
		{
			Title = "Browse";
			Items = new ObservableCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				Item newItem = item as Item;
				Items.Add(newItem);
				await DataStore.AddItemAsync(newItem);
			});
		}

		public ObservableCollection<Item> Items { get; set; }

		public Command LoadItemsCommand { get; set; }

		private async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Items.Clear();
				IEnumerable<Item> items = await DataStore.GetItemsAsync(true);

				foreach (Item item in items)
				{
					Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}