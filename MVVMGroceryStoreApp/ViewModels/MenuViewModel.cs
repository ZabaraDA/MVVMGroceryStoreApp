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


        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        // Представляемая модель                // Выбираем нужную модель
        public MenuViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        } 
        private INavigationService CreateProductNavigationService()
        {
            return new NavigationService<ProductViewModel>(_navigationStore, CreateProductViewModel);
        }

        private ProductViewModel CreateProductViewModel()
        {
            return new ProductViewModel(CreateAddProductNavigationService());
        }

        private INavigationService CreateAddProductNavigationService()
        {
            return new NavigationService<AddProductViewModel>(_navigationStore, CreateAddProductViewModel);
        }

        private AddProductViewModel CreateAddProductViewModel()
        {
            return new AddProductViewModel(CreateProductNavigationService());
        }
        #region Function Commands     
        public ICommand ProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    INavigationService navigationService = CreateProductNavigationService();
                    navigationService.Navigate();
                });
            }
        }
        #endregion
        #region Window State
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
        #endregion
        #region Commands Window State
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
