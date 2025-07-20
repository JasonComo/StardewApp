using Microsoft.AspNetCore.Mvc;
using StardewApp.Interfaces;
using StardewApp.Services;
using StardewShared.DTOs;

namespace StardewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CropController : ControllerBase
    {
        private readonly ICropService _service;

        public CropController(ICropService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CropResDto>>> GetAll()
        {
            var result = await _service.GetAllCropsAsync();
            return Ok(result);
        }
    }
}
