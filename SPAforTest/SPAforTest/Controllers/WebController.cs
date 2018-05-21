using System.Collections.Generic;
using System.Web.Http;
using SPAforTest.Models;

namespace SPAforTest.Controllers
{
    public class WebController : ApiController
    {
        private UserRepository repo = UserRepository.Current;
        public IEnumerable<UsersAndDep> GetUsers()
        {
            return repo.GetUsersAndDepartments();
        }
        
        public User GetUser(int id)
        {
            return repo.GetUser(id);
        }
        [HttpPost]
        public User AddUser(User user)
        {
            return repo.AddUser(user);
        }
        [HttpPut]
        public bool UpdateUser(User user)
        {
            return repo.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            repo.RemoveUser(id);
        }
    }
}