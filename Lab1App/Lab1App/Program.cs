using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;
using WcfLab1.Domain.Respositories;


namespace Lab1App
{
    class Program {
        static void Main(string[] args) {
            Presentation.Menu Menu = new Presentation.Menu();
            Menu.Grettings();
            int numPlayers = Menu.GetNumberOfPlayers();
            var WCF = new Bingo(numPlayers, Menu.SelectPlayMode(), Menu.namePlayers(numPlayers));
            List <Player> players = WCF.preparateTheGame();
            Menu.printPlayersAndCardboard(players);
            Console.WriteLine("");
            Console.WriteLine("Is time to play!!! (Press ENTER to START)");
            Console.ReadKey();
            Menu.ShowTheWinner(Menu.stargame(players, WCF));
            Menu.Goodbye();
        }
    }
}
