using Microsoft.AspNetCore.Mvc;
using StardewApp.Models;
using StardewApp.Interfaces;
using StardewApp.Services;
using StardewApp.DTOs;
using System.Reflection.Metadata.Ecma335;
namespace StardewApp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SettingController : ControllerBase
{
    private readonly ISettingService _service;

    public SettingController(ISettingService service)
    {
        _service = service;

    }

    [HttpGet]
    public async Task<ActionResult<SettingResDto>> Get(int id)
    {
        var result = await _service.GetSettingByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);  
    }

    [HttpPut]
    public async Task<ActionResult<SettingResDto>> Update([FromBody] SettingUpdateDto dto)
    {
        var result = await _service.UpdateSettingsAsync(dto);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}
