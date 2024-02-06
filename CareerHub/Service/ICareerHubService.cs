using CareerHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Service
{
    internal interface ICareerHubService
    {
        void ApplyS();

        void GetApplicantsS();

        void postJobS();

        void GetJobsS();

        void CreateProfileS();


        void InsertCompanyS();

        void GetJobListingsS();

        void GetCompaniesS();

        void GetAllApplicantsS();

        void GetApplicationsForJobS();

        void GetJobListingsWithinRangeS();
    }
}
