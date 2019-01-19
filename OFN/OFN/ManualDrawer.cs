using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace OFN
{

    class ManualDrawer
    {
        //value of number "one" on chart - max value
        private readonly double VALUE_OF_ONE = 200;
        private double scaleClass = 0;


        //draws starting lines of OX Axis
        public void drawAxis(Canvas canvas)
        {
            var horizontalLine = new Line();
            var vertical = new Line();
            var setOneLine = new Line();
            horizontalLine.Stroke = new SolidColorBrush(Colors.Black);
            horizontalLine.StrokeThickness = 2;
            vertical.Stroke = new SolidColorBrush(Colors.Black);
            vertical.StrokeThickness = 2;
            setOneLine.Stroke = new SolidColorBrush(Colors.Black);
            setOneLine.StrokeThickness = 2;

            //line horizontal
            horizontalLine.X1 = 10;
            horizontalLine.Y1 = 400;
            horizontalLine.X2 = 1900;
            horizontalLine.Y2 = 400;

            //line vertical
            vertical.X1 = 960;
            vertical.Y1 = 400;
            vertical.X2 = 960;
            vertical.Y2 = 100;

            //line to set "1"
            setOneLine.X1 = 940;
            setOneLine.Y1 = VALUE_OF_ONE;
            setOneLine.X2 = 980;
            setOneLine.Y2 = VALUE_OF_ONE;

            displayText(canvas, "1", 920, 185);
            displayText(canvas, "0", 955, 400);
            displayText(canvas, "X", 1880, 400);
            displayText(canvas, "Y", 920, 100);
            displayText(canvas, ">", 1890, 384);
            displayText(canvas, @"/\", 952, 91);


            canvas.Children.Add(horizontalLine);
            canvas.Children.Add(setOneLine);
            canvas.Children.Add(vertical);

        }

        public void drawFuzzyNumber(Canvas canvas, FuzzyNumber fuzzyNumber, Color colorBrush)
        {
            var upLine = new Line();
            var horizontalLine = new Line();
            var downLine = new Line();

            upLine.Stroke = new SolidColorBrush(colorBrush);
            upLine.StrokeThickness = 3;
            horizontalLine.Stroke = new SolidColorBrush(colorBrush);
            horizontalLine.StrokeThickness = 3;
            downLine.Stroke = new SolidColorBrush(colorBrush);
            downLine.StrokeThickness = 3;


            upLine.X1 = converterX(fuzzyNumber.Pos1, fuzzyNumber);
            upLine.Y1 = converterY(0);
            upLine.X2 = converterX(fuzzyNumber.Pos2, fuzzyNumber);
            upLine.Y2 = converterY(VALUE_OF_ONE);

            horizontalLine.X1 = converterX(fuzzyNumber.Pos2, fuzzyNumber);
            horizontalLine.Y1 = converterY(VALUE_OF_ONE);
            horizontalLine.X2 = converterX(fuzzyNumber.Pos3, fuzzyNumber);
            horizontalLine.Y2 = converterY(VALUE_OF_ONE);

            downLine.X1 = converterX(fuzzyNumber.Pos3, fuzzyNumber);
            downLine.Y1 = converterY(VALUE_OF_ONE);
            downLine.X2 = converterX(fuzzyNumber.Pos4, fuzzyNumber);
            downLine.Y2 = converterY(0);


            canvas.Children.Add(upLine);
            canvas.Children.Add(horizontalLine);
            canvas.Children.Add(downLine);
        }

        // returns value referenced to point [0,0] (X), scales canvas
        private double converterX(double XnumberToConvert, FuzzyNumber fuzzyNumber)
        {
            double tempXnumberToConvert = 0;
            double maxFromFuzzyNumber = Math.Abs(FuzzyNumber.findMaxValueOfFuzzyNumber(fuzzyNumber));
            double scale = 0;

            if (scaleClass == 0)
            {
                scale = 960 / maxFromFuzzyNumber / 2;
                scaleClass = scale;
            }
            else
            {
                scale = scaleClass;
            }

            //960 = 0 on X
            tempXnumberToConvert = XnumberToConvert * scale + 960;


            return tempXnumberToConvert;
        }

        // returns value referenced to point [0,0] (Y)
        private double converterY(double YnumberToConvert)
        {
            double tempYnumberToConvert = 0;

            //400 = 0 on Y

            tempYnumberToConvert = 400 - YnumberToConvert;

            return tempYnumberToConvert;
        }

        public void clearCanvas(Canvas canvas)
        {
            canvas.Children.Clear();
        }

        private static void displayText(Canvas canvas, string text, int x, int y)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 20;
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }

    }
}
