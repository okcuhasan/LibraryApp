namespace EntityFrameworkMvc.Models
{
    public class AuthorProfile
    {
        public int AuthorProfileId { get; set; }

        public string? SocialMedia { get; set; }

        public string? WebSite { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
