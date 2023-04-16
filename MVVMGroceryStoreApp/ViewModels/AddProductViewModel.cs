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
        public ICommand NavigateProductCommand { get; }
        public AddProductViewModel(INavigationService navigationService)
        {
            NavigateProductCommand = new NavigateCommand(navigationService);
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
