using Microsoft.AspNetCore.Mvc;
using StardewApp.Models;
using StardewApp.Interfaces;
using StardewApp.Services;
using StardewShared.DTOs;
using StardewShared.Enums;
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
    public async Task<ActionResult<List<UserCropResDto>>> GetAll()
    {
        var result = _service.GetAllUserCropsAsync();
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<UserCropResDto>> Update([FromBody] UserCropUpdateDto dto)
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

    [HttpGet("calculateprofit")]
    public async Task<ActionResult<float>> GetProfit(int id, Fertilizer fertilizer, int quantity)
    {
        var result = await _service.CalculateUserCropProfitAsync(id, fertilizer, quantity);
        return Ok(result);
    }

    [HttpGet("totalprofit")]
    public async Task<ActionResult<float>> GetTotalProfit()
    {
        var result = await _service.CalculateTotalUserCropProfitAsync();
        return Ok(result);
    }



}