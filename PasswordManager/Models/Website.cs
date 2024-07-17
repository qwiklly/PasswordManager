namespace Password_Manager.Models
{
    public class Website
    {
        public int Id { get; set; }
        public string WebsiteName { get; set; } = string.Empty;
        public string SitePassword { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

    }
}
