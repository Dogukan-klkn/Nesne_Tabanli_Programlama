using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonProffesor
{
    // Base class: Person
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public void PurchaseParkingPass()
        {
            // Logic to purchase a parking pass
        }
    }

    // Associated class: Address
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public bool Validate()
        {
            // Logic to validate the address
            return true;
        }

        public string OutputAsLabel()
        {
            return $"{Street}, {City}, {State}, {PostalCode}, {Country}";
        }
    }

    // Derived class: Student
    public class Student : Person
    {
        public int StudentNumber { get; set; }
        public int AverageMark { get; set; }

        public bool IsEligibleToEnroll(string course)
        {
            // Logic to check if eligible to enroll in a course
            return true;
        }

        public int GetSeminarsTaken()
        {
            // Logic to return the number of seminars taken
            return 0;
        }
    }

    // Derived class: Professor
    public class Professor : Person
    {
        public int Salary { get; set; }
        public int StaffNumber { get; set; }
        public int YearsOfService { get; set; }
        public int NumberOfClasses { get; set; }

        public void Supervise(Student student)
        {
            // Logic to supervise a student
        }
    }

    // Program class
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create Address instance
            Address address = new Address
            {
                Street = "123 Main St",
                City = "Springfield",
                State = "IL",
                PostalCode = 62701,
                Country = "USA"
            };

            // Create Student instance
            Student student = new Student
            {
                Name = "John Doe",
                PhoneNumber = "123-456-7890",
                EmailAddress = "john.doe@example.com",
                StudentNumber = 1001,
                AverageMark = 85
            };

            // Create Professor instance
            Professor professor = new Professor
            {
                Name = "Dr. Smith",
                PhoneNumber = "987-654-3210",
                EmailAddress = "dr.smith@example.com",
                Salary = 90000,
                StaffNumber = 2001,
                YearsOfService = 10,
                NumberOfClasses = 3
            };

            // Output Address label
            Console.WriteLine("Address Label: " + address.OutputAsLabel());

            // Check student eligibility
            Console.WriteLine($"Is {student.Name} eligible to enroll? {student.IsEligibleToEnroll("Math 101")}");

            // Professor supervises the student
            professor.Supervise(student);
            Console.WriteLine($"{professor.Name} is now supervising {student.Name}.");
            Console.ReadLine();
        }
    }

}
