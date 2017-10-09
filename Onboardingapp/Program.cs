using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Onboardingapp;

namespace OnboardingApp
{
    class Onboarding
    {
        static void Main(string[] args)
        {
            var user = new User();

            Console.WriteLine("Hello there! Welcome to your Onboarding.");

            user.FirstName = AskQuestion("What is your first name?");
            Console.WriteLine("Thanks! Your first name is " + user.FirstName);

            user.LastName = AskQuestion("What is your last name?");
            Console.WriteLine("Great, Your full name is " + user.FirstName + " " + user.LastName);

            user.IsAccountOwner = AskBoolQuestion("Are you the account owner?");
            Console.WriteLine("Terrific! You are the Account Owner: " + user.IsAccountOwner);

            user.PinNumber = AskIntQuestion("What is your 4-digit pin?", 4);
            Console.WriteLine("Awesome! You entered: " + user.PinNumber);



            Console.ReadKey();
        }

        public static string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static bool AskBoolQuestion(string question)
        {
            var hasAnswered = false;
            var responseBool = false;

            while (!hasAnswered)
            {
                var response = AskQuestion(question + " (y/n)");

                if (response == "y")
                {
                    responseBool = true;
                    hasAnswered = true;
                }
                else if (response == "n")
                {
                    responseBool = false;
                    hasAnswered = true;
                }
            }
            return responseBool;
        }

        static string AskIntQuestion(string question, int limit)
        {
            String numberString = null;
            while (numberString == null)
            {
                var response = AskQuestion(question);

                int possibleResponse = 0;

                if (response.Length == limit && Int32.TryParse(response, out possibleResponse))
                {
                    numberString = response;
                }

            }

            return numberString;

        } 

        
    }  

}

