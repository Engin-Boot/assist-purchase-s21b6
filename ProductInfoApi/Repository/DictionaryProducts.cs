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
            
            /*DictionaryOfProducts.Add("abc1", new ProductData
            {
                ProductId = "abc1",
                ModelNumber = "a",
                ProductName = "a",
                ScreenSize = 0,
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

            DictionaryOfProducts.Add("abc2", new ProductData
            {
                ProductId = "abc2",
                ModelNumber = "b",
                ProductName = "b",
                ScreenSize = 0,
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

            DictionaryOfProducts.Add("abc3", new ProductData
                {
                    ProductId = "abc3",
                    ModelNumber = "a",
                    ProductName = "a",
                    ScreenSize = 0,
                    Weight = 0,
                    HasBattery = false,
                    HasHandle = false,
                    IsCeCertified = false,
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

            DictionaryOfProducts.Add("abc4", new ProductData
                {
                    ProductId = "abc4",
                    ModelNumber = "a",
                    ProductName = "a",
                    ScreenSize = 0,
                    Weight = 0,
                    HasBattery = false,
                    HasHandle = false,
                    IsCeCertified = false,
                    IsTouchScreen = true,
                    ScreenType = "LCD",
                    Dimension = new Dimensions
                    {
                        
                        Length = 8,
                        Width = 10,
                        Height = 12
                    }
                }
            );*/
        }
    }
}
