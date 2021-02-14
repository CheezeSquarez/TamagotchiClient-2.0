using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace TamagotchiClient.UI
{
    abstract class Validation
    {
        public static bool IsValidPass(string pass) => pass.Length >= 8 && pass.Length <= 18 && !pass.Contains(" ");

        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidBirthdate(int year, int month, int day)
        {
            try
            {
                DateTime d = new DateTime(year, month, day);
                return (DateTime.Now - d).Days / 365 >= 8 && (DateTime.Now - d).Days / 365 <= 120;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
