using System.Collections.Generic;
using System.Net;
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
        }
    }
}
