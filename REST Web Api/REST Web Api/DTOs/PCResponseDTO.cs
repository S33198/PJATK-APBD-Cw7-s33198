namespace REST_Web_Api.DTOs;

public record PCResponseDTO( 
    int Id,
    String Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);