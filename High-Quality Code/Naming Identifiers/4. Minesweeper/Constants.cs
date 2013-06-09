namespace MinesweeperGame
{
    using System;

    internal class Constants
    {
        internal const int BoardRows = 5;
        internal const int BoardColumns = 10;

        internal const int MaxMines = 15;

        internal const int MaxScore = (BoardRows * BoardColumns) - MaxMines;

        internal const int MaxLeaders = 5;
    }
}
