using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1App
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation.Menu Menu = new Presentation.Menu();
            Menu.Grettings();
            var WCF = new WcfLab1.Domain.Services.Bingo();
            WCF.PlayBingo();
        }
    }
}
