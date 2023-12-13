using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime BuyDate { get; set; }
        public string IdentityUserId { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
