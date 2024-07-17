using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Password_Manager.DTOs;
using Password_Manager.Repositories;

public class IndexModel(IAccount accountRepo) : PageModel
{
    private readonly IAccount _accountRepo = accountRepo;

    public List<AddNoteDTO> Notes { get; set; }

    [BindProperty]
    public AddNoteDTO NewNote { get; set; }

    public async Task OnGetAsync()
    {
        Notes = await _accountRepo.GetNotesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Request.Form["Type"] == "Электронная почта" && !IsValidEmail(NewNote.WebsiteName))
            {
                ModelState.AddModelError(string.Empty, "Пожалуйста, введите корректный адрес электронной почты.");
                return Page();
            }

            if (NewNote.Password.Length < 8)
            {
                ModelState.AddModelError(string.Empty, "Пароль должен содержать минимум 8 символов.");
                return Page();
            }

            // Check for duplicate entries
            var existingNotes = await _accountRepo.GetNotesAsync();
            if (existingNotes.Exists(note => note.WebsiteName == NewNote.WebsiteName))
            {
                ModelState.AddModelError(string.Empty, "Запись с таким наименованием уже существует");
                return Page();
            }

            NewNote.DateTime = DateTime.Now;
            var response = await _accountRepo.AddNoteAsync(NewNote);
            if (response.Flag == true)
            {
                return RedirectToPage();
            }

            ModelState.AddModelError(string.Empty, response.Message);
            return Page();
        }
        catch (Exception ex) {}
        return Page();
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}