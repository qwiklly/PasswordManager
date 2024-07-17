using Microsoft.EntityFrameworkCore;
using Password_Manager.Data;
using Password_Manager.DTOs;
using Password_Manager.Models;
using static Password_Manager.Responses.CustomResponses;

namespace Password_Manager.Repositories
{
    public class Account : IAccount
    {
        private readonly AppDbContext _context;

        public Account(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistrationDTO>> GetUsersAsync()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.CreationDate)
                .Select(u => new RegistrationDTO
                {
                    EmailName = u.EmailName,
                    EmailPassword = u.EmailPassword,
                    CreationDateTime = u.CreationDate
                })
                .ToListAsync();

            return users;
        }

        public async Task<List<AddNoteDTO>> GetNotesAsync()
        {
            var notes = await _context.Website
                .OrderByDescending(w => w.CreationDate)
                .Select(w => new AddNoteDTO
                {
                    WebsiteName = w.WebsiteName,
                    Password = w.SitePassword,
                    DateTime = w.CreationDate
                })
                .ToListAsync();

            return notes;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationDTO model)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.EmailName == model.EmailName);
            if (existingUser != null)
            {
                return new RegistrationResponse(false, "User already exists");
            }

            var newUser = new Users
            {
                EmailName = model.EmailName,
                EmailPassword = model.EmailPassword,
                CreationDate = model.CreationDateTime
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new RegistrationResponse(true, "User registered successfully");
        }

        public async Task<AddNoteResponse> AddNoteAsync(AddNoteDTO model)
        {
            var existingNote = await _context.Website.FirstOrDefaultAsync(w => w.WebsiteName == model.WebsiteName);
            if (existingNote != null)
            {
                return new AddNoteResponse(false, "Website note already exists");
            }

            var newNote = new Website
            {
                WebsiteName = model.WebsiteName,
                SitePassword = model.Password,
                CreationDate = model.DateTime
            };

            _context.Website.Add(newNote);
            await _context.SaveChangesAsync();

            return new AddNoteResponse(true, "Website note added successfully");
        }
    }
}