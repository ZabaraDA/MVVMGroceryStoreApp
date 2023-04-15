using MVVMGroceryStoreApp.Services;
using MVVMGroceryStoreApp.ViewModels;
using MVVMGroceryStoreApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMGroceryStoreApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = CreateHomeNavigationService();
            navigationService.Navigate();
            MenuWindow menuWindow = new MenuWindow()
            {
                DataContext = new MenuViewModel(_navigationStore, _modalNavigationStore)
            };
            menuWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService()
        {
            return new NavigationService<ProductViewModel>(_navigationStore, CreateProductViewModel);
        }

        private ProductViewModel CreateProductViewModel()
        {
            return new ProductViewModel(CreateAccountNavigationService());
        }

        private INavigationService CreateAccountNavigationService()
        {
            return new NavigationService<AddProductViewModel>(_navigationStore, CreateAddProductViewModel);
        }

        private AddProductViewModel CreateAddProductViewModel()
        {
            return new AddProductViewModel(CreateHomeNavigationService());
        }

    }
}
