using MVVMGroceryStoreApp.Models.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMGroceryStoreApp.Models
{
    public class ProductModel
    {
        public List<Товар> GetAllProducts()
        {
            return GroceryStoreDatabase.GetContext().Товар.ToList();
        }

        public void AddProduct(Товар currentProduct)
        {
            try
            {
                GroceryStoreDatabase.GetContext().Товар.Add(currentProduct);
                GroceryStoreDatabase.GetContext().SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        } 
        public void UpdateProduct(Товар currentProduct)
        {
            try
            {
                GroceryStoreDatabase.GetContext().Товар.AddOrUpdate(currentProduct);
                GroceryStoreDatabase.GetContext().SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
