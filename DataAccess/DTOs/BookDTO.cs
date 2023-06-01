

namespace DataAccess.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
    }
}
