using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {
        public AddProductViewModel(INavigationService navigationService)
        {

        }
        public ICommand AddProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {

                });
            }
        }
    }
}
