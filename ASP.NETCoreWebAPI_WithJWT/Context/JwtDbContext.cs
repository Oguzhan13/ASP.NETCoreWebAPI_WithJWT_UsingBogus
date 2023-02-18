namespace ASP.NETCoreWebAPI_WithJWT.Context
{
    public class JwtDbContext : IdentityDbContext<User>
    {
        public JwtDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}