using System.Collections;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<IEnumerable<PCComponentDetailDTO>?> GetPCComponentDetailAsync(int id, CancellationToken ct)
    {
        var PcExists = await ctx.PC.AnyAsync(p=> p.Id == id, ct);
        if(!PcExists)
            return null;
        return await ctx.PCComponent.Where(p=> p.PCId == id)
            .Select(pc => new PCComponentDetailDTO(
                pc.ComponentCode,
                pc.Components.Name,
                pc.Amount,
                pc.Components.ComponentManufacturers.FullName
            )).ToListAsync(ct);
    }

    public async Task<int> CreatePCAsync(PCCreateRequestDTO dto, CancellationToken ct)
    {
        var PC = new PCs
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            Stock = dto.Stock,
            CreatedAt = DateTime.Now
        };
        if(PC.Weight < 0)
            throw new ArgumentException("Weight must be greater than 0");
        if(PC.Warranty < 0)
            throw new ArgumentException("Warranty must be greater than 0");
        if(PC.Stock < 0)
            throw new ArgumentException("Stock must be greater than 0");
        ctx.PC.Add(PC);
        await ctx.SaveChangesAsync(ct);
        return PC.Id;
    }

    public async Task UpdatePCAsync(int id, PCCreateRequestDTO dto, CancellationToken ct)
    {
        var PC = await ctx.PC.FirstOrDefaultAsync(p => p.Id == id, ct);
        if (PC == null)
            throw new ArgumentException("PC not found");
        PC.Name = dto.Name;
        PC.Weight = dto.Weight;
        PC.Warranty = dto.Warranty;
        PC.Stock = dto.Stock;
        if (PC.Weight < 0)
            throw new ArgumentException("Weight must be greater than 0");
        if (PC.Warranty < 0)
            throw new ArgumentException("Warranty must be greater than 0");
        if (PC.Stock < 0)
            throw new ArgumentException("Stock must be greater than 0");
        ctx.PC.Update(PC);
        await ctx.SaveChangesAsync(ct);
    }

    public async Task<bool> DeletePCAsync(int id, CancellationToken ct)
    {
        var pc = await ctx.PC.FirstOrDefaultAsync(p => p.Id == id, ct);
        if(pc==null)
            throw new ArgumentException("PC not found");
        ctx.PC.Remove(pc);
        return await ctx.SaveChangesAsync(ct) > 0;
        
    }
}