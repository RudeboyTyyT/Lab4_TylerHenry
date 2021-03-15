//Author: Tyler Henry
//Last Modified: March 14 2021
//Title: Lab 4 Constructor
//Description: Creates constructors for cars object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_TylerHenry
{
    /// <summary>
    /// Class to store individual car information as objects
    /// </summary>
    class Cars
    {
        //Static variables to hold each car's information
        private static int carCount = 0;
        private int carIdentificationNumber = 0;
        private string carMake = String.Empty;
        private string carModel = String.Empty;
        private int carYear = 0;
        private decimal carPrice = 0;
        private bool carNewStatus = false;

        /// <summary>
        /// Deafault Constructor - creates new car object
        /// </summary>
        public Cars()
        {
            //Increments car counter
            carCount += 1;
            carIdentificationNumber = carCount;
        }

        /// <summary>
        /// Parameterized Constructor - creates a new car object
        /// </summary>
        /// <param name="make">Car's Make</param>
        /// <param name="model">Car's Model</param>
        /// <param name="year">Car's Year</param>
        /// <param name="price">Car's Price</param>
        /// <param name="newStatus">true if a car is new</param>
        public Cars (string make, string model, int year, decimal price, bool newStatus) : this()
        {
           

            //Set instance variables to variables passed into constructor
            carMake = make;
            carModel = model;
            carYear = year;
            carPrice = price;
            carNewStatus = newStatus;
        }
        /// <summary>
        /// Count ReadOnly Property - Gets the number of cars that have been instantiated/created
        /// </summary>
        public int Count
        {
            get
            {
                return carCount;
            }
        }

        /// <summary>
        /// IdentificationNumber ReadOnly Property - Gets a specific cars' identification number
        /// </summary>
        public int IdentificationNumber
        {
            get
            {
                return carIdentificationNumber;
            }
        }

        /// <summary>
        /// NewStatus Property - >Gets and Sets the New Status of a car
        /// </summary>
        public bool NewStatus
        {
            get
            {
                return carNewStatus;
            }
            set
            {
                
                carNewStatus = value;
            }
        }

        /// <summary>
        /// Make property - Gets and Sets the make of a car
        /// </summary>
        public string Make
        {
            get
            {
                return carMake;
            }
            set
            {
                carMake = value;
            }
        }

        /// <summary>
        /// Model property - Gets and Sets the model of a car
        /// </summary>
        public string Model
        {
            get
            {
                return carModel;
            }
            set
            {
                carModel = value;
            }
        }

        /// <summary>
        /// Year property - Gets and Sets the year of a car
        /// </summary>
        public int Year
        {
            get
            {
                return carYear;
            }
            set
            {
                carYear = value;
            }
        }
        /// <summary>
        /// Price property - Gets and Sets the price of a car
        /// </summary>
        public decimal Price
        {
            get
            {
                return carPrice;
            }
            set
            {
                carPrice = value;
            }
        }

        /// <summary>
        /// GetSalutation is a function that a salutation based on the private properties within the class scope
        /// </summary>
        /// <returns>string describing the customer</returns>
        public string GetSalutation()
        {
            return "This car is  " + (carNewStatus ? "a new" : "a used") + " " + carYear + " " + carMake 
                + " " + carModel + " and costs $" + carPrice;


        }
    }

   












}
