using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CircleAndCyllinderController : FigureController
{
    public override void ExecuteFigureCreationCommand(string[] splitFigString)
    {
        switch (splitFigString[0])
        {
            // Create a circle or a cyllinder. If the figure to create is different, execute the base creation parser
            case "circle":
                Vector3D center = Vector3D.Parse(splitFigString[1]);
                currentFigure = new Circle(center, double.Parse(splitFigString[2]));
                break;
            case "cylinder":
                Vector3D topCenter = Vector3D.Parse(splitFigString[1]);
                Vector3D bottomCenter = Vector3D.Parse(splitFigString[2]);
                currentFigure = new Cyllinder(bottomCenter, topCenter, double.Parse(splitFigString[3]));
                break;

            default:
                base.ExecuteFigureCreationCommand(splitFigString);
                break;
        }

        this.EndCommandExecuted = false;
    }

    protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
    {
        switch (splitCommand[0])
        {
            // Get the area, volume, or normal of the current figure. If the command is not found, execute the base command parser  
            case "area":
                if (this.currentFigure is IAreaMeasurable)
                {
                    Console.WriteLine("{0:0.00}",(this.currentFigure as IAreaMeasurable).GetArea());
                }
                else Console.WriteLine("undefined");
                break;

            case "volume":
                if (this.currentFigure is IVolumeMeasurable)
                {
                    Console.WriteLine("{0:0.00}", (this.currentFigure as IVolumeMeasurable).GetVolume());
                }
                else Console.WriteLine("undefined");
                break;

            case "normal":
                if (this.currentFigure is IFlat)
                {
                    Console.WriteLine("{0:0.00}",(this.currentFigure as IFlat).GetNormal());
                }
                else Console.WriteLine("undefined");
                break;

            default:
                base.ExecuteFigureInstanceCommand(splitCommand);
                break;
        }
    }
}
