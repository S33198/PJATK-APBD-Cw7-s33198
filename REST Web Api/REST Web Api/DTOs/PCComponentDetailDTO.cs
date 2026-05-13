namespace REST_Web_Api.DTOs;

public record PCComponentDetailDTO(
    string ComponentCode,
    string Name,
    int Amount,
    string ManufacturerName
);