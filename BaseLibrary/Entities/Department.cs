namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        //Many to One (다:일) relationship with Department
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        //One to Many (일:다) relationship with Branch
        public List<Branch>? Branches { get; set; }
    }
}
