
using Microsoft.Extensions.DependencyInjection;
using MVVMGroceryStoreApp.ViewModels;
using System;
using System.Windows;

namespace MVVMGroceryStoreApp.Infrastructure
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public static void InitializeComponent()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<AuthorizationViewModel>();
            services.AddSingleton<MenuViewModel>();



            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }
    }
}
