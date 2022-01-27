using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DSU21.Controllers
{
    public class VisitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
