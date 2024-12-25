using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetailed
{
    using System;
    using System.Collections.Generic;

    namespace CarRentalSystem
    {
        class Transaction
        {
            private int id;
            private string name;
            private string date;
            private string address;

            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public string Date { get => date; set => date = value; }
            public string Address { get => address; set => address = value; }

            public void Update()
            {
                Console.WriteLine("Transaction updated.");
            }
        }

        class Customer
        {
            private int id;
            private string name;
            private string contact;
            private string address;
            private int payment;

            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public string Contact { get => contact; set => contact = value; }
            public string Address { get => address; set => address = value; }
            public int Payment { get => payment; set => payment = value; }

            public void Update()
            {
                Console.WriteLine("Customer details updated.");
            }
        }

        class Car
        {
            private int id;
            private string details;
            private string orderType;

            public int Id { get => id; set => id = value; }
            public string Details { get => details; set => details = value; }
            public string OrderType { get => orderType; set => orderType = value; }

            public void ProcessDebit()
            {
                Console.WriteLine("Debit processed for car.");
            }
        }

        class RentingOwner
        {
            private int id;
            private string name;
            private string age;
            private string contactNum;
            private string password;

            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public string Age { get => age; set => age = value; }
            public string ContactNum { get => contactNum; set => contactNum = value; }
            public string Password { get => password; set => password = value; }

            public void VerifyAccount()
            {
                Console.WriteLine("Account verified.");
            }
        }

        class Payment
        {
            private int id;
            private int cardNumber;
            private int amount;

            public int Id { get => id; set => id = value; }
            public int CardNumber { get => cardNumber; set => cardNumber = value; }
            public int Amount { get => amount; set => amount = value; }

            public void Add()
            {
                Console.WriteLine("Payment added.");
            }

            public void Update()
            {
                Console.WriteLine("Payment updated.");
            }
        }

        class Rentals
        {
            private int id;
            private string name;
            private string price;

            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public string Price { get => price; set => price = value; }

            public void Add()
            {
                Console.WriteLine("Rental record added.");
            }
        }

        class Reservation
        {
            private int id;
            private string details;
            private string list;

            public int Id { get => id; set => id = value; }
            public string Details { get => details; set => details = value; }
            public string List { get => list; set => list = value; }

            public void Confirmation()
            {
                Console.WriteLine("Reservation confirmed.");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Car Rental System initialized.");
            }
        }
    }

}
