using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1App.Models
{
    public class BingoElement
    {
        public string Number { get; set; }
        public bool State { get; set; }

        public BingoElement(string _Number, bool _State)
        {
            this.Number = _Number;
            this.State = _State;
        }
    }
}
