using Certification.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Certification.Data
{
    public interface IUniversityCertificationData
    {
        IEnumerable<Certifications> GetCertificationByGroup(string enteredStr);
        Certifications GetById(int id);

        IEnumerable<CustData> GetResults(string enteredStr);
    }
}
