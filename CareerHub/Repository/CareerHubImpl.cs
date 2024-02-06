using CareerHub.Models;
using CareerHub.Utility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace CareerHub.Repository
{
    internal class CareerHubImpl:ICareerHub
    {
  

        
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;

        public CareerHubImpl()
        {

            sqlconnection = new SqlConnection(DBConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void Apply(int applicantID,string coverLetter,int jobID)
        {
            try
            {
                sqlconnection.Open();

                cmd.CommandText = "INSERT INTO Applications VALUES (@JobID, @ApplicantID,GetDate(), @CoverLetter)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@JobID", jobID);
                cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                cmd.Parameters.AddWithValue("@CoverLetter", coverLetter);

                int applicationStatus = cmd.ExecuteNonQuery();
                if (applicationStatus > 0)
                {
                    Console.WriteLine("Application successful.");

                }
                else
                {
                    Console.WriteLine("Error.Application unsuccessful..");
                }
                sqlconnection.Close();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public List<Applicant> GetApplicants(int jobID)
        { 
            List<Applicant> applicantList = new List<Applicant>();

            try
            {
                cmd.CommandText = "select * from Applicants where ApplicantID in (select distinct ApplicantID from Applications where jobID=@jobID);";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@jobID", jobID);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Applicant applicant = new Applicant();
                    applicant.ApplicantID = (int)reader["applicantID"];
                    applicant.FirstName = (string)reader["Firstname"];
                    applicant.LastName = (string)reader["Lastname"];
                    applicant.Email = (string)reader["email"];
                    applicant.Phone = (string)reader["phone"];
                    applicant.Resume = (string)reader["resume"];
                    applicantList.Add(applicant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();


            return applicantList;

        }

        public void postJob(int companyID,string jobTitle,string jobDescription,string jobLocation,decimal salary,string jobType)
        {
            try
            {
                sqlconnection.Open();

                cmd.CommandText = "INSERT INTO Jobs VALUES (@CompanyID, @jobTitle,@jobDescription,@jobLocation,@salary,@jobType,GetDate())";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                cmd.Parameters.AddWithValue("@jobLocation", jobLocation);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@jobType", jobType);
                int postingStatus = cmd.ExecuteNonQuery();
                if (postingStatus > 0)
                {
                    Console.WriteLine("Job posted successfully.");

                }
                else
                {
                    Console.WriteLine("Error.Job not posted.");
                }
                sqlconnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public List<JobListing> GetJobs(int companyID)
        { 
            List<JobListing > jobs = new List<JobListing>();
            try
            {
                cmd.CommandText = "select * from Jobs where CompanyID=@CompanyID;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CompanyID",companyID );
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobListing job = new JobListing();
                    Company company = new Company();
                    company.CompanyID = (int)reader["CompanyID"];
                    job.JobID = (int)reader["jobID"];
                    job.Company = company;
                    job.JobLocation = (string)reader["JobLocation"];
                    job.PostedDate = (DateTime)reader["PostedDate"];
                    job.Salary = (decimal)reader["salary"];
                    job.JobDescription = (string)reader["JobDescription"];
                    job.JobTitle = (string)reader["JobTitle"];
                    job.JobType = (string)reader["JobType"];
                    
                    jobs.Add(job);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();


            return jobs;
        }

        public void CreateProfile(string firstName,string lastName,string email,string phone,string resume)
        {
            try
            {
                sqlconnection.Open();

                cmd.CommandText = "INSERT INTO Applicants VALUES (@firstName, @lastName,@email,@phone,@resume)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@resume", resume);
                cmd.Parameters.AddWithValue("@phone", phone);
                int createProfileStatus = cmd.ExecuteNonQuery();
                if (createProfileStatus > 0)
                {
                    Console.WriteLine("Applicant added.");

                }
                else
                {
                    Console.WriteLine("Error.Applicant not added.");
                }
                sqlconnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void InsertCompany(Company company)
        {

            try
            {
                sqlconnection.Open();

                cmd.CommandText = "INSERT INTO Companies VALUES (@companyName, @location)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@companyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@location", company.Location);
                int addCompanyStatus = cmd.ExecuteNonQuery();
                if (addCompanyStatus > 0)
                {
                    Console.WriteLine("Company added successfully.");

                }
                else 
                {
                    Console.WriteLine("Error.Company not added.");
                }

                sqlconnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public List<JobListing> GetJobListings()
        {

            List<JobListing> jobs = new List<JobListing>();
            try
            {
                cmd.CommandText = "select * from Jobs;";
                cmd.Parameters.Clear();
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobListing job = new JobListing();
                    Company company = new Company();
                    company.CompanyID = (int)reader["CompanyID"];
                    job.JobID = (int)reader["jobID"];
                    job.Company = company;
                    job.JobLocation = (string)reader["JobLocation"];
                    job.PostedDate = (DateTime)reader["PostedDate"];
                    job.Salary = (decimal)reader["salary"];
                    job.JobDescription = (string)reader["JobDescription"];
                    job.JobTitle = (string)reader["JobTitle"];
                    job.JobType = (string)reader["JobType"];

                    jobs.Add(job);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();


            return jobs;
        }

        public List<Company> GetCompanies()
        { 
            List<Company> companies = new List<Company>();
            try
            {
                cmd.CommandText = "select * from Companies;";
                cmd.Parameters.Clear();
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company company = new Company();
                    company.CompanyID = (int)reader["CompanyID"];
                    company.CompanyName = (string)reader["CompanyName"];
                    company.Location = (string)reader["Location"];

                    companies.Add(company);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();


            return companies;
        }

        public List<Applicant> GetAllApplicants()
        { 
            List<Applicant> applicants = new List<Applicant>();
            try
            {
                cmd.CommandText = "select * from Applicants;";
                cmd.Parameters.Clear();
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Applicant applicant = new Applicant();
                    applicant.ApplicantID = (int)reader["applicantID"];
                    applicant.FirstName = (string)reader["Firstname"];
                    applicant.LastName = (string)reader["Lastname"];
                    applicant.Email = (string)reader["email"];
                    applicant.Phone = (string)reader["phone"];
                    applicant.Resume = (string)reader["resume"];
                    applicants.Add(applicant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();


            return applicants;
        }

        public List<JobApplication> GetApplicationsForJob(int jobID)
        {
            List<JobApplication> applications = new List<JobApplication>();

            try
            {
                cmd.CommandText = "select * from Applications where jobID=@jobID;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("jobID", jobID);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobApplication application = new JobApplication();
                    application.ApplicationID = (int)reader["applicationID"];
                    JobListing jobListing = new JobListing();
                    jobListing.JobID = (int)reader["jobID"];
                    Applicant applicant = new Applicant();
                    applicant.ApplicantID = (int)reader["applicantID"];
                    application.ApplicationDate = (DateTime)reader["ApplicationDate"];
                    application.CoverLetter = (string)reader["CoverLetter"];
                    application.Applicant = applicant;
                    application.JobListing = jobListing;
                    applications.Add(application);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();

            return applications;

        }
        
        public List<JobListing> GetJobListingsWithinRange(decimal l,decimal h)
        {

            List<JobListing> jobs = new List<JobListing>();
            try
            {
                cmd.CommandText = "select * from Jobs where Salary>=@l and salary<=@h;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@l",l);
                cmd.Parameters.AddWithValue("@h",h);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobListing job = new JobListing();
                    Company company = new Company();
                    company.CompanyID = (int)reader["CompanyID"];
                    job.JobID = (int)reader["jobID"];
                    job.Company = company;
                    job.JobLocation = (string)reader["JobLocation"];
                    job.PostedDate = (DateTime)reader["PostedDate"];
                    job.Salary = (decimal)reader["salary"];
                    job.JobDescription = (string)reader["JobDescription"];
                    job.JobTitle = (string)reader["JobTitle"];
                    job.JobType = (string)reader["JobType"];

                    jobs.Add(job);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            sqlconnection.Close();


            return jobs;
        }
    }
}
