using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Factoid
{
    public sealed class HasContextToEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value != null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }

    public sealed class FavoriteSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Windows.UI.Xaml.Controls.IconElement icon = new Windows.UI.Xaml.Controls.SymbolIcon()
            {
                Symbol = ((bool)value) ? Windows.UI.Xaml.Controls.Symbol.UnFavorite : Windows.UI.Xaml.Controls.Symbol.Favorite,
            };

            return icon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }

    public sealed class FavoriteLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((bool)value) ? "Unfavorite" : "Favorite";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }

    public sealed class IsFavoriteBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((bool)value) ?  new Windows.UI.Xaml.Media.SolidColorBrush((Windows.UI.Color)App.Current.Resources["AppMainAccentColor"]) : new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }

    public sealed class IsFavoriteThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((bool)value) ? Windows.UI.Xaml.ElementTheme.Dark : Windows.UI.Xaml.ElementTheme.Light;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
