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
    //[Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsService _brandsService;
        private readonly IMapper _mapper;
        private readonly ICompaniesService _companiesService;
        private const int maxBrandspageSize = 50;

        public BrandsController(IBrandsService brandsService, IMapper mapper, ICompaniesService companiesService)
        {
            _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
        }

        [HttpGet("api/Brands")]
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

        [HttpGet("api/Companies/{companyName}/Brands")]
        public async Task<ActionResult<IEnumerable<BrandWithoutCompNameDTO>>> GetBrandsForCompany(string companyName)
        {
            if (!await _companiesService.IsExistCompanyAsync(companyName))
            {
                return NotFound();
            }

            var brands = await _brandsService.GetBrandsForCompanyAsync(companyName);

            return Ok(_mapper.Map<IEnumerable<BrandWithoutCompNameDTO>>(brands));
        }

        [HttpGet("api/Brands/{brandId}", Name = "GetBrand")]
        public async Task<IActionResult> GetBrand(int brandId, bool includeModels = false)
        {
            var brand = await _brandsService.GetBrandAsync(brandId, includeModels);

            if (brand == null)
            {
                return NoContent();
            }

            if (includeModels)
            {
                return Ok(_mapper.Map<BrandWithModelsDTO>(brand));
            }

            return Ok(_mapper.Map<BrandDTO>(brand));
        }

        [HttpPost("api/Brands")]
        public async Task<ActionResult<BrandDTO>> CreateBrand(BrandCreationDTO brand)
        {
            var finalBrand = _mapper.Map<Brand>(brand);

            await _brandsService.AddBrand(finalBrand);

            await _brandsService.SaveChangesAsync();

            var createdBrandToReturn = _mapper.Map<BrandDTO>(finalBrand);

            return CreatedAtRoute("GetBrand", new {brandId = createdBrandToReturn.Id}, createdBrandToReturn);
        }

        [HttpDelete("api/Brands/{brandId}")]
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

        [HttpPatch("api/Brands/{brandId}")]
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
