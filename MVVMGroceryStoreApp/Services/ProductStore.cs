using MVVMGroceryStoreApp.Models.Databases;
using MVVMGroceryStoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGroceryStoreApp.Services
{
    public class ProductStore
    {
        private Товар _currentProduct;
        public Товар CurrentProduct
        {
            get => _currentProduct;
            set
            {
                _currentProduct = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentProductChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentProductChanged?.Invoke();
        }

    }
}
