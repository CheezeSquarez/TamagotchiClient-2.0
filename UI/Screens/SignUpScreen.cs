using System;
using System.Collections.Generic;
using System.Text;
using TamagotchiClient.DataTransferObjects;
using TamagotchiClient.WebServices;
using System.Threading.Tasks;


namespace TamagotchiClient.UI  
{
    class SignUpScreen : Screen
    {
        public SignUpScreen() : base("Sign Up") { }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("First name: ");
            string fName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            string lName = Console.ReadLine();

            int[] bDate = new int[3];
            bool correctDate = false;
            do
            {
                string date = Format.MakeFormattedDatestring(bDate);
                while (!Validation.IsValidBirthdate(bDate[2], bDate[1], bDate[0]))
                {
                    Console.WriteLine("Invalid Date! Please Try again");
                    date = Format.MakeFormattedDatestring(bDate);
                }
                Console.WriteLine($"Is this: {date}, your birthday?\nPress 'Y' if yes. Press anything else if not.");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                    correctDate = true;
            } while (!correctDate);
            


            Console.WriteLine("Username: ");
            string uName = Console.ReadLine();

            string pWord = Format.GetAndCheckPassword();

            Console.WriteLine("Confirm Password: ");
            string confirmPWord = Console.ReadLine();

            while (pWord != confirmPWord)
            {
                Console.WriteLine("Passwords don't match! Please Enter your password again.\n");
                pWord = Format.GetAndCheckPassword();
                Console.WriteLine("Confirm Password: ");
                confirmPWord = Console.ReadLine();
            }

            Console.WriteLine("Email: ");
            string gmail = Console.ReadLine();
            while (!Validation.IsValidEmail(gmail))
            {
                Console.WriteLine("Invalid Email! Try again.");
                gmail = Console.ReadLine();
            }
            
            string[] genders = { "Male", "Female", "Other" };
            Console.WriteLine("Gender: \n1 - Male\n2 - Female\n3 - Other");
            int gender;
            int.TryParse(Console.ReadLine(), out gender);

            while (gender > 3 || gender < 1)
            {
                Console.WriteLine("ERROR!!!!!! gender has to be between 1-3 please try again");
                int.TryParse(Console.ReadLine(), out gender);
            }

            Task<bool> exist = MainApp.api.DoesExistAsync(uName, gmail);
            exist.Wait();
            if (exist.Result)
            {
                Console.WriteLine("A player with this username or email already exists... Please try again. (Press any key to continue...)");
                Console.ReadKey();
                this.Show();
            }
            
            PlayerDTO p = new PlayerDTO() { FirstName = fName, LastName = lName, PWord = pWord, Username = uName, Gender = genders[gender - 1], Email = gmail, DateOfBirth = new DateTime(bDate[2],bDate[1],bDate[0]) };
            
            try
            {
                Task<bool> t = MainApp.api.SignUpAsync(p);
                t.Wait();
                if (!t.Result)
                {
                    throw new UnauthorizedAccessException(); // not the right exception just fix it

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem with the sign up process.\nException:\n" + e.Message + "\nInner Exception: " + e.InnerException.Message);
                Environment.Exit(1);
            }

            MainApp.loginScreen.Show();

        }
        

        
    }
}
