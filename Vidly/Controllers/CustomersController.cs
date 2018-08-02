using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public virtual ViewResult Index()
        {
            var customList = _context.Customers.Include(c => c.MembershipType).ToList();
          
            return View(customList);
        }

        [Route("/{id}")]
        public virtual ActionResult Details(int id)
        {

            Customer customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }        
    }
}