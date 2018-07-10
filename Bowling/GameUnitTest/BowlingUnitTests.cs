using Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameUnitTest
{
    [TestClass]
    public class BowlingUnitTests
    {
        private readonly Game _game=new Game();
       
        private void RollMany(int rollsCount, int point)
        {
            for (int i = 0; i < rollsCount; i++)
            {
                _game.Roll(point);
            }
        }
        
        

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12,10);
            Assert.AreEqual(300,_game.GetTotalScore());
        }
    }
}
