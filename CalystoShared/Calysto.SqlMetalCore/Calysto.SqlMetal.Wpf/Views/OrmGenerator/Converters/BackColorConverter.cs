using SqlMetal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calysto.SqlMetal.Wpf.Views.OrmGenerator.Converters
{
    public class BackColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "OrangeRed";
    //        if (value is BackColorEnum color1)
    //        {
				//switch (color1)
				//{
    //                case BackColorEnum.Error: 
    //                    return Brushes.OrangeRed;
    //                case BackColorEnum.Success: 
    //                    return Brushes.GreenYellow;
    //                default: 
    //                    return Brushes.Transparent;
				//}
    //        }
    //        else
    //        {
    //            return null;
    //        }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
