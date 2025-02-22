using ASP.NETCoreMVCByLaxmiBhattarai.DAO;
using ASP.NETCoreMVCByLaxmiBhattarai.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreMVCByLaxmiBhattarai.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        public MyAppDBContext _context;

        public StudentController(MyAppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllData()
        {

            List<Student> std = _context.Students.ToList();

            if (std == null)
            {

                return Json(new
                {
                    success = false,
                    message = "Data not found!"
                });

            }
            else
            {
                return Json(new
                {
                    success = true,
                    data = std
                });
            }

        }

        [HttpGet]
        public JsonResult Create(string name, string address, int age, string department, string email)
        {



            Student std = new Student()
            {
                Name = name,
                Address = address,
                Age = age,
                Department = department,
                Email = email
            };

            if (std == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Unable to data insert!!"

                });
            }
            else
            {
                _context.Students.Add(std);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Data inserted Sucessfully!!"

                });

            }


        }



        [HttpGet]
        public JsonResult Update(string name, string address, int age, string department, string email, int id)
        {
            Student std = _context.Students.Where(x => x.Sid == id).FirstOrDefault();

            if (std == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Data not found!!"
                });

            }
            else
            {
                std.Name = name;
                std.Address = address;
                std.Age = age;
                std.Department = department;
                std.Email = email;
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data updated sucessfully!!"
                });
            }


        }





        [HttpGet]
        public JsonResult GetDataById(int id)
        {
            Student data = _context.Students.Where(x => x.Sid == id).FirstOrDefault();

            return Json(new
            {
                success = true,
                data = data
            });
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var removeData = _context.Students.Where(x => x.Sid == id).FirstOrDefault();

            if (removeData == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Data Not Found!!"
                });
            }
            else
            {
                _context.Students.Remove(removeData);
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data Deleted Sucessfully!!"
                });
            }


        }


        [HttpGet]
        public JsonResult GetAllEmail()
        {
            var email = _context.Students.Select(s => s.Email).ToList();

            if (email == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Data not found!!"

                });
            }
            else
            {
                return Json(new
                {
                    success = true,
                    data = email
                });
            }


        }
    }
}
