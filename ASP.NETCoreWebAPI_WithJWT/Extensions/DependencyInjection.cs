namespace ASP.NETCoreWebAPI_WithJWT.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JwtDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Default")));
            services.Configure<JwtOption>(configuration.GetSection("Jwt"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["Jwt:Issuer"],                                                          // Take Issuer value in Jwt
                        ValidAudience = configuration["Jwt:Audience"],                                                      // Take Audience value in Jwt
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),   // Take Secret value in Jwt
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<JwtDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IJwtService, JwtService>();
            // AddController(), AddEndpointsApiExplorer() and Add.SwaggerGen() methods move to AddApiServices() method from Program.cs class
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
