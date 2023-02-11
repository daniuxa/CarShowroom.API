using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarShowroom.API.Controllers
{
    [Route("api/[controller]")]
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

        //TODO: Change to api/Companies/{companyName}/Engines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EngineDTO>>> GetEnginesFromCompany(string companyName)
        {
            if (!await _companiesService.IsExistCompany(companyName))
            {
                return NotFound();
            }

            var engines = await _enginesService.GetEnginesForCompany(companyName);

            return Ok(_mapper.Map<IEnumerable<EngineDTO>>(engines));
        }
        [HttpGet("{engineId}")]
        public async Task<ActionResult<IEnumerable<EngineDTO>>> GetEngineFromCompany(int engineId)
        {
            var engine = await _enginesService.GetEngine(engineId);

            if (engine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EngineDTO>(engine));
        }

        //TODO: api/Companies/{companyName}/Engines/{engineId}
    }
}
