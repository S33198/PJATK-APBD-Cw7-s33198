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
}