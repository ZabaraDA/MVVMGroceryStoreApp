using MVVMGroceryStoreApp.Models.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGroceryStoreApp.Models
{
    public class ProductModel
    {
        public static List<Товар> GetAllProduct()
        {
            return GroceryStoreDatabase.GetContext().Товар.ToList();
        }
    }
}
