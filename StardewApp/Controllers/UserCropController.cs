using Microsoft.AspNetCore.Mvc;
using StardewApp.Models;
using StardewApp.Interfaces;
using StardewApp.Services;
using StardewApp.DTOs;
namespace StardewApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserCropController : ControllerBase
{

    private readonly IUserCropService _service;

    public UserCropController(IUserCropService service) 
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<UserCropResDto>> Add([FromBody] UserCropCreateDto dto)
    {
        var result = await _service.AddUserCropAsync(dto);
        if (result == null) return BadRequest();

        return Ok(result);
    }


    [HttpGet]
    public async Task<List<UserCropResDto>> GetAll()
    {
        return await _service.GetAllUserCropsAsync();
    }
    
    [HttpPut]
    public async Task<ActionResult<UserCropResDto>> Update(UserCropUpdateDto dto)
    {
        var result = await _service.UpdateUserCropAsync(dto);
        if (result == null) return BadRequest();
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await _service.DeleteUserCropAsync(id);
        return Ok(result);
    }
    

}