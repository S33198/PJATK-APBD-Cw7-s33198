namespace REST_Web_Api.Models;

public class ComponentManufacturers
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string FullName { get; set; }
    public DateTime FoundationDate { get; set; }
    public List<Components> Components {get; set;}
}