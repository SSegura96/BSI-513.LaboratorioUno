using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1App.Presentation
{
    public class Menu
    {
        public void Grettings ()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("    Welcome Players to the Best WCF Bingo Ever!!!");
            Console.WriteLine("======================================================");
            Console.WriteLine("               Press ENTER to CONINUE");
            Console.ReadKey();
            Console.Clear();
        }

        public int SelectPlayerNumber()
        {
            while (true)
            {
                Console.WriteLine("Select the number of players");
                Console.WriteLine("a) 1 player");
                Console.WriteLine("b) 2 player");
                Console.WriteLine("c) 3 player");
                Console.WriteLine("d) 4 player");
                Console.WriteLine("e) 5 player");
                char Resp = Console.ReadLine()[0];

                switch (Resp)
                {
                    case 'a':
                    case 'A':
                        return 1;
                    case 'b':
                    case 'B':
                        return 2;
                    case 'c':
                    case 'C':
                        return 3;
                    case 'd':
                    case 'D':
                        return 4;
                    case 'e':
                    case 'E':
                        return 5;
                    default:
                        Console.WriteLine("Invalid selection type one of the options");
                        break;
                }
            }
        }

        public int SelectGameType ()
        {
            return 0;
        }
    }
}
