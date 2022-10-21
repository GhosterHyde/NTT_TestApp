using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NTT_TestApp.Model
{
    internal class ProductCategoryList : List<ProductCategory>
    {
        public ObservableCollection<ProductCategory> Items = new();

        public ProductCategoryList(List<Product> Products)
        {
            foreach (var product in Products)
            {
                if (product.Categories.Any())
                {
                    foreach (var category in product.Categories)
                    {
                        AddProductCategory(product.Name, category.Name);
                    }
                }
                else
                {
                    AddProductCategory(product.Name, "-");
                }
            }
        }
        public ProductCategoryList(List<Product> Products, List<Category> Categories)
        {
            foreach (var category in Categories)
            {
                if (category.Products.Any())
                {
                    foreach (var product in category.Products)
                    {
                        AddProductCategory(product.Name, category.Name);
                    }
                }
                else
                {
                    AddProductCategory("-", category.Name);
                }
            }
            var LeftProducts = Products.Where(product => product.Categories.Count == 0);
            foreach (var product in LeftProducts)
            {
                AddProductCategory(product.Name, "Без категории");
            }
        }

        private void AddProductCategory(string productName, string categoryName)
        {
            var item = new ProductCategory
            {
                ProductName = productName,
                CategoryName = categoryName
            };
            Items.Add(item);
        }
    }
}
