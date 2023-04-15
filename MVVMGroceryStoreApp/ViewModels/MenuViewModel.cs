using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        private readonly ModalNavigationStore _modalNavigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public BaseViewModel CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public bool IsOpen => _modalNavigationStore.IsOpen;

        public MenuViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;

            //ProductCommand = new ActionCommand(Product);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }


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
        //public ICommand ProductCommand { get; set; }
        //private void Product(object obj) => CurrentView = new ProductViewModel(_navigationService);



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
