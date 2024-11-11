using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Shop
    {
        private Dictionary<Product, int> products;
        private decimal profit;

        public Shop()
        {
            products = new Dictionary<Product, int>();
            profit = 0;
        }

        public void CreateProduct(string name, decimal price, int count)
        {
            Product product = new Product(name, price);
            if (products.ContainsKey(product)) products[product] += count;
            else products[product] = count;

        }

        public Product FindByName(string name)
        {
            return products.Keys.FirstOrDefault(p => p.Name == name);
        }

        public void Sell(Product product, int count)
        {
            if (products.ContainsKey(product) && products[product]-count >= 0)
            {
                products[product]-=count;
                profit += (int)product.Price*count;
                if (products[product] == 0) products.Remove(product);
            }
        }

        public Dictionary<Product, int> GetProducts()
        {
            return products;
        }

        public decimal Profit => profit;
    }
}
