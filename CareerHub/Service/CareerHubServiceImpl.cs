using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Models;
using CareerHub.Repository;

namespace CareerHub.Service
{
    internal class CareerHubServiceImpl
    {
        readonly ICareerHub _careerHub;

        public CareerHubServiceImpl()
        {
            _careerHub = new CareerHubImpl();
        }
        public void ApplyS()
        {
            
            Console.WriteLine("Enter Applicant ID: ");
            int applicantID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Job ID: ");
            int jobID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Cover Letter: ");
            string coverLetter = Console.ReadLine();

            _careerHub.Apply(applicantID,coverLetter,jobID);

        }

        public void GetApplicantsS()
        { 
            List<Applicant> applicantList=new List<Applicant>();
            Console.WriteLine("Enter Job ID: ");
            int jobID = int.Parse(Console.ReadLine());  

            applicantList = _careerHub.GetApplicants(jobID);

            foreach (var applicant in applicantList)
            {
                Console.WriteLine($"\nApplicant ID: {applicant.ApplicantID}\t First Name: {applicant.FirstName}\t Last Name: {applicant.LastName}\t Email: {applicant.Email}\t Phone: {applicant.Phone}\t Resume:{applicant.Resume}");

            }

        }

        public void postJobS()
        {
            Console.Write("Enter Company ID: ");
            int companyID = int.Parse(Console.ReadLine());

            
            Console.Write("Enter Job Title: ");
            string jobTitle = Console.ReadLine();

            
            Console.Write("Enter Job Description: ");
            string jobDescription = Console.ReadLine();

           
            Console.Write("Enter Job Location: ");
            string jobLocation = Console.ReadLine();

            
            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Job Type(Full-time,Part-time,Contract): ");
            string jobType = Console.ReadLine();

            _careerHub.postJob(companyID, jobTitle, jobDescription, jobLocation, salary, jobType);

        }

        public void GetJobsS()
        { 
            List<JobListing> jobs=new List<JobListing>();
            Console.WriteLine("Enter company ID:");
            int companyID = int.Parse(Console.ReadLine());

            jobs = _careerHub.GetJobs(companyID);


            foreach (var job in jobs)
            {
                Console.WriteLine($"\nApplicant ID: {job.JobID}\t Job Description: {job.JobDescription}\t Title: {job.JobTitle}\t Location: {job.JobLocation}\t Salary: {job.Salary}\t Job Type:{job.JobType}\t Posted Date:{job.PostedDate}");

            }

        }

        public void CreateProfileS()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Resume: ");
            string resume = Console.ReadLine();

            _careerHub.CreateProfile( firstName, lastName, email, phone, resume);
        }

        public void InsertCompanyS()
        { 
            Company company = new Company();
            Console.WriteLine("Enter Company Name:");
            company.CompanyName = Console.ReadLine();
            Console.WriteLine("Enter location:");
            company.Location = Console.ReadLine();
            
            _careerHub.InsertCompany( company );
        }

        public void GetJobListingsS()
        {

            List<JobListing> jobs = new List<JobListing>();
         

            jobs = _careerHub.GetJobListings();


            foreach (var job in jobs)
            {
                Console.WriteLine($"\nApplicant ID: {job.JobID}\t Job Description: {job.JobDescription}\t Title: {job.JobTitle}\t Location: {job.JobLocation}\t Salary: {job.Salary}\t Job Type:{job.JobType}\t Posted Date:{job.PostedDate}");

            }
        }

        public void GetCompaniesS()
        { 
            List<Company> companies = new List<Company>();

            companies = _careerHub.GetCompanies();

            foreach (var company in companies)
            {
                Console.WriteLine($"\nCompany ID: {company.CompanyID}\t Company Name: {company.CompanyName}\t Location: {company.Location}");

            }

        }

        public void GetAllApplicantsS()
        {
            List<Applicant> applicants = new List<Applicant>();
            applicants = _careerHub.GetAllApplicants();

            foreach (var applicant in applicants)
            {
                Console.WriteLine($"\nApplicant ID: {applicant.ApplicantID}\t First Name: {applicant.FirstName}\t Last Name: {applicant.LastName}\t Email: {applicant.Email}\t Phone: {applicant.Phone}\t Resume:{applicant.Resume}");
            }
        }

        public void GetApplicationsForJobsS()
        {
            Console.WriteLine("Enter JobID: ");
            int jobID = int.Parse(Console.ReadLine());

            List<JobApplication> jobApplications= new List<JobApplication>();

            jobApplications = _careerHub.GetApplicationsForJob(jobID);

            foreach (var applications in jobApplications)
            {
                Console.WriteLine($"\nApplication ID: {applications.ApplicationID}\t Job ID: {applications.JobListing.JobID}\t ApplicantID: {applications.Applicant.ApplicantID}\t Date: {applications.ApplicationDate}\t Cover Letter:{applications.CoverLetter}");
            }

        }


    }
}
