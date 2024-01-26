namespace EntityFrameworkMvc.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string? BookName { get; set; }

        public string? BookDescription { get; set;}

        public DateTime? BookYearOfPublication { get; set;}

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
