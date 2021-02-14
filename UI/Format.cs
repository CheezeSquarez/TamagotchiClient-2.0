using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiClient.UI
{
    abstract class Format
    {
        public static int GetIntFromString(string s)
        {
            int output;
            while(!int.TryParse(s, out output))
            {
                Console.WriteLine("Please enter numbers only!!!");
                s = Console.ReadLine();
            }
            return output;
        }

        public static string MakeFormattedDatestring(int[] date)
        {
            Console.WriteLine("Enter the day from you date of birth (-DD-/mm/yyyy)");
            date[0] = Format.GetIntFromString(Console.ReadLine());
            Console.WriteLine("Enter the month from you date of birth (dd/-MM-/yyyy)");
            date[1] = Format.GetIntFromString(Console.ReadLine());
            Console.WriteLine("Enter the year from you date of birth (dd/mm/-YYYY-)");
            date[2] = Format.GetIntFromString(Console.ReadLine());

            return string.Join('/', date);

        }

        public static string GetAndCheckPassword()
        {
            Console.WriteLine("Password: ");
            string pWord = Console.ReadLine();
            while (!Validation.IsValidPass(pWord))
            {
                Console.WriteLine("Invalid Password! Password length must be between 8-18 and without spaces.\nEnter your password again...");
                pWord = Console.ReadLine();
            }

            return pWord;
        }
    }
}
