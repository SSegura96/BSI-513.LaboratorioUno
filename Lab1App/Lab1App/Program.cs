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
            var WCF = new WcfLab1.Domain.Services.Bingo();
            WCF.PlayBingo();
        }
    }
}
