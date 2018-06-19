using System;
using System.Collections.Generic;
using System.Text;

namespace WcfLab1.Domain.Respositories
{
    public class Player
    {
        public string Name { get; set; }
        public BingoElement[,] CardBoardPlayer { get; set; }
        public List<int> MarkedNumbers { get; set; }

        public Player(string name, BingoElement[,] cardBoardPlayer, List<int> markedNumbers)
        {
            Name = name;
            CardBoardPlayer = cardBoardPlayer;
            MarkedNumbers = markedNumbers;
        }

        public Player()
        {
            this.MarkedNumbers = new List<int>();
            this.CardBoardPlayer = new BingoElement[5, 5];
        }
    }
}
