namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        //Many to One (다:일) relationship with Department
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }


        //Relationshop : One to Many with Employee
        public List<Employee>? Employees { get; set; }
    }
}
