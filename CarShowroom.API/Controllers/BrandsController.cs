using CarShowroom.Bll.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShowroom.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        [HttpGet("api/Brands")]
        public async Task<IActionResult> GetBrands()
        {

        }
        //[HttpGet("api/Companies/{companyName}/Brands")]

    }
}
