using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models.AutomobilesDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarShowroom.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AutomobilesController : ControllerBase
    {
        private const int maxAutomobilesPageSize = 50;
        private readonly IAutomobileService _automobileService;
        private readonly IMapper _mapper;

        public AutomobilesController(IAutomobileService automobileService, IMapper mapper)
        {
            _automobileService = automobileService ?? throw new ArgumentNullException(nameof(automobileService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("api/Automobiles")]
        public async Task<ActionResult<IEnumerable<AutomobileDTO>>> GetAutomobiles(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxAutomobilesPageSize)
            {
                pageSize = maxAutomobilesPageSize;
            }

            var (Automobiles, paginationMetadata) = await _automobileService.GetAutomobilesAsync(pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<AutomobileDTO>>(Automobiles));
        }


    }
}
