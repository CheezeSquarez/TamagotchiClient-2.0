using System;
using System.Collections.Generic;
using System.Text;
using TamagotchiClient.WebServices;
using TamagotchiClient.DataTransferObjects;
using System.Threading.Tasks;

namespace TamagotchiClient.UI
{
    class LoginScreen : Screen
    {
        private UserPageMenu next;
        public LoginScreen() : base("Login Screen")
        {
            next = null;
        }

        public override void Show()
        {
            base.Show();
            if (MainApp.currentPlayer == null)
            {
                Console.WriteLine("Please enter your username:");
                string uName = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                string pass = Console.ReadLine();
                Task<PlayerDTO> p = MainApp.api.LoginAsync(uName, pass);
                p.Wait();
                MainApp.currentPlayer = p.Result;
                //MainApp.currentPlayer = MainApp.db.Login("Mitzi123", "HaHato0l1234123"); //For testing
                if (MainApp.currentPlayer == null)
                {
                    //new ErrorScreen("Incorrect Username or Pass Error", this).Show();
                    Console.WriteLine("Incorrect username or password\nPress any key to try again.");
                    Console.ReadKey();
                    this.Show();
                }
                else
                {
                    next = new UserPageMenu();
                    Console.WriteLine("Login Succesfull!\nPress any key to continue...");
                    Console.ReadKey();
                    next.Show();
                }
            }
            else
            {
                Console.WriteLine("Would like to sign out and re-Login? Y/N");

                bool validChoice = false;
                while (!validChoice)
                {
                    char choice = Console.ReadKey().KeyChar;
                    switch (choice)
                    {
                        case 'y':
                        case 'Y':
                            Task<bool> t = MainApp.api.LogOutAsync();
                            t.Wait();
                            if(t.Result)
                                MainApp.currentPlayer = null;
                            else
                                Console.WriteLine("There was a Problem logging out");
                            validChoice = true;
                            this.Show();
                            break;
                        case 'n':
                        case 'N':
                            validChoice = true;
                            next = new UserPageMenu();
                            next.Show();

                            break;
                        default:
                            Console.WriteLine("\nInvalid input! Enter 'Y' for yes, or 'N' for No.");

                            break;
                    }
                }
                
            }
        }
    }    
}
