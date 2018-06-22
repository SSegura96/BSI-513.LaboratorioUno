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

        public Bingo(int _PlayeresNumber, GameType _GameType)
        {
            this.PlayeresNumber = _PlayeresNumber;
            this.GameType = _GameType;
        }

        public string PlayBingo()
        {
            var BingoSpecification = new WcfLab1.Domain.Specification.Bingo();
            List<Player> PlayersList = BingoSpecification.PreparateTheGame(PlayeresNumber);
            return BingoSpecification.StartTheGame(GameType, PlayersList);
        }
    }
}
