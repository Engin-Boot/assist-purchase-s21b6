using System.IO;
using ProductInfoApi;
using Xunit;

namespace DatabaseTester
{
    public class DatabaseTester
    {
        [Fact]
        public void CheckDatabaseFilePath()
        {
            var filePath = ProductsProvider.GetDbPath();
            var fileExistsInPath = File.Exists(filePath);
            Assert.True(fileExistsInPath.Equals(true));
        }

        [Fact]
        public void WhenCorrectDatabaseFilePathPassedCreateProductObject()
        {
            var filePath = ProductsProvider.GetDbPath();
            var productsProvider = new ProductsProvider(filePath);
            Assert.True(!productsProvider.Equals(null));
        }

        [Fact]
        public void WhenCorrectAddressIsPassedThenCreateDbObject()
        {
            var filePath = ProductsProvider.GetDbPath();
            var productsProvider = new ProductsProvider(filePath);
            Assert.False(productsProvider._dbConnection.Equals(null));
        }

        [Fact]
        public void WhenWrongFilePathIsPassedToProductsProviderCtorThrowError()
        {
            var filePath = "jskzjdskjk";
            var products = new ProductsProvider(filePath);
            Assert.True(products._dbConnection == null);
        }
    }
}
