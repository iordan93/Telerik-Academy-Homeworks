namespace Figure
{
    using System;

    public class Rotator
    {
        public static Size GetRotatedSize(Size currentSize, double angle)
        {
            // This is more easily done using a matrix of rotation
            double sinOfAngle = Math.Abs(Math.Sin(angle));
            double cosOfAngle = Math.Abs(Math.Cos(angle));

            double width = (cosOfAngle * currentSize.Width) + (sinOfAngle * currentSize.Height);
            double height = (sinOfAngle * currentSize.Width) + (cosOfAngle * currentSize.Height);
            
            return new Size(width, height);
        }
    }
}
