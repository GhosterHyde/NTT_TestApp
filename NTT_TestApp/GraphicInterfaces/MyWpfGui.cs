using NTT_TestApp.Interfaces;
using System.Collections;
using System.Windows;

namespace NTT_TestApp.GraphicInterfaces
{
    internal class MyWpfGui : IGui
    {
        MainWindow MainWindow { get; set; }
        public MyWpfGui(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        public void Clear()
        {
            MainWindow.CategoriesDG.Visibility = Visibility.Hidden;
            MainWindow.ProductsDG.Visibility = Visibility.Hidden;
            MainWindow.Loading.Visibility = Visibility.Visible;
        }

        public void StartLoading()
        {
            MainWindow.Loading.Visibility = Visibility.Visible;
            MainWindow.ShowProductsButton.IsEnabled = false;
            MainWindow.ShowProductsOrderButton.IsEnabled = false;
            MainWindow.ShowCategoriesButton.IsEnabled = false;
        }

        public void StopLoading()
        {
            MainWindow.Loading.Visibility = Visibility.Hidden;
            MainWindow.ShowProductsButton.IsEnabled = true;
            MainWindow.ShowProductsOrderButton.IsEnabled = true;
            MainWindow.ShowCategoriesButton.IsEnabled = true;
        }

        public void ShowProducts(IEnumerable Items)
        {
            MainWindow.ProductsDG.ItemsSource = Items;
            MainWindow.ProductsDG.Visibility = Visibility.Visible;
            MainWindow.Loading.Visibility = Visibility.Hidden;
        }

        public void ShowCategories(IEnumerable Items)
        {
            MainWindow.CategoriesDG.ItemsSource = Items;
            MainWindow.CategoriesDG.Visibility = Visibility.Visible;
            MainWindow.Loading.Visibility = Visibility.Hidden;
        }
    }
}
