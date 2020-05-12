// <copyright file="IDataStore.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IDataStore<T>
	{
		Task<bool> AddItemAsync(T item);

		Task<bool> DeleteItemAsync(string id);

		Task<T> GetItemAsync(string id);

		Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

		Task<bool> UpdateItemAsync(T item);
	}
}