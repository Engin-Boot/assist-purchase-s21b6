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
            Assert.False(productsProvider.DbConnection.Equals(null));
        }

        [Fact]
        public void WhenWrongFilePathIsPassedToProductsProviderCtorReturnsNull()
        {
            var filePath = "jskzjdskjk";
            var products = new ProductsProvider(filePath);
            Assert.True(products.DbConnection == null);
        }

        [Fact]
        public void GetAllProductsFromDatabaseWhenCorrectFilePathIsPassed()
        {
            var filePath = ProductsProvider.GetDbPath();
            var products = new ProductsProvider(filePath);
            var allProducts = products.GetAllProductsFromDb();
            Assert.True(allProducts.Count !=0);
        }

        [Fact]
        public void WhenWrongDatabasePassedThrowFileNotFoundError()
        {
            const string filePath = @"D:\Work\Training\Bootcamp\Products.db";
            var products = new ProductsProvider(filePath);
            Assert.Throws<FileNotFoundException>(() => products.GetAllProductsFromDb());
        }

        [Fact]
        public void DatabaseRefreshTester()
        {
            var products = new ProductsRefresher();
            var refreshedProducts = products.RefreshProducts();
            Assert.True(products !=null);
            Assert.True(refreshedProducts.Count !=0);
        }

    }
}
