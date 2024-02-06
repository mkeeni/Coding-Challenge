using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CareerHub.Models
{
    internal class Applicant
    {
        private int applicantID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string resume;


        public Applicant() { }

        public Applicant(int applicantID, string firstName, string lastName, string email, string phone, string resume)
        {
            ApplicantID = applicantID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Resume = resume;
        }

        public int ApplicantID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Resume { get; set; }
    }
}
