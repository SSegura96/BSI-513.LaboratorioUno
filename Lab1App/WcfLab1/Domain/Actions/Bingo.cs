using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Actions
{
    public class Bingo
    {
        /// <summary>
        /// 
        /// </summary>
        public void GameStart()
        {
            Console.WriteLine("Welcome Players to the Best WCF Bingo Ever!!! (Press ENTER to CONINUE)");
            Console.ReadKey();
            Console.Clear();
            List<Player> PlayersList = new List<Player>(CreatePlayer());
            PrintPlayersAndCardboards(PlayersList);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Is time to play!!! (Press ENTER to START)");
            Console.ReadKey();
            Console.Clear();
            List<int> NumberList = new List<int>();
            int CurrentNumber = 0;
            while (NumberList.Count < 75)
            {
                CurrentNumber = CalculateNumber(1, 75);
                if (!NumberList.Contains(CurrentNumber))
                {
                    NumberList.Add(CurrentNumber);
                    Console.WriteLine("In the column: {0} The number: {1}", GetBingoColumnLetter(CurrentNumber), CurrentNumber);
                    Console.WriteLine("List of the {0} number(s) played:", NumberList.Count);
                    Console.WriteLine("{0}", string.Join(",", NumberList));
                    MarkNumber(CurrentNumber, PlayersList);
                    PrintPlayersAndCardboards(PlayersList);

                    Console.WriteLine("\nFor the next number, please press ENTER");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            //NumberList.Sort();
            Console.WriteLine("The game is over :(");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Player> CreatePlayer()
        {
            Console.WriteLine("How many players want to play?:");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            List<Player> PlayersList = new List<Player>();
            Player NewPlayer;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                NewPlayer = new Player();
                Console.WriteLine("Name of the player #{0}:", i + 1);
                NewPlayer.Name = Console.ReadLine();
                NewPlayer.CardBoardPlayer = InitializeCardboard(NewPlayer.CardBoardPlayer);
                PlayersList.Add(NewPlayer);
            }
            Console.Clear();
            return PlayersList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlayersList"></param>
        public void PrintPlayersAndCardboards(List<Player> PlayersList)
        {
            foreach (var player in PlayersList)
            {
                Console.WriteLine("\n{0}'s Cardboard:", player.Name);
                PrintCardboard(player);
                if (player.MarkedNumbers.Count != 0)
                {
                    PrintMarkedNumbers(player);
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentNumber"></param>
        /// <returns></returns>
        public string GetBingoColumnLetter(int CurrentNumber)
        {
            if (CurrentNumber >= 1 && CurrentNumber <= 15)
            {
                return "B";
            }
            else if (CurrentNumber >= 16 && CurrentNumber <= 30)
            {
                return "I";
            }
            else if (CurrentNumber >= 31 && CurrentNumber <= 45)
            {
                return "N";
            }
            else if (CurrentNumber >= 46 && CurrentNumber <= 60)
            {
                return "G";
            }
            else if (CurrentNumber >= 61 && CurrentNumber <= 75)
            {
                return "O";
            }
            return String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentNumber"></param>
        /// <param name="PlayersList"></param>
        public void MarkNumber(int CurrentNumber, List<Player> PlayersList)
        {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        static void PrintCardboard(Player player)
        {
            BingoElement CurrentElement;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CurrentElement = player.CardBoardPlayer[i, j];
                    if (CurrentElement.State)
                    {
                        string NewNumber = CurrentElement.Number.Substring(1, 2);

                        Console.Write(" {0} [X]", NewNumber);
                    }
                    else
                    {
                        string ModifiedNumber = CurrentElement.Number;
                        if (!ModifiedNumber.Equals(" XXXXXX"))
                        {
                            if (ModifiedNumber.Substring(1, 2).Contains(" "))
                            {
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
        /// 
        /// </summary>
        /// <param name="player"></param>
        static void PrintMarkedNumbers(Player player)
        {
            Console.WriteLine("\n{0}'s Marked Numbers List: {1}", player.Name, string.Join(",", player.MarkedNumbers));
            Console.WriteLine("------------------------------------------------------------------");
        }

        /// <summary>
        /// Fill all the matrix with the numbers
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static BingoElement[,] InitializeCardboard(BingoElement[,] m)
        {
            char[] Columns = new char[]
            {
                'B','I','N','G','O'
            };

            for (int i = 0; i < Columns.Length; i++)
            {
                FillColumn(Columns[i], m);
            }

            return m;
        }

        /// <summary>
        /// Fill each column with the value 
        /// </summary>
        /// <param name="CurrentColumn"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static BingoElement[,] FillColumn(char CurrentColumn, BingoElement[,] m)
        {
            int ColumnIndex = 0;
            int FistNumber = 0;
            int LastNumber = 0;

            switch (CurrentColumn)
            {
                case 'B':
                    ColumnIndex = 0;
                    FistNumber = 1;
                    LastNumber = 15;
                    break;
                case 'I':
                    ColumnIndex = 1;
                    FistNumber = 16;
                    LastNumber = 30;
                    break;
                case 'N':
                    ColumnIndex = 2;
                    FistNumber = 31;
                    LastNumber = 45;
                    break;
                case 'G':
                    ColumnIndex = 3;
                    FistNumber = 46;
                    LastNumber = 60;
                    break;
                case 'O':
                    ColumnIndex = 4;
                    FistNumber = 61;
                    LastNumber = 75;
                    break;
                default:
                    return null;
            }

            List<int> SelectedNumbers = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (CurrentColumn == 'N' && i == 2)
                {
                    m[i, ColumnIndex] = new BingoElement(" XXXXXX", false);
                }
                else
                {
                    int CurrentNumber = CalculateNumber(FistNumber, LastNumber);
                    while (SelectedNumbers.Contains(CurrentNumber))
                    {
                        CurrentNumber = CalculateNumber(FistNumber, LastNumber);
                    }
                    SelectedNumbers.Add(CurrentNumber);
                    m[i, ColumnIndex] = new BingoElement(" " + CurrentNumber + " [ ]", false);
                }
            }
            return m;
        }

        /// <summary>
        /// Ony Get a random number that its inside of this range
        /// </summary>
        /// <param name="FistNumber"></param>
        /// <param name="LastNumber"></param>
        /// <returns></returns>
        static int CalculateNumber(int FistNumber, int LastNumber)
        {
            Random rnd = new Random();
            return rnd.Next(FistNumber, LastNumber + 1);
        }

        #region Patterns

        public string[,] patternFull()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c <= 4; c++)
                {
                    patron[f, c] = "X";
                }
            }
            return patron;
        }

        public string[,] pattern4Corners()
        {
            string[,] patron = new string[5, 5];
            patron[0, 0] = "X"; patron[0, 4] = "X";
            patron[2, 2] = "X";
            patron[4, 0] = "X"; patron[4, 4] = "X";
            return patron;
        }

        public string[,] patternH()
        {
            string[,] patron = new string[5, 5];
            patron[2, 2] = "X";
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (c == 0 || c == 4)
                        patron[f, c] = "X";
                    else
                    {
                        if (f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            return patron;
        }

        public string[,] patternX()
        {
            string[,] patron = new string[5, 5];
            patron[0, 0] = "X"; patron[0, 4] = "X";
            patron[1, 1] = "X"; patron[1, 3] = "X";
            patron[2, 2] = "X";
            patron[3, 1] = "X"; patron[3, 3] = "X";
            patron[4, 0] = "X"; patron[4, 4] = "X";
            return patron;
        }

        public string[,] patternO()
        {
            string[,] patron = new string[5, 5];
            patron[2, 2] = "X";
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (f == 0 || f == 4)
                    {
                        if (c == 1 || c == 2 || c == 3)
                            patron[f, c] = "X";
                    }
                    else
                    {
                        if (c == 0 || c == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            return patron;
        }

        public string[,] patternU()
        {
            string[,] patron = new string[5, 5];
            patron[2, 2] = "X";
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (f == 4)
                    {
                        if (c == 1 || c == 2 || c == 3)
                            patron[f, c] = "X";
                    }
                    else
                    {
                        if (c == 0 || c == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            return patron;
        }

        public string[,] patternP()
        {
            string[,] patron = new string[5, 5];
            for (int c = 0; c < 3; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0)
                        patron[f, c] = "X";
                    if (c == 1)
                    {
                        if (f == 0 || f == 2)
                            patron[f, c] = "X";
                    }
                    if (c == 2)
                    {
                        if (f == 0 || f == 1 || f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            return patron;
        }

        public string[,] patternA()
        {
            string[,] patron = new string[5, 5];
            patron[2, 2] = "X"; patron[0, 2] = "X";
            for (int c = 0; c < 5; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0 || c == 4)
                    {
                        patron[f, c] = "X";
                    }
                    else
                    {
                        if (f == 0 || f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            return patron;
        }

        public string[,] patternE()
        {
            string[,] patron = new string[5, 5];
            patron[2, 2] = "X"; patron[0, 2] = "X";
            for (int c = 0; c < 5; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0)
                    {
                        patron[f, c] = "X";
                    }
                    else
                    {
                        if (f == 0 || f == 2 || f == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            return patron;
        }

        #endregion
    }
}
