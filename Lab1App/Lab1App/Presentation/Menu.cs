using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Presentation
{
    public class Menu{

        public void Grettings()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("    Welcome Players to the Best WCF Bingo Ever!!!");
            Console.WriteLine("======================================================");
            Console.WriteLine("               Press ENTER to CONINUE");
            Console.ReadKey();
            Console.Clear();
        }

        public int GetNumberOfPlayers()
        {
            int resp = 0;
            while (true)
            {
                Console.WriteLine("Write the number of players");
                if (int.TryParse(Console.ReadLine(), out resp))
                {
                    if (resp > 0 && resp <= 10)
                    {
                        Console.Clear();
                        return resp;
                    }
                    Console.WriteLine("Only can play 1 - 10 people");
                }
                Console.WriteLine("Invalid selection please try again (Press enter)");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public GameType SelectPlayMode()
        {
            while (true)
            {
                Console.WriteLine("Select the game mode");
                Console.WriteLine("1) FullCardboar");
                Console.WriteLine("2) 4 Corners");
                Console.WriteLine("3) H");
                Console.WriteLine("4) X");
                Console.WriteLine("5) O");
                Console.WriteLine("6) U");
                Console.WriteLine("7) P");
                Console.WriteLine("8) A");
                Console.WriteLine("9) E");
                int Resp = int.Parse(Console.ReadLine());

                switch (Resp)
                {
                    case 1:
                        return GameType.Full;
                    case 2:
                        return GameType.FourCorners;
                    case 3:
                        return GameType.H;
                    case 4:
                        return GameType.X;
                    case 5:
                        return GameType.O;
                    case 6:
                        return GameType.U;
                    case 7:
                        return GameType.P;
                    case 8:
                        return GameType.A;
                    case 9:
                        return GameType.E;
                    default:
                        Console.WriteLine("Invalid selection type one of the options");
                        break;
                }
            }
        }

        public void ShowTheWinner (string PlayerName)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("      Congratulations {0} you are the winner!!!",PlayerName);
            Console.WriteLine("======================================================");
        }

        public void Goodbye ()
        {
            Console.WriteLine("The game is over :(");
            Console.ReadKey();
        }

        public string[] namePlayers(int numPlayer)
        {
            string[] names = new string[numPlayer];
            for (int i = 0; i < numPlayer; i++)
            {
                Console.WriteLine("Name of the player #{0}:", i + 1);
                names[i] = Console.ReadLine();
            }
            Console.Clear();
            return names;
        }

        public void printPlayersAndCardboard(List<Player> PlayersList) {
            foreach (var player in PlayersList) {
                Console.WriteLine("\n{0}'s Cardboard:", player.Name);
                printCardboard(player);
                if (player.MarkedNumbers.Count != 0){
                    printMarkedNumbers(player);
                }
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="player"></param>
        public void printCardboard(Player player) {
            WcfLab1.Domain.Respositories.BingoElement CurrentElement;
            for (int i = 0; i < 5; i++){
                for (int j = 0; j < 5; j++){
                    CurrentElement = player.CardBoardPlayer[i, j];
                    if (CurrentElement.State){
                        string NewNumber = CurrentElement.Number.Substring(1, 2);

                        Console.Write(" {0} [X]", NewNumber);
                    }
                    else {
                        string ModifiedNumber = CurrentElement.Number;
                        if (!ModifiedNumber.Equals(" XXXXXX")){
                            if (ModifiedNumber.Substring(1, 2).Contains(" ")){
                                ModifiedNumber = " 0" + ModifiedNumber.Substring(1, 2) + "[ ]";
                            }
                        }
                        Console.Write(ModifiedNumber);
                    }
                }
                Console.WriteLine(""); 
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="player"></param>
        public void printMarkedNumbers(Player player) {
            Console.WriteLine("\n{0}'s Marked Numbers List: {1}", player.Name, string.Join(",", player.MarkedNumbers));
            Console.WriteLine("------------------------------------------------------------------");
        }

        /// <summary>
        /// </summary>
        /// <param name="CurrentNumber"></param>
        /// <param name="PlayersList"></param>
        public void MarkNumber(int CurrentNumber, List<Player> PlayersList) {
            foreach (var Player in PlayersList)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!(Player.CardBoardPlayer[i, j].Number.Equals(" XXXXXX")))
                        {
                            if (Convert.ToInt32(Player.CardBoardPlayer[i, j].Number.Substring(1, 2)) == CurrentNumber)
                            {
                                Player.CardBoardPlayer[i, j].State = true;
                                Console.WriteLine("{0}'s number {1}:[{2}][{3}]", Player.Name, CurrentNumber, i + 1, j + 1);
                                Player.MarkedNumbers.Add(CurrentNumber);
                            }
                        }
                    }
                }
            }
        }

        public string stargame(List<Player> players, Bingo WCF) {
            List<int> NumberList = new List<int>();
            while (WCF.Winner(players) == null){
                Console.WriteLine("\nFor the next number, please press ENTER");
                Console.ReadKey();
                Console.Clear();
                int CurrentNumber = WCF.PlayBingo(players, NumberList);
                NumberList.Add(CurrentNumber);
                Console.WriteLine("In the column: {0} The number: {1}", WCF.ColumnLetter(CurrentNumber), CurrentNumber);
                Console.WriteLine("List of the {0} number(s) played:", NumberList.Count);
                Console.WriteLine("{0}", string.Join(",", NumberList));
                MarkNumber(CurrentNumber, players);
                printPlayersAndCardboard(players);
            }
            return WCF.Winner(players);
        }


    }
}
