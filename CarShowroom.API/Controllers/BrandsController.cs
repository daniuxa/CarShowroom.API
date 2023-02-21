using AutoMapper;
using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.BrandDTOs;
using CarShowroom.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarShowroom.API.Controllers
{
    /// <summary>
    /// Controller to work with brand entity
    /// </summary>
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsService _brandsService;
        private readonly IMapper _mapper;
        private readonly ICompaniesService _companiesService;
        private const int maxBrandspageSize = 50;

        /// <summary>
        /// Constructor of controller 
        /// </summary>
        /// <param name="brandsService">Brand service</param>
        /// <param name="mapper">Auto mapper</param>
        /// <param name="companiesService">Company service</param>
        /// <exception cref="ArgumentNullException">If parameter is null</exception>
        public BrandsController(IBrandsService brandsService, IMapper mapper, ICompaniesService companiesService)
        {
            _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
        }

        /// <summary>
        /// Receive collection of brands
        /// </summary>
        /// <param name="pageNumber">Number of page which we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of brands</returns>
        /// <response code="200">Returned collection of brands</response>
        [HttpGet("api/Brands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetBrands(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxBrandspageSize)
            {
                pageSize = maxBrandspageSize;
            }

            var (Brands, paginationMetadata) = await _brandsService.GetBrandsAsync(pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<BrandDTO>>(Brands));
        }

        /// <summary>
        /// Receive collection of brands which are in the same company
        /// </summary>
        /// <param name="companyName">Name of the company</param>
        /// <returns>Collection of brands</returns>
        /// <response code="200">Returned collection of brands</response>
        /// <response code="404">Haven't found company</response>
        [HttpGet("api/Companies/{companyName}/Brands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BrandWithoutCompNameDTO>>> GetBrandsForCompany(string companyName)
        {
            if (!await _companiesService.IsExistCompanyAsync(companyName))
            {
                return NotFound();
            }

            var brands = await _brandsService.GetBrandsForCompanyAsync(companyName);

            return Ok(_mapper.Map<IEnumerable<BrandWithoutCompNameDTO>>(brands));
        }

        /// <summary>
        /// Receive brand 
        /// </summary>
        /// <param name="brandId">Id of brand</param>
        /// <param name="includeModels">Include or not models into brand</param>
        /// <returns>Brand which has this Id</returns>
        /// <response code="200">Returned brand with or without models collection</response>
        /// <response code="404">Haven't found brand</response>
        [HttpGet("api/Brands/{brandId}", Name = "GetBrand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBrand(int brandId, bool includeModels = false)
        {
            var brand = await _brandsService.GetBrandAsync(brandId, includeModels);

            if (brand == null)
            {
                return NotFound();
            }

            if (includeModels)
            {
                return Ok(_mapper.Map<BrandWithModelsDTO>(brand));
            }

            return Ok(_mapper.Map<BrandDTO>(brand));
        }

        /// <summary>
        /// Add a brand to data base
        /// </summary>
        /// <param name="brand">Brand for adding</param>
        /// <returns>Added brand</returns>
        /// <response code="201">Added brand to data base</response>
        [HttpPost("api/Brands")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes ("application/json", "application/xml")]
        public async Task<ActionResult<BrandDTO>> CreateBrand(BrandCreationDTO brand)
        {
            var finalBrand = _mapper.Map<Brand>(brand);

            await _brandsService.AddBrand(finalBrand);

            await _brandsService.SaveChangesAsync();

            var createdBrandToReturn = _mapper.Map<BrandDTO>(finalBrand);

            return CreatedAtRoute("GetBrand", new {brandId = createdBrandToReturn.Id}, createdBrandToReturn);
        }

        /// <summary>
        /// Delete brand from data base
        /// </summary>
        /// <param name="brandId">Id of brand</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Deleted brand from data base</response>
        /// <response code="404">Haven't found brand</response>
        [HttpDelete("api/Brands/{brandId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            var brandEntity = await _brandsService.GetBrandAsync(brandId);

            if (brandEntity == null)
            {
                return NotFound();
            }

            _brandsService.DeleteBrand(brandEntity);

            await _brandsService.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update of brand
        /// </summary>
        /// <param name="brandId">Id of brand</param>
        /// <param name="patchDocument">The set of operations to apply to the brand</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Updated brand</response>
        /// <response code="404">Haven't found brand</response>
        /// <response code="400">Incorrect entered command for updating</response>
        /// <remarks>
        /// Sample request (this request updates the brand's name)
        /// PATCH /Brands/id
        /// [
        ///     {
        ///         "op": "replace",
        ///         "path": "/name",
        ///         "values": "NewName"
        ///     }
        /// ]
        /// </remarks> 
        [HttpPatch("api/Brands/{brandId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PartiallyUpdateBrand(int brandId, JsonPatchDocument<BrandUpdateDTO> patchDocument)
        {
            var brandEntity = await _brandsService.GetBrandAsync(brandId);

            if (brandEntity == null)
            {
                return NotFound();
            }

            var brandToPatch = _mapper.Map<BrandUpdateDTO>(brandEntity);

            patchDocument.ApplyTo(brandToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(brandToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(brandToPatch, brandEntity);

            await _brandsService.SaveChangesAsync();

            return NoContent();
        }
    }
}
