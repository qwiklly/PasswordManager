namespace Password_Manager.Responses
{
    public class CustomResponses
    {
        public record RegistrationResponse(bool Flag = false, string Message = null!);
        public record AddNoteResponse(bool Flag=false, string Message = null!);
        public record GetNoteResponse(bool Flag = false, string Message = null!);
    }
}
