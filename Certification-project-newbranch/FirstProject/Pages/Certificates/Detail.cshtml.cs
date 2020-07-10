using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Certification.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Certification.Data;

namespace Certification.Main.Pages.Certificates
{
    public class DetailModel : PageModel
    {
        private readonly ICertificationData certificationData;
        [TempData]
        public string Message { get; set; }
        public Certifications Certification { get; set; }
       public DetailModel(ICertificationData certificationData)
        {
            this.certificationData = certificationData;
        }
        public IActionResult OnGet(int certificationId)
        {
            Certification = certificationData.GetById(certificationId);
            if(Certification == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}