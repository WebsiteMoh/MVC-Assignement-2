using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class Doctor : Controller
    {
        class Doctors
        {
         public   Doctors(int Id,String name)
            {
                ID=Id;
                Name=name;
            }
            int ID { get; set; }
            String Name { get; set; }
        }
           
        public ActionResult Index()
        {
           
            return View();
        }

      
        }
    }

