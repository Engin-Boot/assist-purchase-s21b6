using System.Collections.Generic;

namespace SQLiteOps
{
    public class ProductsRefresher
    {
        public Dictionary<string, Description> RefreshProducts()
        {
            var filePath = ProductsProvider.GetDbPath();
            var products = new ProductsProvider(filePath);
            return products.GetAllProductsFromDb();
        }
    }
}
