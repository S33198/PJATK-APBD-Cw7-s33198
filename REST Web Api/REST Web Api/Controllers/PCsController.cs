using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using REST_Web_Api.DTOs;
using REST_Web_Api.Service;

namespace REST_Web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PCsController(PCsService service): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCComponentDetail(int id, CancellationToken cancellationToken)
    {
        var result = await service.GetPCComponentDetailAsync(id, cancellationToken);
        if(result == null)
            return NotFound("Pc with id: " + id + " not found");
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePC(PCCreateRequestDTO dto, CancellationToken ct)
    {
        try
        {
            var newId = await service.CreatePCAsync(dto, ct);
            return CreatedAtAction(nameof(GetAll), new {id = newId}, dto);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePC(int id, PCCreateRequestDTO dto, CancellationToken ct)
    {
        try
        {
            await service.UpdatePCAsync(id, dto, ct);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePC(int id, CancellationToken ct)
    {
        var deleted = await service.DeletePCAsync(id, ct);
        if(deleted)
            return NoContent();
        return NotFound("Pc with id: " + id + " not found");
    }
    
}