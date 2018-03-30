using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable2_AnnaBaseley
{
    class Program
    {
        static void Main(string[] args)
        {
            //This pulls the information from the Date class.
            Date newDate = new Date();
            newDate.GetDatesfromUser();
            Console.ReadKey();
        }
    }
    class Date
    {
        static public DateTime birthDay, toDay;
        
        //This is where the program asks the user for two dates: their date of birth & the current date.
        public void GetDatesfromUser()
        {
            Console.WriteLine("Please enter your birthday (Month/Day/Year) and the time you were born (HH:MM PM/AM).");
            Console.WriteLine("If you don't know what time you were born, that's okay.  You can guess or leave it out.");

            string[] formats = 
                {
                //This string array allows the program to read a number of date variations from the user.
                "MM/dd/yyyy", "M/dd/yyyy", "M/d/yyyy", "MM/d/yyyy",
                "MM/dd/yy", "M/d/yy", "M/d/yy", "MM/d/yy",

                "MM/dd/yyyy h:mm", "M/dd/yyyy h:mm", "M/d/yyyy h:mm:ss", "MM/d/yyyy h:mm",
                "MM/dd/yy h:mm", "M/d/yy h:mm", "M/d/yy h:mm", "MM/d/yy h:mm",

                "MM/dd/yyyy h:m", "M/dd/yyyy h:m", "M/d/yyyy h:m", "MM/d/yyyy h:m",
                "MM/dd/yy h:m", "M/d/yy h:m", "M/d/yy h:m", "MM/d/yy h:m",

                "MM/dd/yyyy h:mm tt", "M/dd/yyyy h:mm tt", "M/d/yyyy h:mm tt", "MM/d/yyyy h:mm tt",
                "MM/dd/yy h:mm tt", "M/d/yy h:mm tt", "M/d/yy h:mm tt", "MM/d/yy h:mm tt",

                "MM/dd/yyyy h:m tt", "M/dd/yyyy h:m tt", "M/d/yyyy h:m tt", "MM/d/yyyy h:m tt",
                "MM/dd/yy h:m tt", "M/d/yy h:m tt", "M/d/yy h:m tt", "MM/d/yy h:m tt"

                };

            while (!DateTime.TryParseExact(Console.ReadLine(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birthDay))
            {
                Console.WriteLine("This does not appear to be in the right format.  Please try again.");
            }

            Console.WriteLine("Thank you! Now please give me today's date and the time. The computer will calculate how old you are in days!", birthDay);

            while (!DateTime.TryParseExact(Console.ReadLine(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out toDay))
            {
                Console.WriteLine("This does not appear to be in the right format.  Please try again.");
            }

            //This is where the computer subtracts the birthday from the current date.
            //It then relays that information to the user in days, hours, and minutes.
            TimeSpan dateDiff = toDay.Subtract(birthDay);
            Console.Write("You have been alive for {0} days, ", dateDiff.Days);
            Console.Write("{0} hours, ", dateDiff.Hours);
            Console.Write("and {0} minutes.", dateDiff.Minutes);
        }
    }
}
