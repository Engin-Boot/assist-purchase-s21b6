using System;
using System.Collections.Generic;
using System.Linq;
using ProductInfoApi.Models;

namespace ProductInfoApi.Repository
{
    public class CharacteristicWiseFilter : ICharacteristicWiseFilter
    {

        private static readonly DictionaryProducts AllProducts = new DictionaryProducts();
        public Dictionary<string, ProductData> DictionaryOfProducts = AllProducts.DictionaryOfProducts;
        public Dictionary<string, ProductData> GetAllProducts()
        {
            return DictionaryOfProducts;
        }

        public IEnumerable<object> GetAllProductIds()
        {
            var listOfProductIds = new List<string>(DictionaryOfProducts.Keys);
            return listOfProductIds;
        }


        public IEnumerable<object> FilterByTouchscreen(
            List<string> productIdsListByUser, string isTouchscreen)
        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            if (!bool.TryParse(isTouchscreen, out var isTouchScreen))
                return ErrorHandler.ParsingBoolError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where product.Value.IsTouchScreen == isTouchScreen
                                   select product.Key;
            return listOfProductIds;

        }



        public IEnumerable<object> FilterByHandle(
            List<string> productIdsListByUser, string hasHandle)

        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            if (!bool.TryParse(hasHandle, out var isHavingHandle))
                return ErrorHandler.ParsingBoolError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where product.Value.HasHandle == isHavingHandle
                                   select product.Key;
            return listOfProductIds;
        }


        public IEnumerable<object> FilterByCeCertification(
            List<string> productIdsListByUser, string hasCeCertificate)

        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            if (!bool.TryParse(hasCeCertificate, out var isHavingCeCertificate))
                return ErrorHandler.ParsingBoolError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where product.Value.IsCeCertified == isHavingCeCertificate
                                   select product.Key;
            return listOfProductIds;
        }

        public IEnumerable<object> FilterByBatteryAvailability(
            List<string> productIdsListByUser, string hasBattery)
        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            if (!bool.TryParse(hasBattery, out var isHavingBattery))
                return ErrorHandler.ParsingBoolError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where product.Value.HasBattery == isHavingBattery
                                   select product.Key;
            return listOfProductIds;
        }


        public IEnumerable<object> FilterByScreenSize(
            List<string> productIdsListByUser, string sizeOfScreen)
        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            if (!double.TryParse(sizeOfScreen, out var screenSize))
                return ErrorHandler.ParsingDoubleError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where Math.Abs(product.Value.ScreenSize - screenSize) < 3
                                   select product.Key;
            return listOfProductIds;
        }

        public IEnumerable<object> FilterByWeight(
            List<string> productIdsListByUser, string weightExpected)

        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            if (!double.TryParse(weightExpected, out var weight))
                return ErrorHandler.ParsingDoubleError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where Math.Abs(product.Value.Weight - weight) < 5
                                   select product.Key;
            return listOfProductIds;
        }

        public static bool IsScreenTypeAvailable(string screenType)
        {
            return screenType == "LCD" || screenType == "LED";
        }

        public IEnumerable<object> FilterByScreenType(
            List<string> productIdsListByUser, string screenTypeExpected)

        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            var screenType = screenTypeExpected.ToUpper();
            if (!IsScreenTypeAvailable(screenType))
                return ErrorHandler.ScreenTypeError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            var listOfProductIds = from product in results
                                   where product.Value.ScreenType == screenTypeExpected.ToUpper()
                                   select product.Key;
            return listOfProductIds;
        }



        public IEnumerable<object> FilterByDimensions(List<string> productIdsListByUser,
            string lengthExpected, string widthExpected, string heightExpected)

        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return ErrorHandler.EmptyInputProductIdList();
            var dimensions = new List<string>() { lengthExpected, widthExpected, heightExpected };
            var dimensionsInDouble = HelperFunctions.DimensionsInDouble(dimensions);
            if (dimensionsInDouble == null)
                return ErrorHandler.ParsingDoubleError();
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            return HelperFunctions.ProductsWithSimilarDimensions(dimensionsInDouble, results);
        }



        public IEnumerable<KeyValuePair<string, ProductData>> GetSelectedProductDetails(List<string> productIdsListByUser)
        {
            if (HelperFunctions.IsInputEmptyOrNull(productIdsListByUser))
                return null;
            var results = HelperFunctions.SubsetOfDictionary(productIdsListByUser,
                DictionaryOfProducts);
            return results;
        }
    }
}

