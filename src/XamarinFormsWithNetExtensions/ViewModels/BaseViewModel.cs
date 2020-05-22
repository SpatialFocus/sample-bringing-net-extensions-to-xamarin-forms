// <copyright file="BaseViewModel.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using XamarinFormsWithNetExtensions.Models;
	using XamarinFormsWithNetExtensions.Services;

	public class BaseViewModel : INotifyPropertyChanged, IPageLifeCycleAware
	{
		private bool isBusy = false;

		private string title = string.Empty;

		public BaseViewModel(IDataStore<Item> dataStore)
		{
			DataStore = dataStore;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public IDataStore<Item> DataStore { get; }

		public bool IsBusy
		{
			get { return this.isBusy; }
			set { SetProperty(ref this.isBusy, value); }
		}

		public string Title
		{
			get { return this.title; }
			set { SetProperty(ref this.title, value); }
		}

		public virtual void OnAppearing()
		{
		}

		public virtual void OnDisappearing()
		{
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChangedEventHandler changed = PropertyChanged;

			if (changed == null)
			{
				return;
			}

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
			{
				return false;
			}

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}