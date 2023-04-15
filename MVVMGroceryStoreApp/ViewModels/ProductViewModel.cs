using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {        
        #region Commands
        public ICommand AddProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    
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
