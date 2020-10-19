using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductInfoApi.Models;
using ProductInfoApi.Repository;

namespace ProductInfoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICharacteristicWiseFilter _repo;

        public ProductsController(ICharacteristicWiseFilter repo)
        {
            this._repo = repo;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<KeyValuePair<string, ProductData>>> Get()
        {
            return this._repo.GetAllProducts();
        }

        // GET api/values/ListOfProductIds/
        [HttpGet("ListOfProductIds/")]
        public IEnumerable<object> GetAllProductIds()
        {
            return this._repo.GetAllProductIds();
        }

        // GET api/values/Touchscreen/true
        [HttpGet("Touchscreen/{input}")]
        public IEnumerable<object> GetProductsByTouchscreen(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByTouchscreen(value, input);
        }

        // GET api/values/Handle/true
        [HttpGet("Handle/{input}")]
        public IEnumerable<object> GetProductsByHandle(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByHandle(value, input);
        }

        // GET api/values/CECertificate/true
        [HttpGet("CECertificate/{input}")]
        public IEnumerable<object> GetProductsByCeCertification(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByCeCertification(value, input);
        }

        // GET api/values/Battery/true
        [HttpGet("Battery/{input}")]
        public IEnumerable<object> GetProductsByBatteryAvailability(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByBatteryAvailability(value, input);
        }

        // GET api/values/ScreenSize/12
        [HttpGet("ScreenSize/{input}")]
        public IEnumerable<object> GetProductsByScreenSize(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByScreenSize(value, input);
        }

        // GET api/values/Weight/12
        [HttpGet("Weight/{input}")]
        public IEnumerable<object> GetProductsByWeight(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByWeight(value, input);
        }

        // GET api/values/ScreenType/led
        [HttpGet("ScreenType/{input}")]
        public IEnumerable<object> GetProductsByScreenType(string input, [FromBody] List<string> value)
        {
            return this._repo.FilterByScreenType(value, input);
        }

        // GET api/values/Dimensions/12/21/15
        [HttpGet("Dimensions/{length}/{width}/{height}")]
        public IEnumerable<object> GetProductsByDimensions(
            string length,string width,string height, [FromBody] List<string> value)
        {
            return this._repo.FilterByDimensions(value, length,width,height);
        }

        // GET api/values/SelectedProductDetails/
        [HttpGet("SelectedProductDetails")]
        public IEnumerable<KeyValuePair<string, ProductData>> GetSelectedProducts([FromBody] List<string> value)
        {
            return this._repo.GetSelectedProductDetails(value);
        }
    }
}
