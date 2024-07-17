using Password_Manager.DTOs;
using static Password_Manager.Responses.CustomResponses;

namespace Password_Manager.Repositories
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationDTO model);
        Task<AddNoteResponse> AddNoteAsync(AddNoteDTO model);
        Task<List<RegistrationDTO>> GetUsersAsync();
        Task<List<AddNoteDTO>> GetNotesAsync();
    }
}
