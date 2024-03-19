using System.ComponentModel.DataAnnotations;

namespace CRUD.Models;
public class Category
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now; //here default value will be assign when we create a object for this class


}