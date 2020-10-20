using Microsoft.AspNetCore.Mvc;
using ProductInfoApi.EmailProviderService;

namespace ProductInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyProductInterestsController : ControllerBase
    {
        private readonly IEmailProvider _repo;

        public NotifyProductInterestsController(IEmailProvider repo)
        {
            this._repo = repo;
        }

        // GET: api/<NotifyProductInterests>
        [HttpGet]
        public object Get([FromBody] EmailFormat email)
        {
            return Ok(_repo.SendCustomerInterestDetailsToMarketingTeam(email));
        }
    }

        //// GET api/<NotifyProductInterests>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

    
}
