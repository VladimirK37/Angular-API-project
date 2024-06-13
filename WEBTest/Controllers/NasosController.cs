using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Data.Context;
using WebTest.Data.Entityes;
using WEBTest.DTO;
using WEBTest.Services;

namespace WEBTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NasosController : Controller
    {
        private readonly NasosService _nasosService;

        public NasosController( NasosService nasosService)
        {
            _nasosService = nasosService;
        }

        /// <summary>
        /// Получение всех насосов
        /// </summary>
        /// <returns></returns>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NasosDto>>> GetAllNasoesAsync()
        {
            var dto = await _nasosService.GetAllNasosAsync();
            return Ok(dto);
        }

        /// <summary>
        /// Создание насоса
        /// </summary>
        /// <param name="nasos"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken] [FromQuery]
        public async Task<ActionResult> CreateNasos( NasosRequestDto nasos)
        {
            await _nasosService.CreateNasosAsync(nasos);
            return Ok();
        }

        /// <summary>
        /// Обновление насоса
        /// </summary>
        /// <param name="nasos"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<NasosDto> UpdateNasos(NasosDto nasos)
        {
            await _nasosService.UpdateNasosAsync(nasos);
            return nasos;
        }

        /// <summary>
        /// Удаление насоса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNasos(Guid id)
        {
            await _nasosService.DeleteNasosAsync(id);
            return NoContent();
        }
    }
}
