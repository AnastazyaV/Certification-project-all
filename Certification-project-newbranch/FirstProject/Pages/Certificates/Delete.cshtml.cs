using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Certification.Core;
using Certification.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Certification.Main.Pages.Certificates
{
    public class DeleteModel : PageModel
    {
        private readonly ICertificationData certificationData;
        public Certifications Certification { get; set; }
        public DeleteModel(ICertificationData certificationData)
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
        public IActionResult OnPost(int certificationId)
        {
            var certification = certificationData.Delete(certificationId);
            certificationData.Commit();
            if (certification == null)
            {
                return RedirectToPage("./NotFound");
            }
            //TempData["Message"] = $"{certification.Group} deleted";
            TempData["Message"] = $"certification deleted";
            return RedirectToPage("./List");
        }
    }
}