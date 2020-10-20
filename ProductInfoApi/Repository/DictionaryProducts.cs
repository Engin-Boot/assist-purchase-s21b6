using System.Collections.Generic;
using ProductInfoApi.Models;

namespace ProductInfoApi.Repository
{
    public class DictionaryProducts
    {
        public readonly Dictionary<string, ProductData> DictionaryOfProducts;

        public  DictionaryProducts()
        {
            var filePath = ProductsProvider.GetDbPath();
            var obj = new ProductsProvider(filePath);
            DictionaryOfProducts = obj.GetAllProductsFromDb();
        }
    }
}
