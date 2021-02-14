using System;
using System.Collections.Generic;
using System.Text;


namespace TamagotchiClient.UI
{
    
    class UserPageMenu : MenuScreen
    {
        
        private const int PREVIOUS_NUM = 3;
        public UserPageMenu() : base("Hello " + MainApp.currentPlayer.FirstName) 
        {
            this.AddItem(new MenuItem("Pet Home", new PetHomeMenu(this)));
            this.AddItem(new MenuItem("Change Password", new ChangePasswordScreen(this)));
            this.AddItem(new MenuItem("Create New Animal", new CreateNewAnimalScreen(this)));
            this.AddItem(new MenuItem("Sign Out", MainApp.loginScreen));
        }

        public override void Show()
        {
            Screen.Show(this.Title);
            base.Show();
        }


    }
}
