using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;

namespace Lab1App
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation.Menu Menu = new Presentation.Menu();
            Menu.Grettings();
            int numPlayers = Menu.GetNumberOfPlayers();
            var WCF = new WcfLab1.Domain.Services.Bingo(numPlayers, Menu.SelectPlayMode(), Menu.namePlayers(numPlayers));
            string WinnerName = WCF.PlayBingo();
            Menu.ShowTheWinner(WinnerName);
            Menu.Goodbye();
        }
    }
}
