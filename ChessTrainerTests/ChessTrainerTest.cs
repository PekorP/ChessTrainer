using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessTrainerTests
{
    [TestClass]
    public class ChessTrainerTest
    {
        [TestMethod]
        public void TestCorrectChessNotationMove()
        {
            var result = ChessTrainer.Models.ChessMove.MoveParse("Qe2-e4");
            Assert.AreEqual(result, "Ферзь e2 на e4");
        }

        [TestMethod]
        public void TestCorrectChessNotationCastling()
        {
            var result = ChessTrainer.Models.ChessMove.MoveParse("0-0");
            Assert.AreEqual(result, "Короткая рокировка");
        }

        [TestMethod]
        public void TestWrongChessNotationCastling()
        {
            var result = ChessTrainer.Models.ChessMove.MoveParse("0-0-0-0");
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestWrongChessNotationMove()
        {
            var result = ChessTrainer.Models.ChessMove.MoveParse("abra-cadabra");
            Assert.AreEqual(result, null);
        }
    }
}
