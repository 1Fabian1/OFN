﻿using OxyPlot;
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

        public static PlotModel ZeroCrossing()
        {
            var plotModel = new PlotModel();
            plotModel.PlotAreaBorderThickness = new OxyThickness(0.0);
            plotModel.PlotMargins = new OxyThickness(10);
            plotModel.LegendFontSize = 24;

            var XlinearAxis = new LinearAxis();
            XlinearAxis.Maximum = 2;
            XlinearAxis.Minimum = -2;
            XlinearAxis.AbsoluteMaximum = 2;
            XlinearAxis.AbsoluteMinimum = -2;
            XlinearAxis.PositionAtZeroCrossing = true;

            XlinearAxis.AxislineStyle = LineStyle.LongDash;
            XlinearAxis.TickStyle = TickStyle.Crossing;
            XlinearAxis.Title = "x";
            XlinearAxis.Tag = "x";

            plotModel.Axes.Add(XlinearAxis);

            var YlinearAxis = new LinearAxis();
            YlinearAxis.Maximum = 30;
            YlinearAxis.Minimum = -30;
            YlinearAxis.AbsoluteMaximum = 32;
            YlinearAxis.AbsoluteMinimum = -32;
            YlinearAxis.Position = AxisPosition.Bottom;
            YlinearAxis.PositionAtZeroCrossing = true;
            YlinearAxis.TickStyle = TickStyle.Crossing;
            YlinearAxis.AxislineStyle = LineStyle.LongDash;
            plotModel.Axes.Add(YlinearAxis);


            return plotModel;
        }

        public static PlotModel zeroCrossing(int scale)
        {
            var plotModel = new PlotModel();
            plotModel.PlotAreaBorderThickness = new OxyThickness(0.0);
            plotModel.PlotMargins = new OxyThickness(10);
            plotModel.LegendFontSize = 24;

            var XlinearAxis = new LinearAxis();
            XlinearAxis.Maximum = 2;
            XlinearAxis.Minimum = -2;
            XlinearAxis.AbsoluteMaximum = 2;
            XlinearAxis.AbsoluteMinimum = -2;
            XlinearAxis.PositionAtZeroCrossing = true;

            XlinearAxis.AxislineStyle = LineStyle.LongDash;
            XlinearAxis.TickStyle = TickStyle.Crossing;
            XlinearAxis.Title = "x";
            XlinearAxis.Tag = "x";

            plotModel.Axes.Add(XlinearAxis);

            var YlinearAxis = new LinearAxis();
            YlinearAxis.Maximum = scale;
            YlinearAxis.Minimum = -scale;
            YlinearAxis.AbsoluteMaximum = scale;
            YlinearAxis.AbsoluteMinimum = -scale;
            YlinearAxis.Position = AxisPosition.Bottom;
            YlinearAxis.PositionAtZeroCrossing = true;
            YlinearAxis.TickStyle = TickStyle.Crossing;
            YlinearAxis.AxislineStyle = LineStyle.LongDash;
            plotModel.Axes.Add(YlinearAxis);


            return plotModel;
        }


        public static FunctionSeries DrawFunction(Polynomial polynomial, string title)
        {
            Func<double, double> fx = (x) => polynomial.ValueX10 * Math.Pow(x, 10) + polynomial.ValueX9 * Math.Pow(x, 9) + polynomial.ValueX8 * Math.Pow(x, 8) + polynomial.ValueX7 * Math.Pow(x, 7)
                                               + polynomial.ValueX6 * Math.Pow(x, 6) + polynomial.ValueX5 * Math.Pow(x, 5) + polynomial.ValueX4 * Math.Pow(x, 4)
                                               + polynomial.ValueX3 * Math.Pow(x, 3) + polynomial.ValueX2 * Math.Pow(x, 2) + polynomial.ValueX * x + polynomial.FreeValue;

            var functionSeries = new FunctionSeries(fx, -5, 5, 0.001, title)
            {
                TextColor = OxyColor.FromRgb(100, 100, 100),
                MarkerSize = 10,

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

            return lineSeries;
        }

    }
}
