using System;
using System.Collections.Generic;
using System.Text;
using TamagotchiClient.WebServices;
using TamagotchiClient.DataTransferObjects;
using System.Threading.Tasks;

namespace TamagotchiClient.UI
{
    class MainApp
    {
        public Screen StartScreen;
        public static PlayerDTO currentPlayer;
        public static TamaguchiWebAPI api;
        public static LoginScreen loginScreen;

        public MainApp()
        {
            loginScreen = new LoginScreen();
            currentPlayer = null;
            StartScreen = new WelcomeMenu();
            api = new TamaguchiWebAPI("https://localhost:44370/api");
        }
        public void ApplicationStart()
        {
            api.LogOutAsync().Wait();
            StartScreen.Show();
        }
    }
}
