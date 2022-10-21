using System.Collections.Generic;

namespace NTT_TestApp.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}