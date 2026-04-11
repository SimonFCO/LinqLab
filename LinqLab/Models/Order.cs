namespace LinqLab.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        // Navs :D
        public Customer Customer { get; set; }
    }
}
