using Microsoft.AspNetCore.Mvc;
using WebTest.Data.Context;
using WEBTest.DTO;
using WEBTest.Services;

namespace WEBTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : Controller
    {
        private readonly MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialResultDto>>> GetAllMaterialsAsync()
        {
            var dto = await _materialService.GetAllMaterialsAsync();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaterial(MaterialResultDto material)
        {
            await _materialService.CreateMaterialAsync(material);
            return Ok();
        }

        [HttpPut]
        public async Task<MaterialResultDto> UpdateMotor(MaterialResultDto materialDto)
        {
            await _materialService.UpdateMaterialAsync(materialDto);
            return materialDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(Guid id)
        {
            await _materialService.DeleteMaterialAsync(id);
            return NoContent();
        }

    }
}
