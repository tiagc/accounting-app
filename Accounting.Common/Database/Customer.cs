namespace Accounting.Backend.Database
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
