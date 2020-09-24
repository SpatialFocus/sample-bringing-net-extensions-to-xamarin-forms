// <copyright file="TranslateExtension.cs" company="Spatial Focus">
// Copyright (c) Spatial Focus. All rights reserved.
// </copyright>

namespace XamarinFormsWithNetExtensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Microsoft.Extensions.Localization;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	[ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		public string Text { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
			{
				throw new ArgumentNullException(nameof(serviceProvider));
			}

			return TranslateExtension.GetStringLocalizer(GetRootObjectType(serviceProvider))[Text];
		}

		protected static IStringLocalizer GetStringLocalizer(Type type)
		{
			Type stringLocalizerTypeOfT = typeof(IStringLocalizer<>).MakeGenericType(type);

			return (IStringLocalizer)Shell.Current.ServiceProvider().GetService(stringLocalizerTypeOfT);
		}

		// See https://stackoverflow.com/questions/55869794/access-contentpage-from-imarkupextension
		protected Type GetRootObjectType(IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
			{
				throw new ArgumentNullException(nameof(serviceProvider));
			}

			IProvideValueTarget valueProvider = serviceProvider.GetService<IProvideValueTarget>() ??
				throw new ArgumentException("serviceProvider does not provide an IProvideValueTarget");

			PropertyInfo cachedPropertyInfo = valueProvider.GetType()
				.GetProperty("Xamarin.Forms.Xaml.IProvideParentValues.ParentObjects", BindingFlags.NonPublic | BindingFlags.Instance);

			if (cachedPropertyInfo != null)
			{
				IEnumerable<object> parentObjects = cachedPropertyInfo.GetValue(valueProvider) as IEnumerable<object>;

				if (parentObjects == null)
				{
					throw new ArgumentException("Unable to access parent objects");
				}

				IEnumerable<object> enumerable = parentObjects as object[] ?? parentObjects.ToArray();

				foreach (object target in enumerable)
				{
					if (target is Page page)
					{
						return target.GetType();
					}
				}

				return enumerable.Last().GetType();
			}

			throw new XamlParseException($"Unable to access parent page");
		}
	}
}