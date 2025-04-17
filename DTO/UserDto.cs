using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


//User Data Transfer Object
namespace UserManagementWebApp.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull]
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
