using MVVMGroceryStoreApp.Infrastructure.Commands;
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
                    MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();
                    Application.Current.Windows[0].Close();
                });
            }
        }
        #endregion

    }
}
