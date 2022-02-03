namespace Dashboard.Models
{
    public class Department
    {
        // Propriedades
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        // Chaves estrangeiras
        public ICollection<User> Users { get; set; }
    }
}
