using Password_Manager.DTOs;
using static Password_Manager.Responses.CustomResponses;

namespace Password_Manager.Services
{
    public class AccountService(HttpClient httpClient) : IAccountService
    {
        private readonly HttpClient httpClient = httpClient;

        public async Task<RegistrationResponse> RegisterAsync(RegistrationDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/Account/Register", model);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
            return result!;
        }
        public async Task<AddNoteResponse> AddNoteAsync(AddNoteDTO model)
        {
            var response = await httpClient.DeleteAsync($"api/Account/AddNote");
            var result = await response.Content.ReadFromJsonAsync<AddNoteResponse>();
            return result!;
        }
    }
}
