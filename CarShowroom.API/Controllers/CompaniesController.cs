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
    /// <summary>
    /// Controller to work with companies entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 50;

        /// <summary>
        /// Constructor of controller 
        /// </summary>
        /// <param name="companiesService">Company service</param>
        /// <param name="mapper">Auto mapper</param>
        /// <exception cref="ArgumentNullException">If parameter is null</exception>
        public CompaniesController(ICompaniesService companiesService, IMapper mapper)
        {
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Receive collection of companies
        /// </summary>
        /// <param name="pageNumber">Number of page which we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of companies</returns>
        /// <response code="200">Returned collection of brands</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanies(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }
            var (Companies, paginationMetadata) = await _companiesService.GetCompaniesAsync(pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(Companies));
        }

        /// <summary>
        /// Receive company
        /// </summary>
        /// <param name="companyName">Name of the company</param>
        /// <param name="includeEngines">Include engines or not</param>
        /// <param name="includeBrands">Include brands or not</param>
        /// <returns>Company model</returns>
        /// /// <response code="200">Returned company with or without collections</response>
        /// <response code="404">Haven't found company</response>
        [HttpGet("{companyName}", Name = "GetCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompany(string companyName, bool includeEngines = false, bool includeBrands = false)
        {
            var company = await _companiesService.GetCompanyAsync(companyName, includeEngines, includeBrands);
            if (company == null)
            {
                return NotFound();
            }

            if (includeEngines == false && includeBrands == true)
            {
                return Ok(_mapper.Map<CompanyWithBrandsDTO>(company));
            }
            if (includeEngines == true && includeBrands == false)
            {
                return Ok(_mapper.Map<CompanyWithEnginesDTO>(company));
            }
            if (includeEngines == false && includeBrands == false)
            {
                return Ok(_mapper.Map<CompanyDTO>(company));
            }
            
            return Ok(_mapper.Map<CompanyWithCollectionsDTO>(company));
        }

        /// <summary>
        /// Add company to data base
        /// </summary>
        /// <param name="company">Company for adding</param>
        /// <returns>Added company</returns>
        /// <response code="201">Added company to data base</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes("application/json", "application/xml")]
        public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyCreationDTO company)
        {
            var finalCompany = _mapper.Map<Company>(company);

            await _companiesService.AddCompanyAsync(finalCompany);

            await _companiesService.SaveChangesAsync();

            var companyToReturn = _mapper.Map<CompanyDTO>(finalCompany);

            return CreatedAtRoute("GetCompany", new {companyName = company.CompanyName}, companyToReturn);
        }

        /// <summary>
        /// Delete company from data base
        /// </summary>
        /// <param name="companyName">Name of company</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Deleted company from data base</response>
        /// <response code="404">Haven't found company</response>
        [HttpDelete("{companyName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Update of company
        /// </summary>
        /// <param name="companyName">Name of company</param>
        /// <param name="company">New company</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Updated company</response>
        /// <response code="404">Haven't found company</response>
        [HttpPut("{companyName}")]
        public async Task<IActionResult> UpdateCompany(string companyName, CompanyForUpdateDTO company)
        {
            var companyEntity = await _companiesService.GetCompanyAsync(companyName);

            if (companyEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(company, companyEntity);

            await _companiesService.SaveChangesAsync();

            return NoContent();
        }
    }
}
