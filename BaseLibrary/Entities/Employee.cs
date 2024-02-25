using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity
    {
        //public int Id { get; set; }
        //public string? Name { get; set; }

        [Required]
        public string? CivilId { get; set; } = string.Empty;

        [Required]
        public string? FileNumber { get; set; } = string.Empty;

        [Required]
        public string? Fullname { get; set; } = string.Empty;

        [Required]
        public string? JobName { get; set; } = string.Empty;

        [Required]
        public string? Address { get; set; } = string.Empty;

        [Required, DataType(DataType.PhoneNumber)]
        public string? TelephoneNumber { get; set; } = string.Empty;

        [Required]
        public string? Photo { get; } = string.Empty;
        public string? Other { get; set; }


        //// Relationshop : Many to One  = N : 1
        //public GeneralDepartment? GeneralDepartment { get; set; }
        //public int GeneralDepartmentId { get; set; }

        //public Department? Department { get; set; }
        //public int DepartmentId { get; set; }

        //Many to One relationshop with Branch
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }


        public Town? Town { get; set; }
        public int TownId { get; set; }

    }
}
