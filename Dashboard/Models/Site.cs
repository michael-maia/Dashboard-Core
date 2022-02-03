namespace Dashboard.Models
{
    public class Site
    {
        // Propriedades
        public int SiteID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        // Chaves Estrangeiras
        public ICollection<User> Users { get; set; }
    }
}
