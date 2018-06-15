using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Specification
{
    public class Bingo
    {
        public void ChooseTheGameType()
        {

        }

        public void PreparateTheGame()
        {
            var BingoAction = new Domain.Actions.Bingo();
            BingoElement[,] WinnerCardboard = BingoAction.CreateCardboard();
            WinnerCardboard = BingoAction.InitializeCardboard(WinnerCardboard);
            BingoAction.PrintCardboard(WinnerCardboard);
        }

        public void GetCardboardsForPlayers()
        {

        }

        public void ShowTheResult()
        {

        }
    }
}