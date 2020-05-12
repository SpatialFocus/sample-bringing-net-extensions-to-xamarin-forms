// <copyright file="ItemDetailViewModel.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.ViewModels
{
	using XamarinFormsWithNetExtensions.Models;

	public class ItemDetailViewModel : BaseViewModel
	{
		public ItemDetailViewModel(Item item = null)
		{
			Title = item?.Text;
			Item = item;
		}

		public Item Item { get; set; }
	}
}