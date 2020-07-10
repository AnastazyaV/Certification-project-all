using Certification.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Certification.Data
{
    public class SqlCertificationData : ICertificationData
    {
        private readonly CertificationDbContext db;
        public SqlCertificationData(CertificationDbContext db)
        {
            this.db = db;
        }
        public Certifications Add(Certifications newCerification)
        {
            db.Add(newCerification);
            return newCerification;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Certifications Delete(int id)
        {
            var certification = GetById(id);
            if (certification != null)
            {
                db.CertificationsOld.Remove(certification);
            }
            return certification;
        }

        public Certifications GetById(int id)
        {
            return db.CertificationsOld.Find(id);
        }

       public IEnumerable<Certifications> GetCertificationByGroup(string enteredStr)
        {
           var query= from c in db.CertificationsOld
                   where string.IsNullOrEmpty(enteredStr) || c.Group.ToString().StartsWith(enteredStr)
                   orderby c.Group
                   select c;
            return query;
        }
       
        public int GetCountOfCertifications()
        {
            return db.Certifications.Count();
        }

        public Certifications Update(Certifications updatedCertification)
        {
            var entity = db.CertificationsOld.Attach(updatedCertification);
            entity.State = EntityState.Modified;
            return updatedCertification;
        }
    }
}
