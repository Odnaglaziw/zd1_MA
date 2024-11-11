using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string GetInfo()
        {
            return $"Наименование: {Name}; Цена: {Price} руб.";
        }
        public override int GetHashCode()
        {
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashPrice = Price.GetHashCode();
            return hashName ^ hashPrice;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var otherProduct = (Product)obj;
            return Name == otherProduct.Name && Price == otherProduct.Price;
        }
    }
}
