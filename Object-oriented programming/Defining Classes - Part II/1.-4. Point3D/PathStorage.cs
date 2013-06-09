using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Text;

namespace _1._4.Point3D
{
    public class PathStorage
    {
        public static Path LoadPathFromFile(string pathToFile)
        {
            Path path = new Path();
            StreamReader reader = new StreamReader(pathToFile);
            // Read lines one by one and parse them to points
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    path.Add(Point3DParse(line));
                    line = reader.ReadLine();
                }
            }
            return path;
        }

        public static void SavePathToFile(Path path, string pathToFile)
        {
            // Read each point and write it to a StringBuilder. Finally, write the StringBuilder to a file
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(pathToFile);
            foreach (Point3D point in path.SequenceOfPoints)
            {
                string pointString = point.ToString().Trim(new char[] { '(', ')' });
                builder.AppendLine(pointString);
            }
            using (writer)
            {
                writer.WriteLine(builder.ToString());
            }
        }

        private static Point3D Point3DParse(string pointString)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Read points, split them to get individual coordinates and pass them as parameters to a new point
            string[] split = pointString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
            Point3D point = new Point3D(double.Parse(split[0]), double.Parse(split[1]), double.Parse(split[2]));
            return point;
        }
    }
}
