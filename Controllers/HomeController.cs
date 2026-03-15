using System.Diagnostics;
using EntityFrame.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext context;//3. database work only use

        public HomeController(ILogger<HomeController> logger,SchoolContext context)//1.->server database connection objcet
        {
            _logger = logger;
            this.context = context;//2.
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
           
        {
            List<Student> students= context.Students.ToList();
            return View(students);
        }
        public IActionResult Details(int? Id)

        {
            if (Id != null) {
                Student st = context.Students.FirstOrDefault(item=>item.Id==Id);
                if (st != null)
                {
                    return View(st);
                }
                else {
                    TempData["message"] = "Record not found" + Id;
                    return RedirectToAction("List");
                }
            }
            TempData["message"] = "please enter the id" + Id;

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid) {
                try {
                    context.Students.Add(stu);//ram server store

                    context.SaveChanges();//database have saved 
                    TempData["success"] = "data insert successfully";
                        }
                catch {
                    TempData["message"] = "please check the valid id";
                }
                return RedirectToAction("List");
            }
            return View(stu);
        }
        
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                Student stu = context.Students.FirstOrDefault(item => item.Id == Id);
                if (stu!=null)
                {
                    return View(stu);

                }
                else
                {
                    TempData["message"] = "please chek the id....." + Id;
                    return RedirectToAction("List");
                }



            }
            TempData["message"] = "please give the correct id....." + Id;

            return RedirectToAction("List");

        }
        [HttpPost]
        public IActionResult delete(Student stu)
        {
            if (stu!=null) {
                context.Students.Remove(stu);
                context.SaveChanges();
                TempData["success"] = "data successfully changes......";
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? Id) 
        {
            if (Id!=null)
             {
                Student stu = context.Students.FirstOrDefault(item => item.Id == Id);

                if (stu!=null)
                { 
                return View(stu);
                }
           
            else {
                return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");

        }
        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            if (stu != null)
            {
                context.Students.Update(stu);
                context.SaveChanges();
                TempData["success"] = "data successfully update......";

            }
            
            return RedirectToAction("List");
         }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
