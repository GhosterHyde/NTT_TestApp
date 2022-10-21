using NTT_TestApp.Interfaces;
using NTT_TestApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace NTT_TestApp.DataWorkers
{
    internal class ResultGetter
    {
        private readonly DataLoader dataLoader = new();

        private ObservableCollection<ProductCategory> Items = new();

        private IGui Gui { get; set; }

        public ResultGetter(IGui gui)
        {
            Gui = gui;
            ConnectDB();
        }

        private async Task ConnectDB()
        {
            Gui.StartLoading();
            await Task.Run(() =>
            {
                int triesCount = 0;
                bool connected = false;
                while (!connected && triesCount < 3)
                {
                    try
                    {
                        var Products = dataLoader.LoadProducts();
                        connected = true;
                    }
                    catch (Exception)
                    {
                        triesCount++;
                    }
                }
                if(triesCount >= 3)
                {
                    throw new Exception("Превышено время ожидания подключения к базе данных!");
                }
            });
            Gui.StopLoading();
        }

        public async void ShowProducts()
        {
            Gui.Clear();
            await Task.Run(() =>
            {
                var Products = dataLoader.LoadProducts();
                var productCategories = new ProductCategoryList(Products);
                Items = productCategories.Items;
            });
            Gui.ShowProducts(Items);
        }

        public async void ShowProductsOrder()
        {
            Gui.Clear();
            await Task.Run(() =>
            {
                var Products = dataLoader.LoadProductsInOrder();
                var productCategories = new ProductCategoryList(Products);
                Items = productCategories.Items;
            });
            Gui.ShowProducts(Items);
        }

        public async void ShowCategories()
        {
            Gui.Clear();
            await Task.Run(() =>
            {
                var Products = dataLoader.LoadProducts();
                var Categories = dataLoader.LoadCategories();
                var productCategories = new ProductCategoryList(Products, Categories);
                Items = productCategories.Items;
            });
            Gui.ShowCategories(Items);
        }
    }
}
