using EntityFrameworkMvc.Models;

namespace EntityFrameworkMvc.ViewModels
{
    public class InformationVM
    {
        public List<Author> AuthorData { get; set; }
        public List<AuthorProfile> AuthorProfileData { get; set; }
        public List<Book> BookData { get; set; }
        public List<AuthorPublisher> AuthorPublisherData { get; set; }
    }
}
