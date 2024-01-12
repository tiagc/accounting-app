using Accounting.Backend.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Backend.Controllers
{
    [ApiController]
    [Route("Accounting")]
    public class AccountingController : ControllerBase
    {
        private readonly AccountingContext _context;

        public AccountingController(AccountingContext context)
        {
            _context = context;
        }

        // Liste von allen Customers anzeigen
        [HttpGet("customer")]
        public ActionResult<List<Customer>> GetCustomers()
        {
            var customers = _context.Customers.ToList();
            _context.Bills.Load();
            return Ok(customers);
        }

        // Customer erstellen
        [HttpPost("customer")]
        public ActionResult<int> CreateCustomer([FromQuery] string customerName)
        {
            var x = new Customer();
            x.CustomerName = customerName;
            _context.Customers.Add(x);
            _context.SaveChanges();

            return Ok(10);
        }

        // Bill erstellen
        [HttpPost("customer/{customerId}/bill")]
        public ActionResult<int> CreateCustomerBill([FromRoute] int customerId, [FromQuery] BillType billType, [FromQuery] BillStatus billStatus)
        {
            var customers = _context.Customers.ToList();

            foreach (var customer in customers)
            {
                if (customer.Id == customerId)
                {
                    var bill = new Bill();
                    bill.CustomerId = customerId;
                    bill.BillType = billType;
                    bill.BillStatus = billStatus;
                    _context.Bills.Add(bill);
                    _context.SaveChanges();
                }
            }
            return Ok(1);
        }

        // Bill löschen
        [HttpDelete("customer/{customerId}/bill")]
        public ActionResult<int> DeleteCustomerBill([FromRoute] int billId)
        {

            var bill = _context.Bills.First(e => e.Id == billId);

            _context.Bills.Remove(bill);
            return Ok();
        }
    }
}
