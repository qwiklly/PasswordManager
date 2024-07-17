using System.ComponentModel.DataAnnotations;

namespace Password_Manager.DTOs
{
    public class RegistrationDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string EmailName { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Пароль должен содержать минимум 8 символов ", MinimumLength = 8)]
        public string EmailPassword { get; set; } = string.Empty;

        [Required]
        public DateTime CreationDateTime { get; set; }

    }
}
