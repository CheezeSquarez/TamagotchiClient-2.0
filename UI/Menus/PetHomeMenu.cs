using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TamagotchiClient.DataTransferObjects;
using System.Threading.Tasks;

namespace TamagotchiClient.UI
{
    class PetHomeMenu : MenuScreen
    {
        public PetHomeMenu(UserPageMenu last) : base("Animal Home") 
        {
            this.AddItem(new MenuItem("Do an Activity", null));
            this.AddItem(new MenuItem("Eat", null));
            this.AddItem(new MenuItem("Clean", null));
            this.AddItem(new MenuItem("View History", null));
            this.AddItem(new MenuItem("Back to User Page", last));
            this.AddItem(new MenuItem("Sign out", MainApp.loginScreen));
        }

        public override void Show()
        {
            Screen.Show(this.Title);
            Thread.Sleep(1000);
            Task<AnimalDTO> t = MainApp.api.GetActiveAnimalAsync();
            t.Wait();
            Console.WriteLine(t.Result);
            Console.WriteLine("What would you Like to do?");
            base.Show();
        }
    }
}
