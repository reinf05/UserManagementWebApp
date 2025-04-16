using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UserManagementWebApp.DTO
{
    public class UserDto
    {
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull]
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
