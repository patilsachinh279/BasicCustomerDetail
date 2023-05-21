namespace Customer.Business.Domain.Entities
{
    public class Order
    {
        public Guid? Id { get; set; }
        public Guid? CustomerId { get; set; }
        public string? ProductName { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
