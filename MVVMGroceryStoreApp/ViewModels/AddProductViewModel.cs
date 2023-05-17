using MVVMGroceryStoreApp.Infrastructure.Commands;
using MVVMGroceryStoreApp.Models;
using MVVMGroceryStoreApp.Models.Databases;
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
    public class AddProductViewModel : BaseViewModel
    {
        private readonly ProductModel _productModel = new ProductModel();
        private readonly GroupModel _groupModel = new GroupModel();

        private readonly ProductStore _productStore;
        public Товар CurrentProduct => _productStore.CurrentProduct;

        #region ProductProperty
        public int Id
        {
            get
            {
                return _productStore.CurrentProduct.Код;
            }
            set
            {
                _productStore.CurrentProduct.Код = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get
            {
                return _productStore.CurrentProduct.Наименование;
            }
            set
            {
                _productStore.CurrentProduct.Наименование = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get
            {
                return _productStore.CurrentProduct.Описание;
            }
            set
            {
                _productStore.CurrentProduct.Описание = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Article
        {
            get
            {
                return _productStore.CurrentProduct.Артикул;
            }
            set
            {
                _productStore.CurrentProduct.Артикул = value;
                OnPropertyChanged(nameof(Article));
            }
        }

        public string Barcode
        {
            get
            {
                return _productStore.CurrentProduct.ШтрихКод;
            }
            set
            {
                _productStore.CurrentProduct.ШтрихКод = value;
                OnPropertyChanged(nameof(Barcode));
            }
        }

        public byte VAT
        {
            get
            {
                return _productStore.CurrentProduct.НДС;
            }
            set
            {
                _productStore.CurrentProduct.НДС = value;
                OnPropertyChanged(nameof(VAT));
            }
        }
        public decimal Cost
        {
            get
            {
                return _productStore.CurrentProduct.Цена;
            }
            set
            {
                _productStore.CurrentProduct.Цена = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
        public int ExpirationDate
        {
            get
            {
                return _productStore.CurrentProduct.СрокГодности;
            }
            set
            {
                _productStore.CurrentProduct.СрокГодности = value;
                OnPropertyChanged(nameof(ExpirationDate));
            }
        }
        public bool Status
        {
            get
            {
                return _productStore.CurrentProduct.Статус;
            }
            set
            {
                _productStore.CurrentProduct.Статус = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public decimal Quantity
        {
            get
            {
                return _productStore.CurrentProduct.Количество;
            }
            set
            {
                _productStore.CurrentProduct.Количество = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public decimal Weight
        {
            get
            {
                return _productStore.CurrentProduct.Вес;
            }
            set
            {
                _productStore.CurrentProduct.Вес = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public int Width
        {
            get
            {
                return _productStore.CurrentProduct.Ширина;
            }
            set
            {
                _productStore.CurrentProduct.Ширина = value;
                OnPropertyChanged(nameof(Width));
            }
        }
        public int Height
        {
            get
            {
                return _productStore.CurrentProduct.Высота;
            }
            set
            {
                _productStore.CurrentProduct.Высота = value;
                OnPropertyChanged(nameof(Height));
            }
        }
        public int Depth
        {
            get
            {
                return _productStore.CurrentProduct.Глубина;
            }
            set
            {
                _productStore.CurrentProduct.Глубина = value;
                OnPropertyChanged(nameof(Depth));
            }
        }

        public byte[] Photo
        {
            get { return _productStore.CurrentProduct.Фото; }
            set
            {
                _productStore.CurrentProduct.Фото = value;
                OnPropertyChanged(nameof(Photo));
            }
        }
        #endregion
        #region Zero Properties
        private static Группа _zeroGroup = new Группа()
        {
            Наименование = "Выберите группу",
        };
        private static Категория _zeroCategory = new Категория()
        {
            Наименование = "Выберите категорию"
        };
        #endregion

        private List<Группа> _groupsList;
        public List<Группа> GroupsList
        {
            get
            {
                return _groupsList;
            }
            set
            {
                _groupsList = value;
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        private Группа _selectedGroup;
        public Группа SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        public Категория SelectedCategory
        {
            get
            {
                return _productStore.CurrentProduct.Категория;
            }
            set
            {
                _productStore.CurrentProduct.Категория = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public AddProductViewModel(INavigationService navigationService, ProductStore productStore)
        {

            GroupsList = _groupModel.GetAllGroups();
            _zeroGroup.Категория.Add(_zeroCategory);
            GroupsList.Insert(0, _zeroGroup);

            _productStore = productStore;
            _productStore.CurrentProductChanged += OnCurrentProductChanged;
            //_productStore.CurrentProduct = new Товар();

            SelectedGroup = _zeroGroup;
            SelectedCategory = _zeroCategory;

            NavigateProductCommand = new NavigateCommand(navigationService);
        }
        private void OnCurrentProductChanged() 
        {
            OnPropertyChanged(nameof(CurrentProduct));
        }

        #region Function Commands 
        public ICommand AddProductCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    _productModel.AddProduct(_productStore.CurrentProduct);
                });
            }
        }
        public ICommand AddPhotoCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    Photo = PhotoImportService.ImportToByte(800);
                });
            }
        }
        public ICommand ClearPhotoCommand
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                    Photo = null;
                }, (obj) => Photo != null);
            }
        }
        public ICommand NavigateProductCommand { get; }
        #endregion
    }
}
