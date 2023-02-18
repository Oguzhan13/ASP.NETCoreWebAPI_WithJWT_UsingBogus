namespace ASP.NETCoreWebAPI_WithJWT.Models
{
    public class AuthResult
    {
        public string? Token { get; set; }
        public bool IsSuccess { get; set; }
    }
}