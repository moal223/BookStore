using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string Name { get; set; }
        [Required]
        public float Salary { get; set; }
        public float Offer { get; set; }
        public int  PageNo { get; set; }
        [MaxLength(30)]
        public string? Author { get; set; }
        public float Rate { get; set; }
        public DateTime PublishDate { get; set; }

        public List<Category>? Category {  get; set; }
        public List<BookCategory>? BookCategory { get; set; }
    }
}
