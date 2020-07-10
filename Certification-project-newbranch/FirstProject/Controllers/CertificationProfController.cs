using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Certification.Main.Controllers
{
    [Authorize(Roles = "professor")]
    public class CertificationProfController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
