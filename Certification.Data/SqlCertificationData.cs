using Certification.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Certification.Data
{ /*
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
                //db.certificationsOld.Remove(certification);
            }
            return certification;
        }

        public Certifications GetById(int id)
        {
            //return db.certificationsOld.Find(id);
            return null;
        }
        
       public IEnumerable<Certifications> GetCertificationByGroup(string enteredStr)
        {
            return null;
            /*
           var query= from c in db.certificationsOld
                   where string.IsNullOrEmpty(enteredStr) || c.Group.ToString().StartsWith(enteredStr)
                   orderby c.Group
                   select c;
            return query;
           
        }
       
        public int GetCountOfCertifications()
        {
            return 0;
           // return db.certifications.Count();
        }

        public Certifications Update(Certifications updatedCertification)
        {
            return null;
           // var entity = db.certificationsOld.Attach(updatedCertification);
            //entity.State = EntityState.Modified;
            return updatedCertification;
        }
    }
*/
}
