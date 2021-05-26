using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(25)")]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR(25)")]
        public string LastName { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string Phone { get; set; }
        [Column(TypeName = "VARCHAR(40)")]
        public string Address { get; set; }       
    }
}