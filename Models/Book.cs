using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Book:BaseModel
    {
       
        public string Title { get; set; }
        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public Author Author { get; set; }
    }
}
