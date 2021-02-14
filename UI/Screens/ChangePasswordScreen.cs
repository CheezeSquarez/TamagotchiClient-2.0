using System;
using System.Collections.Generic;
using System.Text;
using TamagotchiClient.DataTransferObjects;
using TamagotchiClient.WebServices;
using System.Threading.Tasks;


namespace TamagotchiClient.UI
{
    class ChangePasswordScreen : Screen
    {
        private UserPageMenu last;
        public ChangePasswordScreen(UserPageMenu last) : base("Change Password") { this.last = last; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Please enter your current password");
            string pass = Console.ReadLine();
            Task<bool> isCorrect = MainApp.api.CheckPasswordAsync(pass);
            isCorrect.Wait();
            while (!isCorrect.Result)
            {               
                Console.WriteLine("Incorrect Password! Try Again");
                pass = Console.ReadLine();
                isCorrect = MainApp.api.CheckPasswordAsync(pass);
                isCorrect.Wait();
            }

            Console.WriteLine("-New Password-");
            string newPass = Format.GetAndCheckPassword();
            Console.WriteLine("Confirm new Password");
            string confirm = Console.ReadLine();
            while(newPass != confirm) 
            {
                Console.WriteLine("Passwords do not match! Try Again.\nEnter Password");
                newPass = Format.GetAndCheckPassword();
                Console.WriteLine("Confirm new Password");
                confirm = Console.ReadLine();
            }
           
            try
            {
                Task<bool> newPassword = MainApp.api.SetPasswordAsync(newPass);
                newPassword.Wait();
                if (!newPassword.Result)
                    throw new InvalidOperationException();
                    
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error changing the password... Please try again later.\nException: {0}\nInner Exception: {1}", e.Message, e.InnerException.Message);
            }
            last.Show();
        }
    }
}
