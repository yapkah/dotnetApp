using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Model;

namespace TestApp.Pages.CRUD
{
    public class detailsModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;
        public Employee e;
        public detailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void OnGet(int id)
        {
            this.e = _employeeRepository.GetEmployee(id);

        }
        [HttpPost]
        public void OnPost(Employee ep)
        {
            this.e = _employeeRepository.GetEmployee(ep.Id);
            Response.Redirect("/");

        }
    }
}
