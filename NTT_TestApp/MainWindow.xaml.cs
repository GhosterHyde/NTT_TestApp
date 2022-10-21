using NTT_TestApp.DataWorkers;
using NTT_TestApp.GraphicInterfaces;
using NTT_TestApp.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace NTT_TestApp
{
    public partial class MainWindow : Window
    {
        private readonly ResultGetter _resultGetter;
        private readonly IGui Gui;

        public MainWindow()
        {
            InitializeComponent();
            Gui = new MyWpfGui(this);
            _resultGetter = new(Gui);
            Gui.StartLoading();
            Task.Run(() => TryConnect(this));
        }

        private void ShowProducts(object sender, RoutedEventArgs e)
        {
            try
            {
                _resultGetter.ShowProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
            }
        }

        private void ShowProductsOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                _resultGetter.ShowProductsOrder();
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
                _resultGetter.ShowCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
            }
        }

        private async Task TryConnect(MainWindow mainWindow)
        {
            try
            {
                await _resultGetter.ConnectDB();
                mainWindow.Dispatcher.Invoke(() =>
                {
                    mainWindow.Gui.StopLoading();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
                mainWindow.Dispatcher.Invoke(() =>
                {
                    mainWindow.Close();
                });
            }
        }
    }
}
