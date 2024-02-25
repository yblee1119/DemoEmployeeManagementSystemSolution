namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {
        //Relationship : One to Many with Employee
        public List<Employee>? employees { get; set; }

        //Many to one relationshop with City
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
