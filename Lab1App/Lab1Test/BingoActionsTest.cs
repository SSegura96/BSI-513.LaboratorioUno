using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1UnitTest
{
    [TestClass]
    public class BingoActionsTest
    {

        [TestMethod]
        public void GetBingoColumnLetterTest()
        {
            WcfLab1.Domain.Actions.Bingo BingoAction = new WcfLab1.Domain.Actions.Bingo();
            var Result = BingoAction.GetBingoColumnLetter(1);
            Assert.IsTrue(Result.Equals("B"), "FalloB");

            Result = BingoAction.GetBingoColumnLetter(30);
            Assert.IsTrue(Result.Equals("I"), "Fallo I");
        }

    }
}
