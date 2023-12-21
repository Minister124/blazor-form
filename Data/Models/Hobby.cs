using System.ComponentModel.DataAnnotations;

namespace Forms.Data.Models;
public class Hobby
{
    public Guid Id {get; set;} = Guid.NewGuid(); // Automaticallu generates unique Id.
    [Required(ErrorMessage ="The Name is Required")]
    public string Name {get; set;}
}