namespace EntityFrameworkMvc.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }

        public DateTime? AuthorBirthDate { get; set; }

        public string? AuthorsBirthPlace { get; set; }

        public string? AuthorsSchool { get; set; }

        public List<Book> ?Books { get; set; }

        public AuthorProfile? AuthorProfile { get; set; }

        public List<AuthorPublisher> ?AuthorPublishers { get; set; }
    }
}
