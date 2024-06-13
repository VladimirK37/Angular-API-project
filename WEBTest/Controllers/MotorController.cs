using Microsoft.AspNetCore.Mvc;
using WebTest.Data.Context;
using WEBTest.DTO;
using WEBTest.Services;

namespace WEBTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotorController : Controller
    {
        private readonly MotorService _motorService;

        public MotorController( MotorService motorService)
        {
            _motorService = motorService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorResultDto>>> GetAllMotorAsync()
        {
            var dto = await _motorService.GetAllMotorAsync();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMotorAsync( MotorResultDto motor)
        {
            await _motorService.CreateMotorAsync(motor);
            return Ok();
        }

        [HttpPut]
        public async Task<MotorResultDto> UpdateMotorAsync(MotorResultDto motorDto)
        {
            await _motorService.UpdateMotorAsync(motorDto);
            return motorDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMotorAsync(Guid id)
        {
            await _motorService.DeleteMotorAsync(id);
            return NoContent();
        }
    }
}
