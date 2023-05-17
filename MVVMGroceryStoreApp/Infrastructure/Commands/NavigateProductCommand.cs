using MVVMGroceryStoreApp.Models.Databases;
using MVVMGroceryStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGroceryStoreApp.Infrastructure.Commands
{
    public class NavigateProductCommand : BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly ProductStore _productStore;

        public NavigateProductCommand(INavigationService navigationService,ProductStore productStore)
        {
            _navigationService = navigationService;
            _productStore = productStore;   
        }

        public override void Execute(object parameter)
        {
            _productStore.CurrentProduct = parameter as Товар;
            _navigationService.Navigate();
        }


        //private readonly LoginViewModel _viewModel;
        //private readonly AccountStore _accountStore;
        //private readonly INavigationService _navigationService;

        //public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, INavigationService navigationService)
        //{
        //    _viewModel = viewModel;
        //    _accountStore = accountStore;
        //    _navigationService = navigationService;
        //}

        //public override void Execute(object parameter)
        //{
        //    Account account = new Account()
        //    {
        //        Email = $"{_viewModel.Username}@test.com",
        //        Username = _viewModel.Username
        //    };

        //    _accountStore.CurrentAccount = account;

        //    _navigationService.Navigate();
        //}
    }
}
