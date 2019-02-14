using System.Collections.Generic;

namespace TowerOfHanoi.Logic
{
    public class TowerOfHanoiLogic
    {
        public static GameState SolveTowerOfHanoi(int numberOfDisks)
        {
            var gameState = new GameState
            {
                Pegs = CreatePegsAtStartPositions(numberOfDisks),
                Moves = new List<Move>()
            };

            CalculateMove(numberOfDisks, 0, 2, 1, gameState);

            return gameState;
        }

        private static List<int[]> CreatePegsAtStartPositions(int numberOfDisks)
        {
            var pegs = new List<int[]>();
            var peg1 = new int[numberOfDisks];
            var counter = numberOfDisks;
            for (int x = 0; x < numberOfDisks; x++)
            {
                peg1[x] = counter;
                counter--;
            }

            pegs.Add(peg1);
            pegs.Add(new int[numberOfDisks]);
            pegs.Add(new int[numberOfDisks]);

            return pegs;
        }

        private static void MoveTopDiskBetweenPegs(int pegToMoveFrom, int pegToMoveTo, GameState gameState)
        {
            var moveFromPosition = 0;
            var moveToPosition = 0;

            for (int x = gameState.Pegs[pegToMoveFrom].Length - 1; x >= 0; x--)
            {
                if (gameState.Pegs[pegToMoveFrom][x] != 0)
                {
                    moveFromPosition = x;
                    break;
                }
            }

            for (int x = 0; x < gameState.Pegs[pegToMoveFrom].Length; x++)
            {
                if (gameState.Pegs[pegToMoveTo][x] == 0)
                {
                    moveToPosition = x;

                    gameState.Pegs[pegToMoveTo][moveToPosition] = gameState.Pegs[pegToMoveFrom][moveFromPosition];
                    gameState.Pegs[pegToMoveFrom][moveFromPosition] = 0;

                    break;
                }
            }

            LogMove(pegToMoveFrom, pegToMoveTo, gameState, moveFromPosition, moveToPosition);
        }

        private static void LogMove(int pegToMoveFrom, int pegToMoveTo, GameState gameState, int moveFromPosition, int moveToPosition)
        {
            gameState.Moves.Add(new Move() { MoveFromPosition = moveFromPosition, MoveToPosition = moveToPosition, PegToMoveFrom = pegToMoveFrom, PegToMoveTo = pegToMoveTo });
        }

        private static void CalculateMove(int numberOfDisks, int startPeg, int endPeg, int tempPeg, GameState gameState)
        {
            if (numberOfDisks > 0)
            {
                CalculateMove(numberOfDisks - 1, startPeg, tempPeg, endPeg, gameState);
                MoveTopDiskBetweenPegs(startPeg, endPeg, gameState);
                CalculateMove(numberOfDisks - 1, tempPeg, endPeg, startPeg, gameState);
            }
        }
    }
}