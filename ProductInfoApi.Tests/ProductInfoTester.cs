using System.Collections.Generic;
using System.Linq;
using System.Net;
using ProductInfoApi.Models;
using ProductInfoApi.Repository;
using Xunit;

namespace ProductInfoApi.Tests
{
    public class ProductInfoTester
    {
        private readonly CharacteristicWiseFilter _filter = new CharacteristicWiseFilter();
        public ProductInfoTester()
        {

            var dictOfProducts = _filter.DictionaryOfProducts;
            dictOfProducts.Clear();
            dictOfProducts.Add("abc1", new ProductData
            {
                ProductId = "abc1",
                ModelNumber = "a",
                ProductName = "a",
                ScreenSize = 10,
                Weight = 0,
                HasBattery = true,
                HasHandle = true,
                IsCeCertified = true,
                IsTouchScreen = true,
                ScreenType = "LED",
                Dimension = new Dimensions
                {
                    Length = 0,
                    Width = 0,
                    Height = 0
                }
            }
            );

            dictOfProducts.Add("abc2", new ProductData
            {
                ProductId = "abc2",
                ModelNumber = "b",
                ProductName = "b",
                ScreenSize = 8,
                Weight = 0,
                HasBattery = true,
                HasHandle = true,
                IsCeCertified = true,
                IsTouchScreen = false,
                ScreenType = "LED",
                Dimension = new Dimensions
                {
                    Length = 0,
                    Width = 0,
                    Height = 0
                }

            });

            dictOfProducts.Add("abc3", new ProductData
            {
                ProductId = "abc3",
                ModelNumber = "a",
                ProductName = "a",
                ScreenSize = 0,
                Weight = 6,
                HasBattery = false,
                HasHandle = false,
                IsCeCertified = false,
                IsTouchScreen = false,
                ScreenType = "LED",
                Dimension = new Dimensions
                {
                    Length = 0,
                    Width = 0,
                    Height = 0
                }
            }
            );

            dictOfProducts.Add("abc4", new ProductData
            {
                ProductId = "abc4",
                ModelNumber = "a",
                ProductName = "a",
                ScreenSize = 0,
                Weight = 5,
                HasBattery = false,
                HasHandle = false,
                IsCeCertified = false,
                IsTouchScreen = false,
                ScreenType = "LCD",
                Dimension = new Dimensions
                {

                    Length = 8,
                    Width = 10,
                    Height = 12
                }
            }
            );
        }

        #region DictionaryInitializationTests

        [Fact]
        public void WhenObjectOfCharacteristicWiseFilterIsCreatedItInitialisesDictoinaryOfProducts()
        {
            Assert.True(_filter.DictionaryOfProducts.Count == 4);
        }

        #endregion

        #region AllProductsRetrievalTests

        [Fact]
        public void WhenGetAllProductsThenReturnDictionaryOfProducts()
        {
            Assert.True(_filter.GetAllProducts().Count > 0);
            Assert.True(_filter.GetAllProducts().Count == 4);
            Assert.Equal("abc1", _filter.GetAllProducts().Keys.ElementAt(0));
            var diction = _filter.GetAllProducts();
            Assert.NotNull(diction);
        }

        [Fact]
        public void WhenGetAllProductIdsIsCalledThenAllProductIdsInTheProductDictionaryAreReturned()
        {
            Assert.Equal(_filter.GetAllProductIds(), _filter.GetAllProducts().Keys);
            Assert.Equal("abc1", _filter.GetAllProductIds().ElementAt(0));
        }

        #endregion

        #region TouchScreenFilterTests

        [Fact]
        public void WhenTouchscreenFeatureIsRequiredByClientThenReturnThoseProductsIdsWithIsTouchscreenTrue()
        {
            var checkTouchScreenProducts = new List<string>() { "abc1", "abc2" };
            Assert.Equal(new List<string>() { "abc1" },
                _filter.FilterByTouchscreen(checkTouchScreenProducts, "true"));
        }

        [Fact]
        public void WhenTouchscreenFeatureIsRequiredByClientThenReturnNothingIfProductsIdsWithIsTouchscreenTrueNotThere()
        {
            var checkTouchScreenProducts = new List<string>() { "abc2", "abc3" };
            Assert.Empty(_filter.FilterByTouchscreen(checkTouchScreenProducts, "true"));
        }

        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToTouchscreenFilterThenSendBackBadRequestStatusCode()
        {
            var checkTouchScreenProducts = new List<string>() { "" };
            var output = _filter.FilterByTouchscreen(checkTouchScreenProducts, "true");
            Assert.Equal(HttpStatusCode.BadRequest, output.ElementAt(0));
        }
        [Fact]
        public void WhenInvalidInputResourceIsPassedToTouchscreenFilterThenSendBackBadRequestStatusCode()
        {
            var checkTouchScreenProducts = new List<string>() { "abc1" };
            var output = _filter.FilterByTouchscreen(checkTouchScreenProducts, "rue");
            Assert.Equal(HttpStatusCode.BadRequest, output.ElementAt(0));
        }

        #endregion

        #region HandleFilterTests

        [Fact]
        public void WhenHandleIsRequiredByClientThenReturnProductIdsFromPassedListThatContainsHandle()
        {
            var checkHandleProducts = new List<string>() { "abc1", "abc2" };
            Assert.Equal(new List<string>() { "abc1", "abc2" },
                _filter.FilterByHandle(checkHandleProducts, "true"));
        }
        [Fact]
        public void WhenHandleFeatureIsRequiredByClientThenReturnNothingIfPassedProductsHaveNoHandle()
        {
            var checkHandleProducts = new List<string>() { "abc3", "abc4" };
            Assert.Empty(_filter.FilterByHandle(checkHandleProducts, "true"));
        }

        [Fact]
        public void HandleCheckingBool()
        {
            var checkHandleProducts = new List<string>() { "abc3" };
            var output = _filter.FilterByHandle(checkHandleProducts, "rue");
            Assert.Equal(HttpStatusCode.BadRequest, output.ElementAt(0));
        }
        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToHandleFilterThenSendBackBadRequestStatusCode()
        {
            var checkHandleProducts = new List<string>() { "" };
            var output = _filter.FilterByHandle(checkHandleProducts, "true");
            Assert.Equal(HttpStatusCode.BadRequest, output.ElementAt(0));
        }

        #endregion

        #region CeCertificationFilterTests

        [Fact]
        public void WhenCeCertificationFeatureIsRequiredByClientThenReturnProductsHavingCeCertification()
        {
            var checkCeProducts = new List<string>() { "abc1", "abc2" };
            Assert.Equal(new List<string>() { "abc1", "abc2" },
                _filter.FilterByCeCertification(checkCeProducts, "true"));
        }
        [Fact]
        public void WhenCeCertificationFeatureIsRequiredByClientThenReturnNothingIfPassedProductsHaveNoCeCertification()
        {
            var checkCeProducts = new List<string>() { "abc3", "abc4" };
            Assert.Empty(_filter.FilterByCeCertification(checkCeProducts, "true"));
        }
        [Fact]
        public void CeCertificationBoolCheck()
        {
            var checkCeProducts = new List<string>() { "abc3", "abc4" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByCeCertification(checkCeProducts, "tru").ElementAt(0));
        }
        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedCeCertificationFilterThenSendBackBadRequestStatusCode()
        {
            var checkCeProducts = new List<string>() { "" };
            Assert.Equal(HttpStatusCode.BadRequest,_filter.FilterByCeCertification(checkCeProducts, "true").ElementAt(0));
        }


        #endregion

        #region BatteryFilterTests

        [Fact]
        public void WhenBatteryFeatureIsRequiredByClientThenReturnProductsThatHaveBattery()
        {
            var checkBatteryProducts = new List<string>() { "abc1", "abc2", "abc3" };
            Assert.Equal(new List<string>() { "abc1", "abc2" },
                _filter.FilterByBatteryAvailability(checkBatteryProducts, "true"));
        }
        [Fact]
        public void WhenBatteryFeatureIsRequiredByClientThenReturnNothingIfPassedProductsHaveNoBattery()
        {
            var checkBatteryProducts = new List<string>() { "abc3", "abc4" };
            Assert.Empty(_filter.FilterByBatteryAvailability(checkBatteryProducts, "true"));
        }
        [Fact]
        public void BatteryBoolCheck()
        {
            var checkBattery = new List<string>() { "abc1" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByBatteryAvailability(checkBattery, "tru").ElementAt(0));
        }
        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToBatteryFilterThenSendBackBadRequestStatusCode()
        {
            var checkBattery = new List<string>() { "" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByBatteryAvailability(checkBattery, "true").ElementAt(0));
        }


        #endregion

        #region ScreenSizeFilterTests

        [Fact]
        public void WhenParticularScreenSizeIsRequiredByClientThenReturnNothingIfPassedProductsNotHaveSameScreenSize()
        {
            var check = new List<string>() { "abc1", "abc2", "abc3" };
            Assert.Equal(new List<string>() { "abc1", "abc2" },
                _filter.FilterByScreenSize(check, "9"));
        }
        [Fact]
        public void WhenParticularScreenSizeIsRequiredByClientThenReturnProductsHavingSimilarScreenSize()
        {
            var check = new List<string>() { "abc3", "abc4" };
            Assert.Empty(_filter.FilterByScreenSize(check, "9"));
        }
        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToScreenSizeFilterThenSendBackBadRequestStatusCode()
        {
            var check = new List<string>() { "" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByScreenSize(check, "true").ElementAt(0));
        }
        [Fact]
        public void ScreenSizeDoubleCheck()
        {
            var check = new List<string>() { "abc1" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByScreenSize(check, "true").ElementAt(0));
        }

        #endregion

        #region WeightFiterTests

        [Fact]
        public void WhenSpecificWeightIsRequiredByClientThenReturnProductsThatHaveSimilarWeight()
        {
            var checkBatteryProducts = new List<string>() { "abc1", "abc2", "abc3" };
            Assert.Equal(new List<string>() { "abc3" },
                _filter.FilterByWeight(checkBatteryProducts, "9"));
        }
        [Fact]
        public void WhenSpecificWeightIsRequiredByClientThenReturnNothingIfPassedProductsNotHaveSimilarWeight()
        {
            var checkBatteryProducts = new List<string>() { "abc1", "abc2" };
            Assert.Empty(_filter.FilterByWeight(checkBatteryProducts, "9"));
        }
        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToWeightFilterThenSendBackBadRequestStatusCode()
        {
            var checkWeight = new List<string>() { "" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByWeight(checkWeight, "9").ElementAt(0));
        }
        [Fact]
        public void WeightIsDoubleCheck()
        {
            var checkWeight = new List<string>() { "abc1" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByWeight(checkWeight, "true").ElementAt(0));
        }

        #endregion

        #region ScreenType

        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToScreenTypeFilterThenSendBackBadRequestStatusCode()
        {
            var checkScreenType = new List<string>() { "" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByScreenType(checkScreenType, "9").ElementAt(0));
        }

        [Fact]
        public void WhenWrongScreenTypeIsPassedThenReturnBadRequest()
        {
            var checkScreenType = new List<string>() { "abc1" };
            var output = _filter.FilterByScreenType(checkScreenType, "lued");
            Assert.Equal(HttpStatusCode.BadRequest, output.ElementAt(0));
        }


        [Fact]
        public void WhenSpecificRequiredScreenTypeIsAvailableInPassedProductsThenReturnThoseProductsBack()
        {
            var checkScreenType = new List<string>() { "abc1", "abc2", "abc3", "abc4" };
            Assert.Equal(new List<string>() { "abc4" },
                _filter.FilterByScreenType(checkScreenType, "lcd"));
        }
        [Fact]
        public void WhenParticularScreenTypeIsNotAvailableInTheProvidedProductsThenReturnEmptyList()
        {
            var checkScreenType = new List<string>() { "abc3", "abc2" };
            Assert.Empty(_filter.FilterByScreenType(checkScreenType, "Lcd"));
        }

        #endregion

        #region DimensionsFilterTests

        [Fact]
        public void WhenEmptyInputListOfProductIdsIsPassedToDimensionFilterThenSendBackBadRequestStatusCode()
        {
            var inputList = new List<string>() { "" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByDimensions(
                inputList, "6.1", "9.1", "11.1").ElementAt(0));
        }

        [Fact]
        public void DimensionPidMatches()
        {
            var inputList = new List<string>() { "abc3", "abc4" };
            Assert.Equal(new List<string>() { "abc4" }, _filter.FilterByDimensions(
                inputList, "6.1", "9.1", "11.1"));

        }

        //[Fact]
        //public void DimensionNoPidMatches()
        //{
        //    var inputList = new List<string>() { "" };
        //    Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByDimensions(
        //        inputList, "6.1", "9.1", "11.1").ElementAt(0));
        //}
        [Fact]
        public void DimensionWrongInput()
        {
            var inputList = new List<string>() { "abc4" };
            Assert.Equal(HttpStatusCode.BadRequest, _filter.FilterByDimensions(
                inputList, "6.1", "abc", "11.1").ElementAt(0));
        }


        #endregion

        #region GetSelectedProductDetailsTests

        [Fact]
        public void GetSelectedProductDetailsNoInput()
        {
            var inputList = new List<string>() { "" };
            Assert.Null(_filter.GetSelectedProductDetails(inputList));
        }

        [Fact]
        public void GetSelectedProductDetailsRightInput()
        {
            var inputList = new List<string>() { "abc1" };
            Assert.Equal("abc1", _filter.GetSelectedProductDetails(inputList).ElementAt(0).Key);
        }

        #endregion

        #region HelperFunctionTests

        [Fact]
        public void WhenSubsetOfDictionaryPassingNullThenReturnNull()
        {
            Assert.Null(HelperFunctions.SubsetOfDictionary(new List<object>() { "abc1" }, new List<KeyValuePair<string, ProductData>>()));
            Assert.Empty(HelperFunctions.SubsetOfDictionary(new List<object>() { "" }, _filter.DictionaryOfProducts));
        }
        [Fact]
        public void WhenSubsetOfDictionaryPassingValuesThenReturnSubsetDictionaryWithSameProductIds()
        {
            Assert.NotNull(HelperFunctions.SubsetOfDictionary(new List<object>() { "abc1" }, _filter.DictionaryOfProducts));
            Assert.NotEmpty(HelperFunctions.SubsetOfDictionary(new List<object>() { "abc1" }, _filter.DictionaryOfProducts));
            Assert.Equal("abc1", HelperFunctions.SubsetOfDictionary(new List<object>() { "abc1" }, _filter.DictionaryOfProducts).ElementAt(0).Key);
        }
        [Fact]
        public void IsNullOrEmptyTesting()
        {
            Assert.True(HelperFunctions.IsInputEmptyOrNull(new List<string>()));
            Assert.True(HelperFunctions.IsInputEmptyOrNull(new List<string>() { "" }));
            Assert.False(HelperFunctions.IsInputEmptyOrNull(new List<string>() { "abc1" }));

        }
        #endregion

        #region ProductDataRemainingPropertyTests

        [Fact]
        public void ModelNumberInitializeTest()
        {
            var abc = new ProductData {ModelNumber = "1234Abc"};
            Assert.Equal("1234Abc",abc.ModelNumber);

        }
        [Fact]
        public void ProductNameInitializeTest()
        {
            var abc = new ProductData { ProductName = "Intellect" };
            Assert.Equal("Intellect", abc.ProductName);

        }

        #endregion
    }
}
