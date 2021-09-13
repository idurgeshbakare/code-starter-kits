using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void GameWithAllOnePinDown()
        {
            var game = new Game();
            Roll(game, 1, 20);
            Assert.AreEqual(20, game.GetScore());
        }


        [TestMethod]
        public void GameWithFirstSpareFrame()
        {
            var game = new Game();
            Roll(game, 5, 2);
            Roll(game, 1, 18);
            Assert.AreEqual(29, game.GetScore());
        }

        [TestMethod]
        public void GameWithFirstThreeFrameSpare()
        {
            var game = new Game();
            Roll(game, 5, 6);
            Roll(game, 1, 14);
            Assert.AreEqual(55, game.GetScore());
        }

        [TestMethod]
        public void GamewWithFirstSpareFrame()
        {
            var game = new Game();
            Roll(game, 10, 1);
            Roll(game, 1, 18);
            Assert.AreEqual(30, game.GetScore());
        }

      
        [TestMethod]
        //{10, 10, 10, 1,1, 1,1  1,1, 1,1, 1,1, 1,1 1,1 }
        public void GameWithFirstThreeFramesStrike()
        {
            var game = new Game();
            Roll(game, 10, 3);
            Roll(game, 1, 14);
            Assert.AreEqual(14 + 30 + 10 + 10 + 10 + 1 + 1 + 1, game.GetScore());
        }

        [TestMethod]
        //{10, 10, 10, 10, 10, 10, 10, 10, 10, 1,1 }
        public void GameWithAllStrikeExceptLastFrame()
        {
            var game = new Game();
            Roll(game, 10, 9);
            Roll(game, 1, 2);
            Assert.AreEqual(245, game.GetScore());
        }


        [TestMethod]
        //{5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5}
        public void GameWithAllSpareFrame()
        {
            var game = new Game();
            Roll(game, 5, 21);
            Assert.AreEqual(150, game.GetScore());
        }


        [TestMethod]
       //{10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
        public void GameWithAllStrikeFrame()
        {
            var game = new Game();
            Roll(game, 10, 12);
            Assert.AreEqual(300, game.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
