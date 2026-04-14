using System.ComponentModel.DataAnnotations;

namespace LinqLab.Models
{
    internal class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress] 
        [MaxLength(150)]
        public string Email { get; set; }

        [Phone] 
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}