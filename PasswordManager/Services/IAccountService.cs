using static Password_Manager.Responses.CustomResponses;
using Password_Manager.DTOs;

namespace Password_Manager.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationDTO model);
        Task<AddNoteResponse> AddNoteAsync(AddNoteDTO model);


    }
}
