using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.EngineDTOs;
using CarShowroom.Dal.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CarShowroom.API.Controllers
{
    //[Route("api/Companies/{companyName}/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IEnginesService _enginesService;
        private readonly IMapper _mapper;

        public EnginesController(ICompaniesService companiesService, IEnginesService enginesService, IMapper mapper)
        {
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
            _enginesService = enginesService ?? throw new ArgumentNullException(nameof(enginesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("api/Companies/{companyName}/Engines")]
        public async Task<ActionResult<IEnumerable<EngineWithoutCompanyDTO>>> GetEnginesFromCompany(string companyName)
        {
            if (!await _companiesService.IsExistCompany(companyName))
            {
                return NotFound();
            }

            var engines = await _enginesService.GetEnginesForCompanyAsync(companyName);

            return Ok(_mapper.Map<IEnumerable<EngineWithoutCompanyDTO>>(engines));
        }
        [HttpGet]
        [Route("api/Companies/{companyName}/Engines/{engineId}")]
        public async Task<ActionResult<EngineWithoutCompanyDTO>> GetEngineFromCompany(string companyName, int engineId)
        {
            if (!await _companiesService.IsExistCompany(companyName))
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

        [HttpGet]
        [Route("api/Engines")]
        public async Task<ActionResult<IEnumerable<EngineDTO>>> GetEngines()
        {
            var engines = await _enginesService.GetEnginesAsync();

            return Ok(_mapper.Map<IEnumerable<EngineDTO>>(engines));
        }

        [HttpGet(Name = "GetEngine")]
        [Route("api/Engines/{engineId}")]
        public async Task<ActionResult<EngineDTO>> GetEngine(int engineId)
        {
            var engine = await _enginesService.GetEngineAsync(engineId);

            if (engine == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<EngineDTO>(engine));  
        }

        [HttpPost]
        public async Task<ActionResult<EngineDTO>> CreateEngine(EngineCreationDTO engine)
        {
            var finalEngine = _mapper.Map<Engine>(engine);

            await _enginesService.AddEngine(finalEngine);

            await _enginesService.SaveChangesAsync();

            var createdEngineToReturn = _mapper.Map<EngineDTO>(finalEngine);

            //TODO: Finish return

            return CreatedAtRoute("GetEngine", new {engineId = createdEngineToReturn.});
        }
    }
}
