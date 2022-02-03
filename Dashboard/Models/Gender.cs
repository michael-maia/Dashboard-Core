namespace Dashboard.Models
{
    public class Gender
    {
        // Propriedades
        public int GenderID { get; set; }
        public string Name { get; set; }

        // Chaves Estrangeiras
        public ICollection<User> Users { get; set; }
    }
}
