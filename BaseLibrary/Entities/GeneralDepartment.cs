namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //One to many (일:다) relationship with Department
        public List<Department>? Departments { get; set; }
    }
}
