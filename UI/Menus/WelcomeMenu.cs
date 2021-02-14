using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiClient.UI
{
    class WelcomeMenu : MenuScreen
    {
        public WelcomeMenu() : base("Tamagotchi") 
        {
            this.AddItem(new MenuItem("Login", MainApp.loginScreen));
            this.AddItem(new MenuItem("Sign up", new SignUpScreen()));
        }

        public override void Show()
        {
            Screen.Show(this.Title);
            Console.WriteLine("\n Welcome to the tamagotchi game!");
            base.Show();
            

        }

    }
}
