using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.EngineDTOs;
using CarShowroom.Dal.Entities;
using CarShowroom.Dal.Enums;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarShowroom.API.Controllers
{
    /// <summary>
    /// Controller to work with engine entity
    /// </summary>
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class EnginesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IEnginesService _enginesService;
        private readonly IMapper _mapper;
        const int maxEnginesPageSize = 50;

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="companiesService">Company service</param>
        /// <param name="enginesService">Engine service</param>
        /// <param name="mapper">Auto Mapper</param>
        /// <exception cref="ArgumentNullException">If parameter is null</exception>
        public EnginesController(ICompaniesService companiesService, IEnginesService enginesService, IMapper mapper)
        {
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
            _enginesService = enginesService ?? throw new ArgumentNullException(nameof(enginesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Receive collection of engines which are in the same company
        /// </summary>
        /// <param name="companyName">Name of the company</param>
        /// <returns>Collection of engines</returns>
        /// <response code="200">Returned collection of engines</response>
        /// <response code="404">Haven't found company</response>
        [HttpGet("api/Companies/{companyName}/Engines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EngineWithoutCompanyDTO>>> GetEnginesFromCompany(string companyName)
        {
            if (!await _companiesService.IsExistCompanyAsync(companyName))
            {
                return NotFound();
            }

            var engines = await _enginesService.GetEnginesForCompanyAsync(companyName);

            return Ok(_mapper.Map<IEnumerable<EngineWithoutCompanyDTO>>(engines));
        }

        /// <summary>
        /// Receive engine 
        /// </summary>
        /// <param name="companyName">Name of company</param>
        /// <param name="engineId">Id of engine</param>
        /// <returns>Engine which has this Id</returns>
        /// <response code="200">Returned engine</response>
        /// <response code="404">Haven't found company or engine</response>
        [HttpGet("api/Companies/{companyName}/Engines/{engineId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EngineWithoutCompanyDTO>> GetEngineFromCompany(string companyName, int engineId)
        {
            if (!await _companiesService.IsExistCompanyAsync(companyName))
            {
                return NotFound();
            }

            var engine = await _enginesService.GetEngineForCompanyAsync(engineId, companyName);

            if (engine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EngineWithoutCompanyDTO>(engine));
        }

        /// <summary>
        /// Receive collection of engines
        /// </summary>
        /// <param name="pageNumber">Number of page which we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <param name="orderEngine">Enum property by what order collection.<br/>
        /// Posible variants: Name, EngineCapacity, Power, FuelType</param>
        /// <returns>Collection of engines</returns>
        /// <response code="200">Returned collection of engines</response>
        [HttpGet("api/Engines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EngineDTO>>> GetEngines(int pageNumber = 1, int pageSize = 10, OrderEngineBy? orderEngine = null)
        {
            if (pageSize > maxEnginesPageSize)
            {
                pageSize = maxEnginesPageSize;
            }
            var (engines, paginationMetadata) = await _enginesService.GetEnginesAsync(pageNumber, pageSize, orderEngine);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<EngineDTO>>(engines));
        }

        /// <summary>
        /// Receive engine
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <returns>Engine which has this Id</returns>
        /// <response code="200">Returned engine</response>
        /// <response code="404">Haven't found engine</response>
        [HttpGet("api/Engines/{engineId}", Name = "GetEngine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EngineDTO>> GetEngine(int engineId)
        {
            var engine = await _enginesService.GetEngineAsync(engineId);

            if (engine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EngineDTO>(engine));
        }

        /// <summary>
        /// Add an engine to data base
        /// </summary>
        /// <param name="engine">Engine for adding</param>
        /// <returns>Added engine </returns>
        /// <response code="201">Added engine to data base</response>
        [HttpPost("api/Engines")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes("application/json", "application/xml")]
        public async Task<ActionResult<EngineDTO>> CreateEngine(EngineCreationDTO engine)
        {
            /*if (engine.CompanyName != null && !await _companiesService.IsExistCompanyAsync(engine.CompanyName))
            {
                return NotFound();
            }*/
            var finalEngine = _mapper.Map<Engine>(engine);

            await _enginesService.AddEngineAsync(finalEngine);

            await _enginesService.SaveChangesAsync();

            var createdEngineToReturn = _mapper.Map<EngineDTO>(finalEngine);

            return CreatedAtRoute("GetEngine", new { engineId = createdEngineToReturn.Id }, createdEngineToReturn);
        }

        /// <summary>
        /// Delete engine from data base
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Deleted engine from data base</response>
        /// <response code="404">Haven't found engine</response>
        [HttpDelete("api/Engines/{engineId}")]
        public async Task<IActionResult> DeleteEngine(int engineId)
        {
            var engineEntity = await _enginesService.GetEngineAsync(engineId);

            if (engineEntity == null)
            {
                return NotFound();
            }

            _enginesService.DeleteEngine(engineEntity);

            await _companiesService.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update of engine
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <param name="patchDocument">The set of operations to apply to the engine</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Updated engine</response>
        /// <response code="404">Haven't found engine</response>
        /// <response code="400">Incorrect entered command for updating</response>
        /// <remarks>
        /// Sample request (this request updates the brand's name)
        /// PATCH /Engines/id
        /// [
        ///     {
        ///         "op": "replace",
        ///         "path": "/name",
        ///         "values": "NewName"
        ///     }
        /// ]
        /// </remarks> 
        [HttpPatch("api/Engines/{engineId}")]
        public async Task<IActionResult> PartiallyUpdateEngine(int engineId, JsonPatchDocument<EngineForUpdateDTO> patchDocument)
        {
            var engineEntity = await _enginesService.GetEngineAsync(engineId);

            if (engineEntity == null)
            {
                return NotFound();
            }

            var engineToPatch = _mapper.Map<EngineForUpdateDTO>(engineEntity);

            patchDocument.ApplyTo(engineToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(engineToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(engineToPatch, engineEntity);

            await _enginesService.SaveChangesAsync();

            return NoContent();
        }
    }
}
