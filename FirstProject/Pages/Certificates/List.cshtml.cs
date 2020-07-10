using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Certification.Core;
using Certification.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Certification.Main.Pages.Certificates
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICertificationData certificationData;
       [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public string Message { get; set; }
        public IEnumerable<Certification.Core.Certifications> certifications { get; set; }
        public ListModel(IConfiguration config, ICertificationData certificationData)
        {
            this.config = config;
            this.certificationData = certificationData;
        }
        public void OnGet()
        {
     
            Message = config["Message"];
            certifications = certificationData.GetCertificationByGroup(SearchTerm);
        }
    }
}
