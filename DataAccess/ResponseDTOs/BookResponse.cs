
namespace DataAccess.ResponseDTOs
{
    public class BookResponse
    {   public Guid Id { get; set; }
        public string Title { get; set; }
       
        public Guid AuthorId { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Author { get; set; }
    }
}
