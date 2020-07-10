using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Certification.Core;
using Certification.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Certification.Main.Pages.Student
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IUniversityCertificationData certificationData;
       [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public string Message { get; set; }
        public IEnumerable<Certifications> certifications { get; set; }
        public IEnumerable<CustData> results;
        public ListModel(IConfiguration config, IUniversityCertificationData certificationData)
        {
            this.config = config;
            this.certificationData = certificationData;

        }
        public void OnGet()
        {

            string name = HttpContext.User.Identity.Name;
            Message = config["Message"];
            certifications = certificationData.GetCertificationByGroup(SearchTerm);
            results = certificationData.GetResults(name);
            
        }
    }
}
