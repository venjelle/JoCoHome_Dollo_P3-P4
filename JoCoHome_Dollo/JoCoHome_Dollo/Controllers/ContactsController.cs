using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JoCoHome_Dollo.Data;
using JoCoHome_Dollo.Models;
using System.Net.Mail;
using System.Net;

namespace JoCoHome_Dollo.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NaamSortParm = sortOrder == "naam" ? "naam_desc" : "naam";
            ViewBag.EmailSortParm = sortOrder == "email" ? "email_desc" : "email";
            ViewBag.OnderwerpSortParm = sortOrder == "onderwerp" ? "onderwerp_desc" : "onderwerp";
            var mail = from m in _context.Contact
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                mail = mail.Where(s => s.Naam.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "naam":
                    mail = mail.OrderBy(s => s.Naam);
                    break;
                case "naam_desc":
                    mail = mail.OrderByDescending(s => s.Naam);
                    break;
                case "email":
                    mail = mail.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    mail = mail.OrderByDescending(s => s.Email);
                    break;
                case "onderwerp":
                    mail = mail.OrderBy(s => s.Onderwerp);
                    break;
                case "onderwerp_desc":
                    mail = mail.OrderByDescending(s => s.Onderwerp);
                    break;
                default:
                    mail = mail.OrderBy(s => s.Id);
                    break;
            }
            return View(await mail.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Email,TelefoonNr,Onderwerp,Bericht")] Contact mail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mail);
                await _context.SaveChangesAsync();
                var body = "<b><p>Email From: {0} ({1})</p></b><b><p>Telefoonnummer:</p></b> {2} <b><p>Onderwerp:</p></b> {3}<b><p>Message:</p></b><p>{4}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("bowelter@hotmail.com"));  // replace with valid value 
                message.From = new MailAddress("bowelterbot@hotmail.com");  // replace with valid value
                message.Subject = "E-mail CeeLearnAndDo Contactform";
                message.Body = string.Format(body, mail.Naam, mail.Email, mail.TelefoonNr, mail.Onderwerp, mail.Bericht);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "bowelterbot@hotmail.com",  // replace with valid value
                        Password = "QAk4I5L40knxUYIe8fip"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(mail);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Email,TelefoonNr,Onderwerp,Bericht")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}
