namespace ASP.NETCoreWebAPI_WithJWT.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}