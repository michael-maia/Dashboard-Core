namespace Dashboard.Models
{
    public class User
    {
        // Propriedades
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public DateTime CreatedDate { get; set; } // Serve para identificar quando o usuário foi criado

        // Chaves Estrangeiras
        public int? RoleID { get; set; }
        public Role Role { get; set; }

        public int? SiteID { get; set; }
        public Site Site { get; set; }

        public int? GenderID { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
