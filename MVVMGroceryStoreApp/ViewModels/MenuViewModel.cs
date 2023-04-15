using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
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

        private ResizeMode _resizeMode;
        public ResizeMode ResizeMode
        {
            get
            {
                return _resizeMode;
            }
            set
            {
                _resizeMode = value;
                OnPropertyChanged(nameof(ResizeMode));
            }
        }
        public ICommand ProductCommand { get; set; }
        private void Product(object obj) => CurrentView = new ProductViewModel();

        public MenuViewModel()
        {
            ProductCommand = new ActionCommand(Product);
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
        public ICommand ScreenCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    if (WindowState == WindowState.Normal)
                    {
                        ResizeMode = ResizeMode.NoResize;
                        WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        WindowState = WindowState.Normal;
                        ResizeMode = ResizeMode.CanResize;
                    }
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
