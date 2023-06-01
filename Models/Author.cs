using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models
{
    public class Author:BaseModel
    {
        

        public string Name { get; set; }
        [ValidateNever]
        public ICollection<Book> Books { get; set; }

     
    }
}