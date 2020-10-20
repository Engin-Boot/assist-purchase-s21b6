using System.Collections.Generic;
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
        }

        [Fact]
        public void WhenTouchScreenFilterIsAppliedReturnObject()
        {
            Init();
            _request = new RestRequest("Products/Touchscreen", Method.GET) {RequestFormat = DataFormat.Json};
            //_request.AddQueryParameter("");
            var response = Client.Execute(_request);

            //var result = Deserializer.Deserialize<>(IEnumerable<>)
        }
       
        
    }
}
