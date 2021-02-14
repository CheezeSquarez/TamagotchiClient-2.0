using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiClient.UI
{
    abstract class Screen
    {
        public string Title { get; set; }

        public Screen(string title)
        {
            this.Title = title;
        }

        public static void Show(string title)
        {
            Console.Clear();

            Console.WriteLine($"{title}".PadLeft(Console.WindowWidth / 2));
        }
        public virtual void Show()
        {
            Screen.Show(this.Title);
        }
    }
}
