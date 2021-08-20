using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class ContactService
    {
        private readonly PersonalCVContext _context;

        public ContactService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task SetAsRead(int contactId)
        {
            var contact = await GetItemById(contactId);
            contact.IsRead = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetItemById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<bool> ContactExists(int id)
        {
            return await _context.Contacts.AnyAsync(e => e.Id == id);
        }
    }
}
