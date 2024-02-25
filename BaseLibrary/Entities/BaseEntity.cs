using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; } = string.Empty;

        ////Relationshop : one to Many  1:다  
        //[JsonIgnore]
        //public List<Employee>? Employees { get; set; }

    }
}
 