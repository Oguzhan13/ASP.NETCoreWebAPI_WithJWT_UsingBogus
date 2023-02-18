namespace ASP.NETCoreWebAPI_WithJWT.Options
{
    public class JwtOption
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public TimeSpan ExpiredTime { get; set; }
    }
}
