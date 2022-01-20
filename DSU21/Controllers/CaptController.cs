using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21.Controllers
{
    public class CaptController : Controller
    {
       // [Authorize(Roles = "Captain")]
        [Authorize(Policy = "CaptainsOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
