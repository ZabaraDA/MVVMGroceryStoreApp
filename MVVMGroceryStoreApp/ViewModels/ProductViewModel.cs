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
using MVVMGroceryStoreApp.Models;

namespace MVVMGroceryStoreApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly ProductModel _productModel = new ProductModel();
        private readonly GroupModel _groupModel = new GroupModel();

        private readonly ProductStore _productStore;

        //private Товар _selectedProduct;
        public Товар SelectedProduct /*=> _productStore.CurrentProduct*/
        {
            get
            {
                return _productStore.CurrentProduct;
            }
            set
            {
                _productStore.CurrentProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private ObservableCollection<Группа> _groupList = new ObservableCollection<Группа>();
        public IEnumerable<Группа> GroupList => _groupList;




        public ProductViewModel(INavigationService navigationService, ProductStore productStore)
        {

            _productStore = productStore;
            foreach (var group in _groupModel.GetAllGroups())
            {
                _groupList.Add(group);
            }

            ChangeProductCommand = new NavigateProductCommand(navigationService, _productStore);
            NavigateProductCommand = new NavigateCommand(navigationService);
        }
        #region Commands

        public ICommand NavigateProductCommand { get; }
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
        public ICommand ChangeProductCommand { get; }

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
