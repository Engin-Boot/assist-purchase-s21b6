using System.Collections.Generic;
using ProductInfoApi.Models;

namespace ProductInfoApi.Repository
{
    public class DictionaryProducts
    {
        public Dictionary<string, ProductData> DictionaryOfProducts { get; private set; }

        public  DictionaryProducts()
        {
            var filePath = ProductsProvider.GetDbPath();
            var obj = new ProductsProvider(filePath);
            DictionaryOfProducts = obj.GetAllProductsFromDb();
        }
    }
}
