using Microsoft.AspNetCore.Mvc;
using Password_Manager.DTOs;
using Password_Manager.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using static Password_Manager.Responses.CustomResponses;

namespace Password_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountRepository;

        public AccountController(IAccount accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("GetUsers")]
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Retrieve a list of all registered users."
        )]
        public async Task<ActionResult<List<RegistrationDTO>>> GetUsersAsync()
        {
            var users = await _accountRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("GetNotes")]
        [SwaggerOperation(
            Summary = "Get all website notes",
            Description = "Retrieve a list of all website notes."
        )]
        public async Task<ActionResult<List<AddNoteDTO>>> GetNotesAsync()
        {
            var notes = await _accountRepository.GetNotesAsync();
            return Ok(notes);
        }

        [HttpPost("Register")]
        [SwaggerOperation(
            Summary = "Register new user",
            Description = "Register a new user with email and password."
        )]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationDTO model)
        {
            var result = await _accountRepository.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("AddNote")]
        [SwaggerOperation(
            Summary = "Add new website note",
            Description = "Add a new website note with website name and password."
        )]
        public async Task<ActionResult<AddNoteResponse>> AddNoteAsync(AddNoteDTO model)
        {
            var result = await _accountRepository.AddNoteAsync(model);
            return Ok(result);
        }
    }
}

