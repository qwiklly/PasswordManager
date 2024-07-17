namespace Password_Manager.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string EmailName { get; set; } = string.Empty;
        public string EmailPassword { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

    }
}
