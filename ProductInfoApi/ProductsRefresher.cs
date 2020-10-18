using System.Collections.Generic;
using ProductInfoApi.Models;

namespace ProductInfoApi
{
    public class ProductsRefresher
    {
        public Dictionary<string, ProductData> RefreshProducts()
        {
            var filePath = ProductsProvider.GetDbPath();
            var products = new ProductsProvider(filePath);
            return products.GetAllProductsFromDb();
        }
    }
}
