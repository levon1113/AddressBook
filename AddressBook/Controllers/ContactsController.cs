using AddressBook.Data;
using AddressBook.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ContactsController( ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var contacts = _context.Contacts;
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Contact Contact)
        {
            Contact contact = new Contact
            {
                FullName = Contact.FullName,
                Phone = Contact.Phone,
                Address = Contact.Address,
                Email = Contact.Email,
            };
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Contact? contact = await _context.Contacts.FindAsync(id);
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Single (int id)
        {
            var contact = _context.Contacts.Find(id);
            return View(contact);
        }

    }
}
