using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMGroceryStoreApp.Models.Databases;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        
        public ICommand NavigateProductCommand { get; }


        public ProductViewModel(INavigationService navigationService)
        {
            NavigateProductCommand = new NavigateCommand(navigationService);
        }
        #region Commands
        public ICommand AddProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    GroceryStoreDatabase.GetContext().Товар.ToList();
                });
            }
        }
        public ICommand ViewProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                   
                });
            }
        }
        public ICommand ChangeProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                   
                });
            }
        }
        public ICommand DeactivateProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {

                });
            }
        }
        #endregion
    }
}
