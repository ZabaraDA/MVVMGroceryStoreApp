using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Services;
using MVVMGroceryStoreApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AuthorizationViewModel()
        {
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected void OnStartup()
        {
            INavigationService navigationService = CreateHomeNavigationService();
            navigationService.Navigate();
            MenuWindow menuWindow = new MenuWindow()
            {
                DataContext = new MenuViewModel(_navigationStore, _modalNavigationStore)
            };
            menuWindow.Show();
            
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
        private string _login;
        public string Login
        {
            get 
            { 
                return _login; 
            }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        private SecureString _password;
        public SecureString Password
        {
            private get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private WindowState _windowState = WindowState.Normal;
        public WindowState WindowState
        {
            get 
            { 
                return _windowState;
            }
            set 
            { 
                _windowState = value;
                OnPropertyChanged(nameof(WindowState));
            }
        }

        
        #region Commands
        public ICommand ExitCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                   Application.Current.Shutdown();
                });
            }
        }
        public ICommand MinimizedCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    WindowState = WindowState.Minimized;
                });
            }
        }
        public ICommand OpenCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    OnStartup();
                    Application.Current.Windows[0].Close();
                });
            }
        }
        #endregion

    }
}
