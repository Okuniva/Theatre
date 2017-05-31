﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Theatre.Services
{
    public static class NavigationService
    {
        private static INavigation Navigation => Application.Current.MainPage?.Navigation;

        public static Task Navigate(Page page)
        {
            if (Navigation == null)
            {
                throw new NotSupportedException("Set navigatable main page before calling this.");
            }
            
            return Navigation.PushAsync(page, animated: true);
        }

        // All pages should follow the convention of being named the same way as their respective
        // View Models, except that the ViewModel suffix is replaced by Page.
        private static Page GetPage(object viewModel)
        {
            var pageType = viewModel.GetType().Name.Replace("ViewModel", "Page");
            return (Page)Activator.CreateInstance(Type.GetType($"Contacts.{pageType}"));
        }
    }
}