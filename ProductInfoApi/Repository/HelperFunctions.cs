using System;
using System.Collections.Generic;
using System.Linq;
using ProductInfoApi.Models;


namespace ProductInfoApi.Repository
{
    public class HelperFunctions
    {
        public static List<double> DimensionsInDouble(List<string> dimensions)
        {
            var dimensionsInDouble = new List<double>();
            foreach (var dimension in dimensions)
            {
                if (!double.TryParse(dimension, out var value))
                {
                    return null;
                }
                dimensionsInDouble.Add(value);
            }
            return dimensionsInDouble;
        }

        public static IEnumerable<KeyValuePair<string, ProductData>> SubsetOfDictionary(
            IEnumerable<object> productIdsListByUser,
            IEnumerable<KeyValuePair<string, ProductData>> dictionaryOfProducts)
        {
            var keyValuePairs = dictionaryOfProducts.ToList();
            if (keyValuePairs.Any())
                return keyValuePairs.Where
                    (r => productIdsListByUser.Contains(r.Key));
            return null;
        }

        public static bool IsInputEmptyOrNull(List<string> productListByUser)
        {
            return productListByUser.Count == 0 || productListByUser[0] == "" && productListByUser.Count == 1;
        }

        public static IEnumerable<object> ProductsWithSimilarDimensions(List<double> dimensionsInDouble,
            IEnumerable<KeyValuePair<string, ProductData>> results)
        {
            var listOfProductIds = from product in results
                                   where Math.Abs(product.Value.Dimension.Length - dimensionsInDouble[0]) < 2
                                         && Math.Abs(product.Value.Dimension.Width - dimensionsInDouble[1]) < 2
                                         && Math.Abs(product.Value.Dimension.Height - dimensionsInDouble[2]) < 2
                                   select product.Key;

            return listOfProductIds;
        }

    }
}

