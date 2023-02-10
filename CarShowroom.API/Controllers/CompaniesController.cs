using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.CompanyDTOs;
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

        [HttpGet("{companyName}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany(string companyName, bool includeEngines = false, bool includeBrands = false)
        {
            var company = await _companiesService.GetCompanyAsync(companyName, includeEngines, includeBrands);
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
            
            return Ok(_mapper.Map<CompanyDTO>(company));
        }

        [HttpPost]
        public async Task<ActionResult<CompanyWithoutCollectionsDTO>> CreateCompany(CompanyCreationDTO company)
        {
            var finalCompany = _mapper.Map<Company>(company);

            await _companiesService.AddCompanyAsync(finalCompany);

            await _companiesService.SaveChangesAsync();

            var companyToReturn = _mapper.Map<CompanyWithoutCollectionsDTO>(finalCompany);

            return CreatedAtRoute("GetCompany", new {name = company.CompanyName}, companyToReturn);
        }

        [HttpDelete("{companyName}")]
        public async Task<IActionResult> DeleteCompany(string companyName)
        {
            var companyEntity = await _companiesService.GetCompanyAsync(companyName);

            if (companyEntity == null)
            {
                return NotFound();
            }

            _companiesService.DeleteCompany(companyEntity);

            await _companiesService.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{companyName}")]
        public async Task<ActionResult> UpdateCompany(string companyName, CompanyForUpdateDTO company)
        {
            var companyEntity = await _companiesService.GetCompanyAsync(companyName);

            if (companyEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(companyEntity, company);

            await _companiesService.SaveChangesAsync();

            //TODO: Chande the result

            return NoContent();
        }
    }
}
