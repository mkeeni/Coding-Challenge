using CareerHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repository
{
    internal interface ICareerHub
    {
        void Apply(int applicantID, string coverLetter, int jobID);
        List<Applicant> GetApplicants(int jobID);

        void postJob(int companyID, string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType);

        List<JobListing> GetJobs(int companyID);

        void CreateProfile(string firstName, string lastName, string email, string phone, string resume);

        void InsertCompany(Company company);

        List<JobListing> GetJobListings();

        List<Company> GetCompanies();

        List<Applicant> GetAllApplicants();

        List<JobApplication> GetApplicationsForJob(int jobID);

        List<JobListing> GetJobListingsWithinRange(decimal l, decimal h);
    }
}
