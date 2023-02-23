using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models.AutomobilesDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarShowroom.API.Controllers
{
    /// <summary>
    /// Controllers to work with automobile entity
    /// </summary>
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class AutomobilesController : ControllerBase
    {
        private const int maxAutomobilesPageSize = 50;
        private readonly IAutomobilesService _automobileService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of controller 
        /// </summary>
        /// <param name="automobileService">Service for working with data base</param>
        /// <param name="mapper">Auto mapper</param>
        /// <exception cref="ArgumentNullException">If parameters is null</exception>
        public AutomobilesController(IAutomobilesService automobileService, IMapper mapper)
        {
            _automobileService = automobileService ?? throw new ArgumentNullException(nameof(automobileService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Receive collection of automobiles
        /// </summary>
        /// <param name="pageNumber">Number of page which we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of automobiles</returns>
        /// <response code="200">Returned collection of automobiles</response>
        [HttpGet("api/Automobiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
