using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Specification
{
    public class Bingo
    {
        private Domain.Actions.Bingo BingoAction { get; set; }
        private List<Player> PlayersList { get; set; }

        public Bingo ()
        {
            BingoAction = new Domain.Actions.Bingo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatternLetter"></param>
        public void ChooseTheGameType(char PatternLetter)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void PreparateTheGame()
        {
            PlayersList = new List<Player>(BingoAction.CreatePlayer());
            BingoAction.PrintPlayersAndCardboards(PlayersList);
            
            Console.WriteLine("");
            Console.WriteLine("Is time to play!!! (Press ENTER to START)");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartTheGame()
        {
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
                    BingoAction.MarkNumber(CurrentNumber, PlayersList);
                    BingoAction.PrintPlayersAndCardboards(PlayersList);

                    Console.WriteLine("\nFor the next number, please press ENTER");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.WriteLine("The game is over :(");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowTheResult()
        {

        }
    }
}