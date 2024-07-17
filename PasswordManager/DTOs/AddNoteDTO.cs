using System.ComponentModel.DataAnnotations;

namespace Password_Manager.DTOs
{
    public class AddNoteDTO
    {
        [Required]
        public string WebsiteName { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Пароль должен содержать минимум 8 символов ", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }

    }
}
