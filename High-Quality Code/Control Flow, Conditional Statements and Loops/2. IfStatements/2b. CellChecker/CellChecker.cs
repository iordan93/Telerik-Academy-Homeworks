using System;

public class CellChecker
{
    private static int minX;
    private static int maxX;
    private static int minY;
    private static int maxY;

    private bool shouldVisitCell;

    public void CheckCell(Cell cellToCheck)
    {
        bool isValidCol = cellToCheck.X >= minX && cellToCheck.X <= maxX;
        bool isValidRow = cellToCheck.Y >= minY && cellToCheck.Y <= maxY;

        if (isValidRow && isValidCol && !this.shouldVisitCell)
        {
           this.VisitCell(cellToCheck);
        }
    }

    private void VisitCell(Cell cellToVisit)
    {
        // ...
    }
}