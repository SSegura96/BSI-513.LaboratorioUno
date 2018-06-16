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
            BingoAction.GetTheCardboardReady();
        }

        public void GetCardboardsForPlayers(int PlayersNumber)
        {
            for(int i = 0;i<PlayersNumber;i++)
            {
                
            }
        }

        public void ShowTheResult()
        {

        }
    }
}