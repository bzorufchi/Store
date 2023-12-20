using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public string UploadFiles([FromForm]IFormFile file)
        {
            using var stream =  file.OpenReadStream();
            var destination = $"{Directory.GetCurrentDirectory()}\\wwwroot\\axstore\\{file.FileName}";
            using(var writer = new FileStream(destination,FileMode.OpenOrCreate))
            {
               stream.CopyTo(writer);
            }
            return file.FileName;
        }

    }
}
