using CareerHub.Service;

namespace CareerHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CareerHubServiceImpl service = new CareerHubServiceImpl();
            //service.ApplyS();
            //service.GetApplicantsS();
            //service.postJobS();
            //service.GetJobsS();
            //service.CreateProfileS();
            //service.InsertCompanyS();
            //service.GetJobListingsS();
            //service.GetAllApplicantsS();
            //service.GetApplicationsForJobsS();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Apply");
                Console.WriteLine("2. Get Applicants");
                Console.WriteLine("3. Post Job");
                Console.WriteLine("4. Get Jobs");
                Console.WriteLine("5. Create Profile");
                Console.WriteLine("6. Insert Company");
                Console.WriteLine("7. Get Job Listings");
                Console.WriteLine("8. Get Companies");
                Console.WriteLine("9. Get All Applicants");
                Console.WriteLine("10. Get Applications for Job");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice (0-10): ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        service.ApplyS();
                        break;
                    case 2:
                        service.GetApplicantsS();
                        break;
                    case 3:
                        service.postJobS();
                        break;
                    case 4:
                        service.GetJobsS();
                        break;
                    case 5:
                        service.CreateProfileS();
                        break;
                    case 6:
                        service.InsertCompanyS();
                        break;
                    case 7:
                        service.GetJobListingsS();
                        break;
                    case 8:
                        service.GetCompaniesS();
                        break;
                    case 9:
                        service.GetAllApplicantsS();
                        break;
                    case 10:
                        service.GetApplicationsForJobsS();
                        break;
                    case 0:
                        Console.WriteLine("Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 10.");
                        break;
                }
            }
    }
}
