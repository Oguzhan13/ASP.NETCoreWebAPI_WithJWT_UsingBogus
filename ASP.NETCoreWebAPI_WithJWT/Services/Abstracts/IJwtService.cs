namespace ASP.NETCoreWebAPI_WithJWT.Services.Abstracts
{
    public interface IJwtService
    {
        string GetJwtToken(User user);
    }
}