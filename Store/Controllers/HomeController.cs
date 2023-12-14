using Microsoft.AspNetCore.Mvc;
using Store.API;
using Store.Entitis;
using Store.Models;
using System.Diagnostics;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreDbContext context;

        public HomeController(StoreDbContext context)
        {
           
            this.context = context;
        }

        public IActionResult Index()
        {
            var userapi = new UserApiService(context);
            // var data = userapi.GetAllUsers();
            //userapi.AddUser(new AddUserInput
            //{
            //    FirstName = "کتایون",
            //    FamilyName = "خیرآبادی",
            //    UserName = "2282961862",
            //    Password = "2282961862",
            //    NationalCode= "2282961862",
            //    BirthDate = DateTime.Now.Date,
            //    Gender=0,
            //    PhoneNumber="09199384815",
            //    RoleId = 1
            //});
            //userapi.UpdateUser(new UpdateUserInput
            //{
            //    Id=4,
            //    PhoneNumber = "09199384815"
            //});
            //userapi.DeleteUser(6);
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult User()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult viewProduct()
        {
            return View();
        }
        public IActionResult aboutus()
        {
            return View();
        }
        public IActionResult contactus()
        {
            return View();
        }
        public IActionResult ourservices()
        {
            return View();
        }
        public IActionResult category()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult GetShowProductLike()
        {
            return View();
        }
        [Route("SingleProduct/{ProductId}")]
        public IActionResult SingleProduct(int ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}