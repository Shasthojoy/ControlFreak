namespace ControlFreak.Views.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    class IntPtrToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IntPtr))
                return "DEADBEEF";

            var ptr = (IntPtr)value;

            if (IntPtr.Size == 8)
                return ptr.ToInt64().ToString("X16");
            else
                return ptr.ToInt32().ToString("X8");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
