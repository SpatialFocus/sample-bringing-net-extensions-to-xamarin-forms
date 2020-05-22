// <copyright file="ItemDetailViewModel.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.ViewModels
{
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.Services;

	public class ItemDetailViewModel : BaseViewModel
	{
		public ItemDetailViewModel(IDataStore<Item> dateStore, Item item = null) : base(dateStore)
		{
			Title = item?.Text;
			Item = item;
		}

		public Item Item { get; set; }
	}
}