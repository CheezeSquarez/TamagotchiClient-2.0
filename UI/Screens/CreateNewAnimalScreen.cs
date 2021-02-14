using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiClient.DataTransferObjects;
using TamagotchiClient.WebServices;
 

namespace TamagotchiClient.UI
{
    class CreateNewAnimalScreen : Screen
    {
        private UserPageMenu last;
        public CreateNewAnimalScreen(UserPageMenu last) : base("Create New Animal") { this.last = last; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Enter the name of your Tamagotchi!\n");
            
            string aName = Console.ReadLine();
            Console.WriteLine("Do you wish to continue? This will kill your current animal if you have one...\nPress any key to continue or Esc to go back");
            if(Console.ReadKey().Key == ConsoleKey.Escape)
            {
                last.Show();
            }
            else
            {
                Task<AnimalDTO> newAnimal = MainApp.api.CreateNewAnimalAsync(aName);
                newAnimal.Wait();
                if (newAnimal.Result==null)
                {
                    throw new InvalidOperationException();
                }
                
                System.Threading.Thread.Sleep(1000);
                PetHomeMenu next = new PetHomeMenu(last);
                next.Show();
            }
        }
    }

}
