using Certification.Core;
using System;
using System.Collections.Generic;

using System.Linq;

namespace Certification.Data
{ /*
    public class InMemoryCertificationData : ICertificationData
    {
        List<Certifications> certifications;
            public InMemoryCertificationData()
        {
            certifications = new List<Certifications>()
            {
                //new Certifications {Id = 1,NameOfProfessor= "Willing", DateOfCertification=DateTime.Now, Group=GroupsType.Group3},
               // new Certifications {Id = 2, NameOfProfessor= "Will", DateOfCertification=DateTime.Now, Group=GroupsType.Group4}
            };
        }
       // public Certifications GetById(int id)
        {
            //return certifications.SingleOrDefault(c => c.Id == id);
        }
        public Certifications Add(Certifications newCertification)
        {
            certifications.Add(newCertification);
            newCertification.Id = certifications.Max(c => c.Id) + 1;
            return newCertification;
        }
        public Certifications Update(Certifications updatedCertification)
        {
            var certification = certifications.SingleOrDefault(c => c.Id == updatedCertification.Id);
            if(certification != null)
            {
                certification.NameOfProfessor = updatedCertification.NameOfProfessor;
                certification.DateOfCertification = updatedCertification.DateOfCertification;
                certification.Group = updatedCertification.Group;
            }
            return certification;
        }
        
        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Certifications> GetCertificationByGroup(string enteredStr)
        {
            return from c in certifications
                   where string.IsNullOrEmpty(enteredStr) || c.Group.ToString().StartsWith(enteredStr)
                   orderby c.DateOfCertification
                   select c;
        }

        public Certifications Delete(int id)
        {
            var certification = certifications.FirstOrDefault(c => c.Id == id);
            if (certification != null)
            {
                certifications.Remove(certification);
            }
            return certification;
        }

        public int GetCountOfCertifications()
        {
            return certifications.Count();
        }
    }

*/
}