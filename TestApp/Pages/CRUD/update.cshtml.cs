using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Model;

namespace TestApp.Pages.CRUD
{
    public class updateModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;
        public Employee e;
        public updateModel(IEmployeeRepository employeeRepository)
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

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            FileInfo fileInfo = new FileInfo(em.FilePath.FileName);
            string fileName = em.FilePath.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                em.FilePath.CopyTo(stream);
            }


            // Convert the file into binary array

            FileStream fs = new FileStream(fileNameWithPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            em.photo = bytes;
            this.e = em;
                //_employeeRepository.Update(em);
           
            Response.Redirect("/");

        }
    }
}
