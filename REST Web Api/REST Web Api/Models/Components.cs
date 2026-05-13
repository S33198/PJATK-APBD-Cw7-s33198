using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_Web_Api.Models;

public class Components
{
    [Key, Column(TypeName = "char(10)")]
    public string Code { get; set; }
    [Required, MaxLength(300)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int ComponentManufacturesld { get; set; }
    public int ComponentTypesld { get; set; }
    [ForeignKey(nameof(ComponentManufacturesld))]
    public ComponentManufacturers ComponentManufacturers { get; set; }
    [ForeignKey(nameof(ComponentTypesld))]
    public ComponentTypes ComponentTypes { get; set; }
    public List<PCComponents> PCComponents { get; set; }

}