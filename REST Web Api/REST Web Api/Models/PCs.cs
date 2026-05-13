using System.ComponentModel.DataAnnotations;

namespace REST_Web_Api.Models;

public class PCs
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<PCComponents> PCComponents { get; set; }
}