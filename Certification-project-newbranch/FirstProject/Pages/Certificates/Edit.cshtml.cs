using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Certification.Core;
using Certification.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Certification.Main.Pages.Certificates
{
    public class EditModel : PageModel
    {
        private readonly ICertificationData certificationData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Certifications Certification { get; set; }
        public IEnumerable<SelectListItem> Groups{ get; set; }
        public EditModel(ICertificationData certificationData,
            IHtmlHelper htmlHelper)
        {
            this.certificationData = certificationData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? certificationId)
        {
            Groups = htmlHelper.GetEnumSelectList<GroupsType>();
            if (certificationId.HasValue)
            {
                Certification = certificationData.GetById(certificationId.Value);

            }
            else
            {
                Certification = new Core.Certifications();
            }
                if(Certification == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Groups = htmlHelper.GetEnumSelectList<GroupsType>();
                return Page();
            }
            if (Certification.Id > 0)
            {
                certificationData.Update(Certification);
            }
            else
            {
                certificationData.Add(Certification);
            }
                certificationData.Commit();
            TempData["Message"] = "Changes in editing saved";
                return RedirectToPage("./Detail", new { certificationId = Certification.Id});
            
           
        }

    }
}