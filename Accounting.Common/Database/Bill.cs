namespace Accounting.Backend.Database
{
    public class Bill
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public BillType BillType { get; set; }
        public BillStatus BillStatus { get; set; }
    }
}
