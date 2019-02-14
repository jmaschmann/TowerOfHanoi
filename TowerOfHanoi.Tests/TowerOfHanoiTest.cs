using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerOfHanoi.Logic;
using System.Collections.Generic;

namespace TowerOfHanoi.Tests
{
    [TestClass]
    public class TowerOfHanoiTest
    {
        [TestMethod]
        public void SolveTowerOfHanoiTest()
        {
            //Arrange
            const int numberOfDisks = 5;
            const int expectedMoveCount = 31;
            var expectedPegs = new List<int[]>()
            {
                new [] {0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0},
                new [] {5, 4, 3, 2, 1}
            };

            //Act
            var actualGameState = TowerOfHanoiLogic.SolveTowerOfHanoi(numberOfDisks);

            //Assert
            Assert.AreEqual(actualGameState.Moves.Count, expectedMoveCount);
            for(int x = 0; x < 3; x++)
            {
                CollectionAssert.AreEqual(actualGameState.Pegs[x], expectedPegs[x]);
            }
        }
    }
}