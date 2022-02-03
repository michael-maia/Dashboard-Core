namespace Dashboard.Models
{
    public class Role
    {
        // Propriedades
        public int RoleID { get; set; }
        public string Name { get; set; }
        
        // Chaves Estrangeiras
        public ICollection<User> Users { get; set; }
    }
}
