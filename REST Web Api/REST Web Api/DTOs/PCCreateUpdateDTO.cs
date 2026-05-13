using System.ComponentModel.DataAnnotations;

namespace REST_Web_Api.DTOs;

public record PCCreateUpdateDTO (
    [Required, MaxLength(50)] string Name,
    [Range(0, 100)] float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);