namespace REST_Web_Api.Models;

public class ComponentTypes
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    public List<Components> Components {get; set;}
    
}