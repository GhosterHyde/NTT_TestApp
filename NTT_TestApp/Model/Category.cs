using System.Collections.Generic;

namespace NTT_TestApp.Model
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
