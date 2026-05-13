using System.ComponentModel.DataAnnotations.Schema;

namespace REST_Web_Api.Models;

public class PCComponents
{
    public int PCId { get; set; }
    public string ComponentCode { get; set; }
    public int Amount { get; set; }
    [ForeignKey(nameof(PCId))]
    public virtual PCs PCs { get; set; }
    [ForeignKey(nameof(ComponentCode))]
    public virtual Components Components { get; set; }
}