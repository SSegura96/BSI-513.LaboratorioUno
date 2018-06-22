using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;

namespace Lab1App.Presentation
{
    public class Menu
    {
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
    }
}
