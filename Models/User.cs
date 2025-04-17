using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


//Custom data type for User
namespace UserManagementWebApp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull]
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly RegistrationDate { get; set; }

        public User()
        {
            RegistrationDate =  DateOnly.Parse(DateTime.Now.ToShortDateString());
        }
    }
}
