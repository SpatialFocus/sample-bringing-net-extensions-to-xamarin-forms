// <copyright file="MockDataStore.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using XamarinFormsWithNetExtensions.Models;

	public class MockDataStore : IDataStore<Item>
	{
		private readonly List<Item> items;

		public MockDataStore()
		{
			this.items = new List<Item>()
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description = "This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description = "This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description = "This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description = "This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description = "This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description = "This is an item description." },
			};
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			this.items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			Item oldItem = this.items.Where((Item arg) => arg.Id == id).FirstOrDefault();
			this.items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(this.items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(this.items);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			Item oldItem = this.items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			this.items.Remove(oldItem);
			this.items.Add(item);

			return await Task.FromResult(true);
		}
	}
}