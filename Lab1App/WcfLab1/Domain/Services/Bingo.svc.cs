using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bingo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Bingo.svc or Bingo.svc.cs at the Solution Explorer and start debugging.
    public class Bingo : IBingo
    {
        
        public int PlayeresNumber { get ; set ; }
        public GameType GameType { get ; set ; }
        public string[] UserNames { get; set; }

        public Bingo(int _PlayeresNumber, GameType _GameType, string[] _UserNames)
        {
            this.PlayeresNumber = _PlayeresNumber;
            this.GameType = _GameType;
            this.UserNames = _UserNames;
        }

        public List<Player> preparateTheGame() {
            var BingoSpecification = new WcfLab1.Domain.Specification.Bingo();
            return BingoSpecification.PreparateTheGame(UserNames, PlayeresNumber);
        }

        public int PlayBingo(List<Player> PlayersList, List<int> list) {
            var BingoSpecification = new WcfLab1.Domain.Specification.Bingo();
            return BingoSpecification.StartTheGame(GameType, PlayersList, list);
        }

        public string Winner(List<Player> playersList) {
            var BingoSpecification = new WcfLab1.Domain.Specification.Bingo();
            return BingoSpecification.CheckWinner(GameType, playersList);
        }

        public string ColumnLetter(int CurrentNumber) {
            var BingoSpecification = new WcfLab1.Domain.Specification.Bingo();
            return BingoSpecification.GetColumnLetter(CurrentNumber);
        }

    }
}
