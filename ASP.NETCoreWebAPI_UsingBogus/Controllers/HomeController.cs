using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebAPI_UsingBogus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private List<User> users = Fakes.BogusFakeData.GetUsers(20);

        [HttpGet]
        public List<User> Get() //Get
        {
            return users;
        }
        [HttpGet("{id}")]
        public User GetUsers(int id)    //Select
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public User Post([FromBody] User user)   //Insert
        {
            users.Add(user);
            return user;
        }
        [HttpPut]   //Update
        public User Put([FromBody] User user)
        {
            var editUser = users.FirstOrDefault(x => x.Id == user.Id);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Address = user.Address;
            return user;
        }
        [HttpDelete]    //Delete
        public void Delete(int id)
        {
            var deletedUser = users.FirstOrDefault(x => x.Id == id);
            users.Remove(deletedUser);
        }
    }
}
