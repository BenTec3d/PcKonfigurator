using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public EmployeeEntity(string login, string firstName, string lastName, byte[] passwordHash, byte[] passwordSalt)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
