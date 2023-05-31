using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Model;

namespace TestApp.Pages.CRUD
{
    public class insertModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;
   
        public insertModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void OnGet()
        {
        }

        [HttpPost]
        public void OnPost(Employee emp)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            FileInfo fileInfo = new FileInfo(emp.FilePath.FileName);
            string fileName = emp.FilePath.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                emp.FilePath.CopyTo(stream);
            }


            // Convert the file into binary array

            FileStream fs = new FileStream(fileNameWithPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            emp.photo = bytes;


            _employeeRepository.Add(emp);
            Response.Redirect("/");

        }

      







    }
}

