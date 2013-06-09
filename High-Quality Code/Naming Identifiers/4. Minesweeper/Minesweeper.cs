namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Minesweeper
    {
        public static void Main()
        {
            string currentCommand = string.Empty;
            char[,] field = CreateField();
            char[,] mines = PlaceMines();
            int currentScore = 0;
            bool hitMine = false;
            List<Score> leaders = new List<Score>(6);
            int currentRow = 0;
            int currentColumn = 0;
            bool isNewGame = true;
            const int MaxScore = Constants.MaxScore;
            bool isWon = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Let's play Minesweeper! Try to find the fields without mines.");
                    Console.WriteLine("{0} Commands {0}", new string('-', 10));
                    Console.WriteLine("'top' - show the leaderboard");
                    Console.WriteLine("'restart' - start a new game");
                    Console.WriteLine("'exit' - exit the game");

                    DrawField(field);
                    isNewGame = false;
                }

                Console.Write("Enter row and column separated by space: ");
                currentCommand = Console.ReadLine().Trim();

                if (currentCommand.Length >= 3)
                {
                    bool isInTheField = currentRow <= Constants.BoardRows && currentColumn <= Constants.BoardColumns;
                    bool isValidRow = int.TryParse(currentCommand[0].ToString(), out currentRow);
                    bool isValidColumn = int.TryParse(currentCommand[2].ToString(), out currentColumn);

                    if (isInTheField && isValidRow && isValidColumn)
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        PrintLeaderboard(leaders);
                        break;
                    case "restart":
                        field = CreateField();
                        mines = PlaceMines();
                        DrawField(field);
                        hitMine = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[currentRow, currentColumn] != '*')
                        {
                            if (mines[currentRow, currentColumn] == '-')
                            {
                                PlayTurn(field, mines, currentRow, currentColumn);
                                currentScore++;
                            }

                            if (MaxScore == currentScore)
                            {
                                isWon = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            hitMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nYou have entered an invalid command!\n");
                        break;
                }

                if (hitMine)
                {
                    DrawField(mines);
                    Console.Write("\nYou hit a mine! Your got {0} points. Enter your nickname: ", currentScore);
                    string nickname = Console.ReadLine();
                    Score score = new Score(nickname, currentScore);
                    if (leaders.Count < Constants.MaxLeaders)
                    {
                        leaders.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < leaders.Count; i++)
                        {
                            if (leaders[i].Points < score.Points)
                            {
                                leaders.Insert(i, score);
                                leaders.RemoveAt(leaders.Count - 1);
                                break;
                            }
                        }
                    }

                    leaders.Sort((Score firstScore, Score secondScore) => secondScore.Nickname.CompareTo(firstScore.Nickname));
                    leaders.Sort((Score firstScore, Score secondScore) => secondScore.Points.CompareTo(firstScore.Points));
                    PrintLeaderboard(leaders);

                    field = CreateField();
                    mines = PlaceMines();
                    currentScore = 0;
                    hitMine = false;
                    isNewGame = true;
                }

                if (isWon)
                {
                    Console.WriteLine("\nBRAVO! You got {0} points without hitting a mine!.", Constants.MaxScore);
                    DrawField(mines);
                    Console.WriteLine("Enter your nickname: ");
                    string nickname = Console.ReadLine();
                    Score score = new Score(nickname, currentScore);
                    leaders.Add(score);
                    PrintLeaderboard(leaders);
                    field = CreateField();
                    mines = PlaceMines();
                    currentScore = 0;
                    isWon = false;
                    isNewGame = true;
                }
            }
            while (currentCommand != "exit");

            Console.WriteLine("Made (and refactored :)) in Bulgaria!");
            Console.Read();
        }

        private static void PrintLeaderboard(List<Score> scores)
        {
            Console.WriteLine("\nLeaderboard:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, scores[i].Nickname, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The leaderboard is empty!\n");
            }
        }

        private static void PlayTurn(char[,] field, char[,] mines, int currentRow, int currentColumn)
        {
            char surroundingBombs = GetSurroundingBombsCount(mines, currentRow, currentColumn);
            mines[currentRow, currentColumn] = surroundingBombs;
            field[currentRow, currentColumn] = surroundingBombs;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            char[,] board = new char[Constants.BoardRows, Constants.BoardColumns];

            for (int i = 0; i < Constants.BoardRows; i++)
            {
                for (int j = 0; j < Constants.BoardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            const int FieldRows = Constants.BoardRows;
            const int FieldCols = Constants.BoardColumns;
            const int MaxMines = Constants.MaxMines;
            char[,] mineField = new char[FieldRows, FieldCols];

            for (int i = 0; i < FieldRows; i++)
            {
                for (int j = 0; j < FieldCols; j++)
                {
                    mineField[i, j] = '-';
                }
            }

            List<int> minePositions = new List<int>();

            while (minePositions.Count < MaxMines)
            {
                Random minePositionGenerator = new Random();
                int currentPosition = minePositionGenerator.Next(FieldRows * FieldCols);
                if (!minePositions.Contains(currentPosition))
                {
                    minePositions.Add(currentPosition);
                }
            }

            foreach (int position in minePositions)
            {
                int column = position / FieldCols;
                int row = position % FieldCols;

                if (row == 0 && position != 0)
                {
                    column--;
                    row = FieldCols;
                }
                else
                {
                    row++;
                }

                mineField[column, row - 1] = '*';
            }

            return mineField;
        }

        private static char GetSurroundingBombsCount(char[,] mineField, int currentRow, int currentColumn)
        {
            int surroundingMinesCount = 0;
            int rows = Constants.BoardRows;
            int columns = Constants.BoardColumns;

            if (currentRow - 1 >= 0)
            {
                if (mineField[currentRow - 1, currentColumn] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (mineField[currentRow + 1, currentColumn] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (mineField[currentRow, currentColumn - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if (currentColumn + 1 < columns)
            {
                if (mineField[currentRow, currentColumn + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (mineField[currentRow - 1, currentColumn - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < columns))
            {
                if (mineField[currentRow - 1, currentColumn + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn - 1 >= 0))
            {
                if (mineField[currentRow + 1, currentColumn - 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn + 1 < columns))
            {
                if (mineField[currentRow + 1, currentColumn + 1] == '*')
                {
                    surroundingMinesCount++;
                }
            }

            return char.Parse(surroundingMinesCount.ToString());
        }
    }
}