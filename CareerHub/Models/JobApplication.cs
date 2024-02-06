using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CareerHub.Models
{
    internal class JobApplication
    {
        private int applicationID;
        JobListing jobListing;
        Applicant applicant;
        private DateTime applicationDate;
        private string coverLetter;

        public JobApplication() { }

        public JobApplication(int applicationID, JobListing jobListing,Applicant applicant,DateTime applicationDate,string coverLetter)
        {
            ApplicationID = applicationID;
            JobListing = jobListing;
            Applicant = applicant;
            ApplicationDate = applicationDate;
            CoverLetter = coverLetter;
        }

        public int ApplicationID { get; set; }
        public string CoverLetter { get; set; }

        public DateTime ApplicationDate { get; set; }

        public JobListing JobListing { get; set; }

        public Applicant Applicant { get; set; }

    }
}
