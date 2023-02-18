namespace ASP.NETCoreWebAPI_WithJWT.Services.Concretes
{
    public class JwtService : IJwtService
    {
        private readonly JwtOption _jwtOption;
        public JwtService(IOptions<JwtOption> options)
        {
            _jwtOption = options.Value;
        }
        public string GetJwtToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  //Token Id -> every turn give Guid value for Jwt Id
            };
            var encodedKey = Encoding.UTF8.GetBytes(_jwtOption.Secret);     //Encoding Secret in Jwt
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _jwtOption.Issuer, audience: _jwtOption.Audience, claims: claims, expires: DateTime.Now.Add(_jwtOption.ExpiredTime), signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}