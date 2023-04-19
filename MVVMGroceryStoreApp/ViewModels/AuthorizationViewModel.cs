using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Models;
using MVVMGroceryStoreApp.Models.Databases;
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
        private AuthorizationModel _authorizationModel;
        private readonly NavigationStore _navigationStore;

        public AuthorizationViewModel()
        {
            _navigationStore = new NavigationStore();
            _authorizationModel = new AuthorizationModel();
        }

        async protected void MenuViewModelStartup()
        {
            await Task.Run(() =>
            {

                if (_authorizationModel.AccountValidation(Login, Password) == null)
                {
                    MessageBox.Show("Неверно введён логин или пароль");
                    AnimationVisiblity = Visibility.Hidden;
                    return;
                }
                INavigationService navigationService = new NavigationService<WelcomeViewModel>(_navigationStore, CreateWelcomeViewModel);
                navigationService.Navigate();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MenuWindow menuWindow = new MenuWindow()
                    {
                        DataContext = new MenuViewModel(_navigationStore)
                    };
                    menuWindow.Show();
                    Application.Current.Windows[0].Close();
                });
                
            });

        }

        private WelcomeViewModel CreateWelcomeViewModel()
        {
            return new WelcomeViewModel();
        }

        #region Login Properties        
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
        #endregion
        #region Window State Properties

        private Visibility _animationVisiblity = Visibility.Hidden;
        public Visibility AnimationVisiblity
        {
            get
            {
                return _animationVisiblity;
            }
            set
            {
                _animationVisiblity = value;
                OnPropertyChanged(nameof(AnimationVisiblity));
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
        #endregion
        #region Function Commands
        public ICommand OpenCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    AnimationVisiblity = Visibility.Visible;
                    MenuViewModelStartup();                    
                });
            }
        }
        #endregion
        #region Window State Commands
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

        #endregion

    }
}
