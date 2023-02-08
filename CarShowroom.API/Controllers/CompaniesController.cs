using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using CarShowroom.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarShowroom.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IMapper _mapper;

        const int maxCitiesPageSize = 50;

        public CompaniesController(ICompaniesService companiesService, IMapper mapper)
        {
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }
            var (Companies, paginationMetadata) = await _companiesService.GetCompaniesAsync(pageNumber, pageSize);
            if (Companies == null || Companies.Count() == 0)
            {
                return NoContent();
            }

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CompanyWithoutCollectionsDTO>>(Companies));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCompany(string name, bool includeEngines = false, bool includeBrands = false)
        {
            var company = await _companiesService.GetCompanyAsync(name, includeEngines, includeBrands);
            if (company == null)
            {
                return NotFound();
            }

            if (includeEngines == false && includeBrands == true)
            {
                return Ok(_mapper.Map<CompanyWithoutEnginesDTO>(company));
            }
            if (includeEngines == true && includeBrands == false)
            {
                return Ok(_mapper.Map<CompanyWithoutBrandsDTO>(company));
            }
            if (includeEngines == false && includeBrands == false)
            {
                return Ok(_mapper.Map<CompanyWithoutCollectionsDTO>(company));
            }
            //TODO : Change Engine to Engine DTO
            
            return Ok(_mapper.Map<CompanyDTO>(company));
        }
    }
}
