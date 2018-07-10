using Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameUnitTest
{
    [TestClass]
    public class BowlingUnitTests
    {
        private Game _game;

        private void RollMany(int rollsCount, int point)
        {
            for (int i = 0; i < rollsCount; i++)
            {
                _game.Roll(point);
            }
        }

        private void RollStrike() => _game.Roll(10);

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        [TestInitialize]
        public void IntializeTest()
        {
            _game = new Game();
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12,10);
            Assert.AreEqual(300, _game.GetTotalScore());
        }

        [TestMethod]
        public void TestFiveStrikeAndFiveSpare()
        {
            RollMany(5,10);
            RollMany(11,5);
            Assert.AreEqual(210,_game.GetTotalScore());
        }

        [TestMethod]
        public void TestSimpleGame()
        {
            _game.Roll(4);
            _game.Roll(5);
            _game.Roll(1);
            _game.Roll(6);
            _game.Roll(3);
            _game.Roll(7);
            RollSpare();
            RollStrike();
            _game.Roll(6);
            _game.Roll(3);
            Assert.AreEqual(79,_game.GetTotalScore());
        }

        [TestMethod]
        public void TestAllSpare()
        {
            RollMany(21,5);
            Assert.AreEqual(150, _game.GetTotalScore());
        }

        [TestMethod]
        public void TestAllZero()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.GetTotalScore());
        }

    }
}
