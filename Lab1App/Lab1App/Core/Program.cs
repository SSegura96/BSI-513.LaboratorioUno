using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;
using WcfLab1.Domain.Respositories;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Lab1App.Application;
using Lab1App.Utils;
using Lab1App.Presentation;

namespace Lab1App
{
    class Program
    {

        static void Main(string[] args) {

            var container = new WindsorContainer();
            container.Register(Component.For<BingoApplication>());
            container.Register(Component.For<BingoGUI>());
            container.Register(Component.For<IBingo>()
                .ImplementedBy<Bingo>().LifestyleSingleton());
            container.Register(Component.For<IBingoUtils>()
                .ImplementedBy<BingoUtils>().LifestyleSingleton());

            var bingoApplication = container.Resolve<BingoApplication>();
            var bingoGUI = container.Resolve<BingoGUI>();


            //List<int> NumberList = new List<int>();
            //while (WCF.Winner(players) == null)
            //{
                
            //    int CurrentNumber = WCF.PlayBingo(players, NumberList);
            //    NumberList.Add(CurrentNumber);
            //    //Console.WriteLine("In the column: {0} The number: {1}", WCF.ColumnLetter(CurrentNumber), CurrentNumber);
                
                
            //    MarkNumber(CurrentNumber, players);
            //    PrintPlayersAndCardboard(players);
            //}
            //return WCF.Winner(players);
        }
    }
}
