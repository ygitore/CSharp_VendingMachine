using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending
{
    public class VendingMachine
    {
        private List<Product> _products = new List<Product>();

        public VendingMachine()
        {
            _products.Add(new Product() { Id = 1, Name = "Snickers", Price = .75 });
            _products.Add(new Product() { Id = 2, Name = "Pepsi", Price = 1.25 });
            _products.Add(new Product() { Id = 3, Name = "Diamond Ring", Price = 2_400 });
            _products.Add(new Product() { Id = 4, Name = "Tesla", Price = 85_000 });
            _products.Add(new Product() { Id = 5, Name = "Hot Pocket", Price = 1.50 });
        }

        // Add a new product to the Vending Machine (For stocking machine)
        public void AddProduct(Product newProduct)
        {
            _products.Add(newProduct);
        }

        // Remove a product from the Vending Machine (for purchasing a product)
        public void RemoveProduct(Product productToRemove)
        {
            _products.Remove(productToRemove);
        }

        // Get all products ordered by price (lowest on top)
        public List<Product> GetAll()
        {
            IEnumerable<Product> product = _products.OrderBy(prod => prod.Price);
            return product.ToList();
        }

        // Find a product by name. Results should be ordered by name)
        public List<Product> SearchByName(string nameCriteria)
        {
            List<Product> productName = _products.Where(n => n.Name == nameCriteria).ToList();
            var name = productName.OrderBy(n => n.Name);
            return name.ToList();
        }                                                                                

        // Find a product between a range or prices. Results should be ordered by price
        public List<Product> SearchByPrice(double minPrice, double maxPrice)
        {
            IEnumerable<Product> prodPrice = from prod in _products
                                             where prod.Price > 2000 && prod.Price < 9000
                                             orderby prod.Price
                                             select prod;
            return prodPrice.ToList();
        }

        // Return a product with a given ID. Return null if not found.
        public Product GetById(int id)
        {
                Product productById = _products.Find(prodId => prodId.Id == id);
                return productById;
            
        }

        // Return the cheapest product or null if there are no products
        public Product GetCheapest()
        {
            double minPrice = _products.Min(cheapestProd => cheapestProd.Price);
            Product cheapestProduct = _products.Find(cheapestProd => cheapestProd.Price == minPrice);
            return cheapestProduct;
        }

        // Return the most expensive product or null if there are no products
        public Product GetMostExpensive()
        {
             double minPrice = _products.Max(expensiveProd => expensiveProd.Price);
            Product expensiveProduct = _products.Find(expensiveProd => expensiveProd.Price == minPrice);
            return expensiveProduct;
        }

        // Return all the product names in alphabetical ordere
        public List<string> GetProductNames()
        {
            IEnumerable<string> productName = from product in _products
                                              orderby product.Name ascending
                                              select product.Name;
            return productName.ToList();
        }

        // Property to represent the total of all the products' prices.
        public double TotalValue
        {
            get
            {
                return _products.Sum(prodPrice => prodPrice.Price);
            }
        }
    }
}
