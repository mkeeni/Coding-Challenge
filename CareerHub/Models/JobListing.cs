using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Models
{
    internal class JobListing
    {
        private int jobID;
        Company company; 
        private string jobTitle;
        private string jobLocation;
        private string jobDescription;
        private decimal salary;
        private string jobType;
        private DateTime postedDate;


        public JobListing() { }

        public JobListing(int jobID, string jobTitle, string jobLocation,string jobDescription,decimal salary,string jobType,DateTime postedDate,Company company)
        {
            JobID = jobID;
            JobTitle = jobTitle;
            JobLocation = jobLocation;
            JobDescription = jobDescription;
            Salary = salary;
            JobType = jobType;
            PostedDate = postedDate;
            Company = company;

        }

      public int JobID { get; set; }
        public Company Company { get; set; }
        public string JobTitle  { get; set; }

        public string JobLocation { get; set; }

        public string JobDescription { get; set; }

        public decimal Salary { get; set; }

        public string JobType { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
