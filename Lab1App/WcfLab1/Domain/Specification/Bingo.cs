using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;
using WcfLab1.Domain.Services;

namespace WcfLab1.Domain.Specification
{
    public class Bingo
    {
        private Domain.Actions.Bingo BingoAction { get; set; }

        public Bingo()
        {
            BingoAction = new Domain.Actions.Bingo();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Player> PreparateTheGame(int PlayersNumber)
        {
            List<Player> PlayersList = new List<Player>(BingoAction.CreatePlayer(PlayersNumber));
            BingoAction.PrintPlayersAndCardboards(PlayersList);

            Console.WriteLine("");
            Console.WriteLine("Is time to play!!! (Press ENTER to START)");
            Console.ReadKey();
            Console.Clear();

            return PlayersList;
        }

        /// <summary>
        /// 
        /// </summary>
        public string StartTheGame(GameType gameType, List<Player> playersList)
        {

            string[,] WinnerPatter = BingoAction.GetWinnerPattern(gameType);

            int CurrentNumber = 0;
            List<int> NumberList = new List<int>();
            while (NumberList.Count < 75)
            {
                CurrentNumber = BingoAction.CalculateNumber(1, 75);
                if (!NumberList.Contains(CurrentNumber))
                {
                    NumberList.Add(CurrentNumber);
                    Console.WriteLine("In the column: {0} The number: {1}", BingoAction.GetBingoColumnLetter(CurrentNumber), CurrentNumber);
                    Console.WriteLine("List of the {0} number(s) played:", NumberList.Count);
                    Console.WriteLine("{0}", string.Join(",", NumberList));


                    BingoAction.MarkNumber(CurrentNumber, playersList);
                    BingoAction.PrintPlayersAndCardboards(playersList);

                    string WinnerName = BingoAction.GetTheWinner(WinnerPatter, playersList);

                    if (WinnerName != null)
                    {
                        return WinnerName;
                    }

                    Console.WriteLine("\nFor the next number, please press ENTER");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            return null;
        }
    }
}