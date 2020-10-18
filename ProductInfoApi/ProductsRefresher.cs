using System.Collections.Generic;
using ProductInfoApi;
using ProductInfoApi.Models;

namespace SQLiteOps
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
