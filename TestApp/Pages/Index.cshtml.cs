using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Model;
using TestApp.ViewModel;

namespace TestApp.Pages
{
    public class IndexModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;
        public IEnumerable<Employee> e;
        public IndexModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        } 

        public void OnGet()
        {

            this.e = _employeeRepository.GetAllEmployees();
            ViewData["PageTitle"] = "Employee Details";
            ViewData["Rows"] = "2";
            ViewData["Columns"] = "4";
        }

  

    }
}
