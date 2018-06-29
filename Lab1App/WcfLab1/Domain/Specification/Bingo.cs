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
        

        public Bingo(){
            BingoAction = new Domain.Actions.Bingo();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Player> PreparateTheGame(string[] userName, int PlayersNumber)
        {
            List<Player> PlayersList = new List<Player>(BingoAction.CreatePlayer(userName, PlayersNumber));
            return PlayersList;
        }

        /// <summary>
        /// 
        /// </summary>
        public int StartTheGame(GameType gameType, List<Player> playersList, List<int> NumberList) {
            int CurrentNumber = 0;
            while (NumberList.Count < 75){
                CurrentNumber = BingoAction.CalculateNumber(1, 75);
                if (!NumberList.Contains(CurrentNumber)) {
                    return CurrentNumber;
                }
            }
            return CurrentNumber;
        }

        public string CheckWinner(GameType gameType, List<Player> playersList) {
            string[,] WinnerPatter = BingoAction.GetWinnerPattern(gameType);
            string WinnerName = BingoAction.GetTheWinner(WinnerPatter, playersList);
            if (WinnerName != null){
                return WinnerName;
            }
            return null;
        }

        public string GetColumnLetter(int CurrentNumber) {
            return BingoAction.GetBingoColumnLetter(CurrentNumber);
        }



    }
}