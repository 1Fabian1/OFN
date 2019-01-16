using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFN
{
    class PlotModelDefine
    {

        public static PlotModel ZeroCrossingForOFN(int scale)
        {
            var plotModel = new PlotModel();
            plotModel.PlotAreaBorderThickness = new OxyThickness(0.0);
            plotModel.PlotMargins = new OxyThickness(10);
            plotModel.LegendFontSize = 24;

            var YlinearAxis = new LinearAxis();
            YlinearAxis.Maximum = 2;
            YlinearAxis.Minimum = -2;
            YlinearAxis.AbsoluteMaximum = 2;
            YlinearAxis.AbsoluteMinimum = -2;
            YlinearAxis.PositionAtZeroCrossing = true;
            YlinearAxis.AxislineStyle = LineStyle.LongDash;
            YlinearAxis.TickStyle = TickStyle.Crossing;
            YlinearAxis.TitlePosition = 0;
            YlinearAxis.Title = "y";
            YlinearAxis.TitleFontSize = 20;
            YlinearAxis.FilterMaxValue = 1.001;
            YlinearAxis.FilterMinValue = -0.001;
            plotModel.Axes.Add(YlinearAxis);

            var XlinearAxis = new LinearAxis();
            XlinearAxis.Maximum = scale;
            XlinearAxis.Minimum = -scale;
            XlinearAxis.AbsoluteMaximum = scale;
            XlinearAxis.AbsoluteMinimum = -scale;
            XlinearAxis.Position = AxisPosition.Bottom;
            XlinearAxis.PositionAtZeroCrossing = true;
            XlinearAxis.TickStyle = TickStyle.Crossing;
            XlinearAxis.AxislineStyle = LineStyle.LongDash;
            XlinearAxis.TitlePosition = 0;
            XlinearAxis.Title = "x";
            XlinearAxis.TitleFontSize = 20;
            plotModel.Axes.Add(XlinearAxis);


            return plotModel;
        }

        public static void ScalePlotOFN(PlotModel plotModel,int scale)
        {
            plotModel.Axes.ElementAt(1).Maximum = scale +5;
            plotModel.Axes.ElementAt(1).Minimum = -scale -5;
            plotModel.Axes.ElementAt(1).AbsoluteMaximum = scale + 5;
            plotModel.Axes.ElementAt(1).AbsoluteMinimum = -scale - 5;

        }

        public static PlotModel ZeroCrossingForPolynomial(int scale)
        {
            var plotModel = new PlotModel();
            plotModel.PlotAreaBorderThickness = new OxyThickness(0.0);
            plotModel.PlotMargins = new OxyThickness(10);
            plotModel.LegendFontSize = 24;
             
            var YlinearAxis = new LinearAxis();
            YlinearAxis.Maximum = scale;
            YlinearAxis.Minimum = -scale;
            YlinearAxis.AbsoluteMaximum = scale*10;
            YlinearAxis.AbsoluteMinimum = -scale*10;
            YlinearAxis.PositionAtZeroCrossing = true;
            YlinearAxis.AxislineStyle = LineStyle.LongDash;
            YlinearAxis.TickStyle = TickStyle.Crossing;
            YlinearAxis.TitlePosition = 0;
            YlinearAxis.Title = "x";
            YlinearAxis.TitleFontSize = 20;

            plotModel.Axes.Add(YlinearAxis);

            var XlinearAxis = new LinearAxis();
            XlinearAxis.Maximum = 2;
            XlinearAxis.Minimum = -2;
            XlinearAxis.AbsoluteMaximum = 2;
            XlinearAxis.AbsoluteMinimum = -2;
            XlinearAxis.Position = AxisPosition.Bottom;
            XlinearAxis.PositionAtZeroCrossing = true;
            XlinearAxis.TickStyle = TickStyle.Crossing;
            XlinearAxis.AxislineStyle = LineStyle.LongDash;
            XlinearAxis.TitlePosition = 0;
            XlinearAxis.Title = "y";
            XlinearAxis.TitleFontSize = 20;
            XlinearAxis.FilterMaxValue = 1.001;
            XlinearAxis.FilterMinValue = -0.001;
            plotModel.Axes.Add(XlinearAxis);


            return plotModel;
        }

        public static void ScalePlotPolynomialPlot(PlotModel plotModel, int scale)
        {
            plotModel.Axes.ElementAt(0).Maximum = scale + 5;
            plotModel.Axes.ElementAt(0).Minimum = -scale - 5;
            plotModel.Axes.ElementAt(0).AbsoluteMaximum = scale + 5;
            plotModel.Axes.ElementAt(0).AbsoluteMinimum = -scale - 5;
        }

        public static FunctionSeries DrawFunction(Polynomial polynomial, string title, double discretizationValue)
        {
            Func<double, double> fx = (x) => polynomial.ValueX10 * Math.Pow(x, 10) + polynomial.ValueX9 * Math.Pow(x, 9) + polynomial.ValueX8 * Math.Pow(x, 8) + polynomial.ValueX7 * Math.Pow(x, 7)
                                               + polynomial.ValueX6 * Math.Pow(x, 6) + polynomial.ValueX5 * Math.Pow(x, 5) + polynomial.ValueX4 * Math.Pow(x, 4)
                                               + polynomial.ValueX3 * Math.Pow(x, 3) + polynomial.ValueX2 * Math.Pow(x, 2) + polynomial.ValueX * x + polynomial.FreeValue;
            if(discretizationValue < 10)
            {
                discretizationValue = 10;
            }
            var functionSeries = new FunctionSeries(fx, -100, 100, 1/discretizationValue, title)
            {
                MarkerSize = 2,
                MarkerType = MarkerType.Diamond
               
            };
            
            


            return functionSeries;
        }



        public static LineSeries drawFuzzyNumber(FuzzyNumber fuzzyNumber, string title)
        {

            LineSeries lineSeries = new LineSeries();
            lineSeries.Points.Add(new DataPoint(fuzzyNumber.Pos1, 0));
            lineSeries.Points.Add(new DataPoint(fuzzyNumber.Pos2, 1));
            lineSeries.Points.Add(new DataPoint(fuzzyNumber.Pos3, 1));
            lineSeries.Points.Add(new DataPoint(fuzzyNumber.Pos4, 0));
            lineSeries.Title = title;
            return lineSeries;
        }

    }
}
