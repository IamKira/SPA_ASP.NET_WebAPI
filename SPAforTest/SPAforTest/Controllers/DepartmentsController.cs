using System.Collections.Generic;
using System.Web.Http;
using SPAforTest.Models;

namespace SPAforTest.Controllers
{
    public class DepartmentsController : ApiController
    {
        private UserRepository repo = UserRepository.Current;
        public IEnumerable<Department> GetDepartments()
        {
            return repo.GetDepartments();
        }
    }
}