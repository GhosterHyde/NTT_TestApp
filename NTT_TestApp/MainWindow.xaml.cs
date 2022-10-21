using NTT_TestApp.DataWorkers;
using NTT_TestApp.GraphicInterfaces;
using NTT_TestApp.Interfaces;
using System;
using System.Windows;

namespace NTT_TestApp
{
    public partial class MainWindow : Window
    {
        private readonly ResultGetter _resultGetter;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                IGui Gui = new MyWpfGui(this);
                _resultGetter = new(Gui);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
                this.Close();
            }
        }

        private void ShowProducts(object sender, RoutedEventArgs e)
        {
            try
            {
                _resultGetter?.ShowProducts();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
            }
        }

        private void ShowProductsOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                _resultGetter?.ShowProductsOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
            }
        }

        private void ShowCategories(object sender, RoutedEventArgs e)
        {
            try
            {
                _resultGetter?.ShowCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
            }
        }
    }
}
