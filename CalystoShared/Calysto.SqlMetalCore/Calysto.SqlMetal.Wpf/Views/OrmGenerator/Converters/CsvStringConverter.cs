using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calysto.SqlMetal.Wpf.Views.OrmGenerator.Converters
{
    public class CsvStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string> list1)
            {
                return string.Join(", ", list1);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str1)
            {
                return str1.Split(',', ';', ' ', '\t', '\r', '\n').Select(o => o?.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToList();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

}
