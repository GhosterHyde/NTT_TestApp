using NTT_TestApp.Core;
using NTT_TestApp.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NTT_TestApp.DataWorkers
{
    internal class DataLoader
    {
        private readonly DataContext DataContext = new();

        public List<Product> LoadProducts()
        {
            DataContext.Products.Load();
            return DataContext.Products.Include(product => product.Categories).ToList();
        }
        public List<Product> LoadProductsInOrder()
        {
            DataContext.Products.Load();
            return DataContext.Products.Include(product => product.Categories).OrderBy(product => product.Name).ToList();
        }

        public List<Category> LoadCategories()
        {
            DataContext.Categories.Load();
            return DataContext.Categories.Include(category => category.Products).ToList();
        }
    }
}
