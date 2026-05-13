using REST_Web_Api.DTOs;
using REST_Web_Api.Models;
using REST_Web_Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace REST_Web_Api.Service;

public class PCsService(DataBaseContext ctx)
{
    public async Task<IEnumerable<PCResponseDTO>> GetAllAsync(CancellationToken ct)
    {
        return await ctx.PC.Select(pc => new PCResponseDTO(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock)).ToListAsync(ct);
    }
}