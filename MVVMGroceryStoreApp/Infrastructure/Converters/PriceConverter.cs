using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVMGroceryStoreApp.Infrastructure.Converters
{
    [ValueConversion(typeof(decimal), typeof(decimal))]
    public class PriceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
                return null;

            Nullable<decimal> cost;
            Nullable<decimal> quantity;

            cost = values[0] as Nullable<decimal>;
            quantity = values[1] as Nullable<decimal>;

            if (cost == null || quantity == null)
                return null;

            return (cost * quantity);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

