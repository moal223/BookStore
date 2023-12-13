using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        public List<Book>? Books { get; set; }
        public List<BookCategory>? BookCategories { get; set; }
    }
}
