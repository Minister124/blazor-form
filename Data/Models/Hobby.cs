namespace Forms.Data.Models;
public class Hobby
{
    public Guid Id {get; set;} = Guid.NewGuid(); // Automaticallu generates unique Id.
    public string Name {get; set;}
}