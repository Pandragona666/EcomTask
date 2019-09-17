﻿using Prism;
using Prism.Ioc;
using EcomLocatorV2.ViewModels;
using EcomLocatorV2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EcomLocatorV2
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync("UsersPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<UsersPage, UsersPageViewModel>();
            containerRegistry.RegisterSingleton<IUser, UsersListApi>();
        }
    }
}
