using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using ProductInfoApi.Controllers;
using ProductInfoApi.EmailProvider;
using ProductInfoApi.EmailProviderService;
using ProductInfoApi.Repository;
using RestSharp;
using RestSharp.Deserializers;
using Xunit;

namespace ProductInfoApi.Tests
{
    public class ControllerTests
    {
        private RestClient Client { get; set; }
        private RestRequest _request;
        private JsonDeserializer Deserializer { get; set; }

        private void Init()
        {
           Client = new RestClient("http://localhost:5000/api");
           Deserializer = new JsonDeserializer();
        }

        [Fact]
        public void CheckWhetherAllProductsReturnsAnObject()
        {
            Init();
            _request = new RestRequest("Products/ListOfProductIds", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            var filters = new CharacteristicWiseFilter();
            var filtersController = new ProductsController(filters);
            var result = filtersController.GetAllProductIds();
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenTouchScreenFilterIsAppliedReturnObject()
        {
            Init();
            _request = new RestRequest("Products/Touchscreen/true", Method.GET) {RequestFormat = DataFormat.Json};
            _request.AddQueryParameter("ProductIds","100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.Equal(HttpStatusCode.BadRequest,response.StatusCode);
            var filterController = new ProductsController(new CharacteristicWiseFilter());
            Assert.NotNull(filterController.GetProductsByTouchscreen(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenHandleFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/Handle/true", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);

            var filterController = new ProductsController(new CharacteristicWiseFilter());
            Assert.NotNull(filterController.GetProductsByHandle(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenCeCertificationFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/CECertificate/true", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            var filterContoller = new ProductsController(new CharacteristicWiseFilter());
            Assert.NotNull(filterContoller.GetProductsByCeCertification(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenBatteryFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/Battery/true", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.NotNull(new ProductsController(new CharacteristicWiseFilter()).GetProductsByBatteryAvailability(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenScreenSizeFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/ScreenSize/6", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.NotNull(new ProductsController(new CharacteristicWiseFilter()).GetProductsByScreenSize(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenWeightFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/Weight/6", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.NotNull(new ProductsController(new CharacteristicWiseFilter()).GetProductsByWeight(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenScreenTypeFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/ScreenType/lcd", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.NotNull(new ProductsController(new CharacteristicWiseFilter()).GetProductsByScreenType(true.ToString(), new List<string>()));
        }

        [Fact]
        public void WhenDimensionsFilterIsAppliedReturnObject()
        {
            Init();

            _request = new RestRequest("Products/Dimensions/6/8/10", Method.GET) { RequestFormat = DataFormat.Json };
            _request.AddQueryParameter("ProductIds", "100");
            var response = Client.Execute(_request);
            var resultList = Deserializer.Deserialize<List<object>>(response);
            Assert.NotNull(resultList);
            Assert.NotNull(new ProductsController(new CharacteristicWiseFilter()).GetProductsByDimensions("10" , "20" , "30" , new List<string>()));
        }

        [Fact]
        public void WhenRequestForSelectedProductsReturnObject()
        {
            Assert.NotNull(new ProductsController(new CharacteristicWiseFilter()).GetSelectedProducts(new List<string>(){"100"}));
        }

        [Fact]
        public void WhenValidEmailFormatIsPassedWithoutNetworkAuthenticationThrowError()
        {
            Assert.Throws<SmtpException>(() =>
                new NotifyProductInterestsController(new EmailNotifier()).Get(new EmailFormat("abcd", "12334", "hejkjka@gmail.com", "Ventilator")));
        }
    }
}
