namespace ASP.NETCoreWebAPI_UsingBogus.Fakes
{
    public class BogusFakeData
    {
        public static List<User> _users;
        public static List<User> GetUsers(int number)
        {
            if (_users == null)
            {
                _users = new Faker<User>()
                    .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                    .RuleFor(x => x.LastName, f => f.Name.LastName())
                    .RuleFor(x => x.Address, f => f.Address.FullAddress())
                    .Generate(number);
            }
            return _users;
        }
    }
}
