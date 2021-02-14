using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiClient.UI
{
    class MenuScreen : Screen
    {
        protected List<MenuItem> items { get; set; }

        public MenuScreen(string title) : base(title) { this.items = new List<MenuItem>(); }
        public void AddItem(MenuItem m)
        {
            items.Add(m);
        }

        public void RemoveItem(MenuItem m)
        {
            items.Remove(m);
        }

        public override void Show()
        {
            
            Console.WriteLine("Please Choose from the following Options");
            int count = 1;
            bool exit = false;
            while (!exit) //Loop until user press the exit option (last option)
            {
                foreach (MenuItem m in items)
                {
                    Console.WriteLine($"\n{count} - {m}");
                    count++;
                }
                Console.WriteLine($"{count} - Exit");

                int option = 0;
                int.TryParse(Console.ReadLine(), out option);
                if (option >= 1 && option <= count)
                {
                    if (option != count)
                    {
                        if (this.items[option - 1].TargetScreen != null)
                        {
                            this.items[option - 1].Show(); //Show selected screen!
                        }
                        //else
                        //    new ErrorScreen("Missing Screen Error", this).Show();
                    }
                    else
                        Environment.Exit(0);
                    exit = true;
                }
                count = 1;
            }
        }
    }
}
