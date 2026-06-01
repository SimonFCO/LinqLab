using System.ComponentModel.DataAnnotations;

namespace LinqLab.Models
{
    internal class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress] 
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Phone] 
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}