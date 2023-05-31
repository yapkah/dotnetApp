using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Model;
namespace TestApp.Pages.CRUD
{
    public class deleteModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;
        public Employee e;
        public deleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void OnGet(int id)
        {
            this.e = _employeeRepository.GetEmployee(id);
        }
     
        [HttpPost]
        public void OnPost(Employee em)
        {
            this.e = em;
            _employeeRepository.Delete(em.Id);
            Response.Redirect("/");

        }


    }
}
