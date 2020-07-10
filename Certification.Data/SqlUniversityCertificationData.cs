using Certification.Core;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace Certification.Data
{
    public class SqlUniversityCertificationData : IUniversityCertificationData
    {
        private readonly CertificationDbContext db;

        public SqlUniversityCertificationData(CertificationDbContext db)
        {
            this.db = db;
        }

        public Certifications GetById(int id)
        {
            return db.Certifications.Find(id);
        }

        public IEnumerable<Certifications> GetCertificationByGroup(string enteredStr)
        {
            var query = from c in db.Certifications
                        where string.IsNullOrEmpty(enteredStr) || c.NGroup.ToString().StartsWith(enteredStr)
                        orderby c.NGroup
                        select c;
            return query;
        }

        
        public IEnumerable<CustData> GetResults(string enteredStr)
        {
            var query = from sub in db.Subjects
                        join cert in db.Certifications on sub.IdSubject equals cert.IdSubject
                        join res in db.Results on cert.IdCertif equals res.IdCertif
                        where  res.LoginStudent.Contains(enteredStr)

                        select new CustData
                        {
                            Sub = sub.Name,
                            IdSert = cert.IdCertif,
                            DateCert = cert.CMonth,
                            Mark = res.Mark,
                            Login = res.LoginStudent,
                            Group = cert.NGroup
                           
                        };
                        

            return query;
                
                 //.where string.IsNullOrEmpty(enteredStr) || r.LoginStudent.StartsWith(enteredStr)
        }
    }
}
