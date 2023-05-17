using MVVMGroceryStoreApp.Models.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGroceryStoreApp.Models
{
    public class GroupModel
    {
        public List<Группа> GetAllGroups()
        {
            return GroceryStoreDatabase.GetContext().Группа.ToList();
        }
    }
}
