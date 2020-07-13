using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Certification.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Certification.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.InteropServices.ComTypes;

namespace Certification.Main.Controllers
{
    [Authorize(Roles = "professor")]
    public class CertificationProfController : Controller
    {
        public CertificationDbContext db;

        public CertificationProfController(CertificationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var login = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

             var teachings = db.Teaching.ToList().FindAll(t => t.LoginLecturer.Equals(login));
           
           
            db.LoadByListAndRef(teachings, "IdSubjectNavigation");
            ViewBag.Teachings = teachings;
            return View();
        }

        public IActionResult Months(int idSubject)
        {

           var subject = db.Subjects.Find(idSubject);
            db.Entry(subject).Collection("Certifications").Load();
            ViewBag.Certif = subject.Certifications;
            return View();
        }

        public IActionResult Groups(int idSubject, byte month)
        {

            var certifications = db.Certifications.ToList().FindAll(c => c.IdSubject == idSubject && c.CMonth == month);
            db.LoadByListAndRef(certifications, "NGroupNavigation");
            ViewBag.Certif = certifications;
            return View();
        }

        public IActionResult Students(int idCertif, string nGroup)
        {

            var group = db.Groups.Find(nGroup);
            db.Entry(group).Collection("Students").Load();
            db.Entry(group).Collection("Teaching").Load();
            db.LoadByListAndRef(group.Students, "LoginStudentNavigation");

            var certif = db.Certifications.Find(idCertif);
            db.Entry(certif).Reference("IdSubjectNavigation").Load();

            var teaching = group.Teaching.ToList().Find(t => t.NGroup.Equals(nGroup) && t.IdSubject == certif.IdSubject);
            db.Entry(teaching).Reference("IdSubjectNavigation").Load();

            ViewBag.Results = new List<Results>();
            foreach (var result in db.Results)
            {
                foreach (var student in group.Students)
                {
                    if (student.LoginStudent.Equals(result.LoginStudent))
                    {
                        ViewBag.Results.Add(result);
                    }
                }
            }
            ViewBag.Students = group.Students;
            ViewBag.IdCertif = idCertif;

            ViewBag.Subject = teaching.IdSubjectNavigation;
            return View();
        }
        public IActionResult Results(int idCertif, string loginStudent)
        {
            ViewBag.idCertif = idCertif;
            ViewBag.Login = loginStudent;
            var certif = db.Certifications.Find(idCertif);
            db.Entry(certif).Reference("IdSubjectNavigation").Load();
            ViewBag.SubjectType = certif.IdSubjectNavigation.SubjectType;

            List<SubjectType> subjectType = new List<SubjectType>
            {
                SubjectType.Незачет,
                SubjectType.Зачет
            };

            ViewBag.SelectList = new SelectList(subjectType);
            return View();
        }

        public IActionResult SaveResult(int idCertif, string login, bool markType, int mark, SubjectType selectListResult)
        {

            var searchResult = db.Results.ToList().Find(r => r.IdCertif == idCertif && r.LoginStudent.Equals(login));
            if (searchResult != null)
            {

                ViewBag.Status = false;
                ViewBag.RangeError = false;
            }
            else
            {
                var result = new Results() { IdCertif = idCertif, LoginStudent = login };
                if (markType)
                {
                    if (selectListResult == SubjectType.Незачет)
                    {
                        result.Mark = 0;
                    }
                    else if (selectListResult == SubjectType.Зачет)
                    {
                        result.Mark = 1;
                    }
                    ViewBag.Status = true;
                    ViewBag.RangeError = false;
                }

                else
                {
                    if (mark >= 0 && mark <= 100)
                    {
                        result.Mark = (byte)mark;
                        ViewBag.Status = true;
                        ViewBag.RangeError = false;
                    }
                    else
                    {
                        ViewBag.Status = false;
                        ViewBag.RangeError = true;
                    }
                }
                if (ViewBag.Status && !ViewBag.RangeError)
                {
                    db.Results.Add(result);
                    db.SaveChanges();
                }
            }

            ViewBag.User = db.Users.Find(login);
            return View();
        }
    }
}
