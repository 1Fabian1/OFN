using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OFN
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        FuzzyNumber resultToContinue = new FuzzyNumber();

        public MainPage()
        {


            this.InitializeComponent();
            comboBoxPartOfPolynomial.Items.Add("Up");
            comboBoxPartOfPolynomial.Items.Add("Down");
            plotView.Model = PlotModelDefine.ZeroCrossing();

            //Rysowanie po punktach
            OxyPlot.Series.LineSeries lineSeries = new OxyPlot.Series.LineSeries();
            lineSeries.Points.Add(new OxyPlot.DataPoint());
            lineSeries.Points.Add(new OxyPlot.DataPoint(3, 1));
            lineSeries.Points.Add(new OxyPlot.DataPoint(5, 1));
            lineSeries.Points.Add(new OxyPlot.DataPoint(6, 0));


            lineSeries.Color = OxyColor.FromRgb(100, 200, 100);
            lineSeries.Title = "Test";
            //plotView.Model.Series.Add(lineSeries);

            //Rysowanie funkcji
            //plotView.Model.Series.Add(new FunctionSeries(Math.Cos, 0, 40, 0.1, "cox(x)"));



            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();

            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            double scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            
            plotView.Model.Series.Clear();
            FuzzyNumber result = new FuzzyNumber();
            int scale = 0;

            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            Int32 disPara; Int32.TryParse(textBoxDiscretization.Text.ToString(), out disPara);

            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.addAplusB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
            scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA,fuzzyNumberB,result);
            plotView.Model = PlotModelDefine.ZeroCrossing(scale+5);
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, "Result"));
            plotView.InvalidatePlot(true);  //refreshes plotView

        }


        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result = new FuzzyNumber();
            int scale = 0;

            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            Int32 disPara; Int32.TryParse(textBoxDiscretization.Text.ToString(), out disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.subtractAminusB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
            scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
            plotView.Model = PlotModelDefine.ZeroCrossing(scale + 5);

            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, "Result"));
            plotView.InvalidatePlot(true);

        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result = new FuzzyNumber();
            int scale = 0;

            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            Int32 disPara; Int32.TryParse(textBoxDiscretization.Text.ToString(), out disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.multiplyAB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
            scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
            plotView.Model = PlotModelDefine.ZeroCrossing(scale + 5);

            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, "Result"));
            plotView.InvalidatePlot(true);

        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result = new FuzzyNumber();
            int scale = 0;

            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            Int32 disPara; Int32.TryParse(textBoxDiscretization.Text.ToString(), out disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.divideAB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
            scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
            plotView.Model = PlotModelDefine.ZeroCrossing(scale + 5);

            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, "Result"));
            plotView.InvalidatePlot(true);

        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            
            textBox1LA.Text = "";
            textBox2mA.Text = "";
            textBoxk3pA.Text = "";
            textBox4PA.Text = "";
            textBox1LB.Text = "";
            textBox2mB.Text = "";
            textBox3pB.Text = "";
            textBox4PB.Text = "";
            textBoxOutput.Text = "";
            textBoxDiscretization.Text = "";
            plotView.Model.Series.Clear();

        }

        private void ButtonCountFromResult_Click(object sender, RoutedEventArgs e)
        {
            textBox1LA.Text = resultToContinue.Pos1.ToString();
            textBox2mA.Text = resultToContinue.Pos2.ToString();
            textBoxk3pA.Text = resultToContinue.Pos3.ToString();
            textBox4PA.Text = resultToContinue.Pos4.ToString();
        }

        private void TextBoxDegreeOfPolynomialA_TextChanged(object sender, TextChangedEventArgs e)
        {
            PolynomialTextBoes polynomial = new PolynomialTextBoes();
            polynomial.CreateTextBoxes(textBoxDegreeOfPolynomialA, PolynomialAFNGrid);
        }

        private void TextBoxDegreeOfPolynomialB_TextChanged(object sender, TextChangedEventArgs e)
        {
            PolynomialTextBoes polynomial = new PolynomialTextBoes();
            polynomial.CreateTextBoxes(textBoxDegreeOfPolynomialB, PolynomialBFNGrid);
        }

        private void ButtonAddPolynomials_Click(object sender, RoutedEventArgs e)
        {

            double freeValueA, freeValueB;
            Double.TryParse(textBoxFreeValueA.Text, out freeValueA); Double.TryParse(textBoxFreeValueB.Text, out freeValueB);
            double valueXA, valueXB;
            Double.TryParse(textBoxValueXA.Text, out valueXA); Double.TryParse(textBoxValueXB.Text, out valueXB);
            double valueX2A, valueX2B;
            Double.TryParse(textBoxValueX2A.Text, out valueX2A); Double.TryParse(textBoxValueX2B.Text, out valueX2B);
            double valueX3A, valueX3B;
            Double.TryParse(textBoxValueX3A.Text, out valueX3A); Double.TryParse(textBoxValueX3B.Text, out valueX3B);
            double valueX4A, valueX4B;
            Double.TryParse(textBoxValueX4A.Text, out valueX4A); Double.TryParse(textBoxValueX4B.Text, out valueX4B);
            double valueX5A, valueX5B;
            Double.TryParse(textBoxValueX5A.Text, out valueX5A); Double.TryParse(textBoxValueX5B.Text, out valueX5B);
            double valueX6A, valueX6B;
            Double.TryParse(textBoxValueX6A.Text, out valueX6A); Double.TryParse(textBoxValueX6B.Text, out valueX6B);
            double valueX7A, valueX7B;
            Double.TryParse(textBoxValueX7A.Text, out valueX7A); Double.TryParse(textBoxValueX7B.Text, out valueX7B);
            double valueX8A, valueX8B;
            Double.TryParse(textBoxValueX8A.Text, out valueX8A); Double.TryParse(textBoxValueX8B.Text, out valueX8B);
            double valueX9A, valueX9B;
            Double.TryParse(textBoxValueX9A.Text, out valueX9A); Double.TryParse(textBoxValueX9B.Text, out valueX9B);
            double valueX10A, valueX10B;
            Double.TryParse(textBoxValueX10A.Text, out valueX10A); Double.TryParse(textBoxValueX10B.Text, out valueX10B);

            Polynomial polynomialResult = new Polynomial();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A, valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B, valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);

            polynomialResult = PolynomialAlgebra.addPolynomialAB(polynomialA, polynomialB);
            plotView.Model.Series.Clear();


            plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Tytył"));

            if (comboBoxPartOfPolynomial.SelectedItem != null)
            {
                if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Up"))
                {
                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                }
                else if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Down"))
                {
                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                }
            }



        }

        private void ButtonSubstractPolynomials_Click(object sender, RoutedEventArgs e)
        {
            double freeValueA, freeValueB;
            Double.TryParse(textBoxFreeValueA.Text, out freeValueA); Double.TryParse(textBoxFreeValueB.Text, out freeValueB);
            double valueXA, valueXB;
            Double.TryParse(textBoxValueXA.Text, out valueXA); Double.TryParse(textBoxValueXB.Text, out valueXB);
            double valueX2A, valueX2B;
            Double.TryParse(textBoxValueX2A.Text, out valueX2A); Double.TryParse(textBoxValueX2B.Text, out valueX2B);
            double valueX3A, valueX3B;
            Double.TryParse(textBoxValueX3A.Text, out valueX3A); Double.TryParse(textBoxValueX3B.Text, out valueX3B);
            double valueX4A, valueX4B;
            Double.TryParse(textBoxValueX4A.Text, out valueX4A); Double.TryParse(textBoxValueX4B.Text, out valueX4B);
            double valueX5A, valueX5B;
            Double.TryParse(textBoxValueX5A.Text, out valueX5A); Double.TryParse(textBoxValueX5B.Text, out valueX5B);
            double valueX6A, valueX6B;
            Double.TryParse(textBoxValueX6A.Text, out valueX6A); Double.TryParse(textBoxValueX6B.Text, out valueX6B);
            double valueX7A, valueX7B;
            Double.TryParse(textBoxValueX7A.Text, out valueX7A); Double.TryParse(textBoxValueX7B.Text, out valueX7B);
            double valueX8A, valueX8B;
            Double.TryParse(textBoxValueX8A.Text, out valueX8A); Double.TryParse(textBoxValueX8B.Text, out valueX8B);
            double valueX9A, valueX9B;
            Double.TryParse(textBoxValueX9A.Text, out valueX9A); Double.TryParse(textBoxValueX9B.Text, out valueX9B);
            double valueX10A, valueX10B;
            Double.TryParse(textBoxValueX10A.Text, out valueX10A); Double.TryParse(textBoxValueX10B.Text, out valueX10B);

            Polynomial polynomialResult = new Polynomial();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A, valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B, valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);

            polynomialResult = PolynomialAlgebra.substractPolynomialAB(polynomialA, polynomialB);

            if (comboBoxPartOfPolynomial.SelectedItem != null)
            {
                if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Up"))
                {
                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                }
                else if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Down"))
                {
                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                }
            }

        }


        private void ButtonMultiplyPolynomials_Click(object sender, RoutedEventArgs e)
        {
            double freeValueA, freeValueB;
            Double.TryParse(textBoxFreeValueA.Text, out freeValueA); Double.TryParse(textBoxFreeValueB.Text, out freeValueB);
            double valueXA, valueXB;
            Double.TryParse(textBoxValueXA.Text, out valueXA); Double.TryParse(textBoxValueXB.Text, out valueXB);
            double valueX2A, valueX2B;
            Double.TryParse(textBoxValueX2A.Text, out valueX2A); Double.TryParse(textBoxValueX2B.Text, out valueX2B);
            double valueX3A, valueX3B;
            Double.TryParse(textBoxValueX3A.Text, out valueX3A); Double.TryParse(textBoxValueX3B.Text, out valueX3B);
            double valueX4A, valueX4B;
            Double.TryParse(textBoxValueX4A.Text, out valueX4A); Double.TryParse(textBoxValueX4B.Text, out valueX4B);
            double valueX5A, valueX5B;
            Double.TryParse(textBoxValueX5A.Text, out valueX5A); Double.TryParse(textBoxValueX5B.Text, out valueX5B);
            double valueX6A, valueX6B;
            Double.TryParse(textBoxValueX6A.Text, out valueX6A); Double.TryParse(textBoxValueX6B.Text, out valueX6B);
            double valueX7A, valueX7B;
            Double.TryParse(textBoxValueX7A.Text, out valueX7A); Double.TryParse(textBoxValueX7B.Text, out valueX7B);
            double valueX8A, valueX8B;
            Double.TryParse(textBoxValueX8A.Text, out valueX8A); Double.TryParse(textBoxValueX8B.Text, out valueX8B);
            double valueX9A, valueX9B;
            Double.TryParse(textBoxValueX9A.Text, out valueX9A); Double.TryParse(textBoxValueX9B.Text, out valueX9B);
            double valueX10A, valueX10B;
            Double.TryParse(textBoxValueX10A.Text, out valueX10A); Double.TryParse(textBoxValueX10B.Text, out valueX10B);

            Polynomial polynomialResult = new Polynomial();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A, valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B, valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);

            polynomialResult = PolynomialAlgebra.multiplyPolynomialAB(polynomialA, polynomialB);
            if (comboBoxPartOfPolynomial.SelectedItem.Equals("Up"))
            {
                textBoxResultUpPolynomail.Text = polynomialResult.TextPolynomial;
            }
            else if (comboBoxPartOfPolynomial.SelectedItem.Equals("Down"))
            {
                textBoxResultDownPolynomail.Text = polynomialResult.TextPolynomial;
            }

        }

        private void ButtonDividePolynomials_Click(object sender, RoutedEventArgs e)
        {
            double freeValueA, freeValueB;
            Double.TryParse(textBoxFreeValueA.Text, out freeValueA); Double.TryParse(textBoxFreeValueB.Text, out freeValueB);
            double valueXA, valueXB;
            Double.TryParse(textBoxValueXA.Text, out valueXA); Double.TryParse(textBoxValueXB.Text, out valueXB);
            double valueX2A, valueX2B;
            Double.TryParse(textBoxValueX2A.Text, out valueX2A); Double.TryParse(textBoxValueX2B.Text, out valueX2B);
            double valueX3A, valueX3B;
            Double.TryParse(textBoxValueX3A.Text, out valueX3A); Double.TryParse(textBoxValueX3B.Text, out valueX3B);
            double valueX4A, valueX4B;
            Double.TryParse(textBoxValueX4A.Text, out valueX4A); Double.TryParse(textBoxValueX4B.Text, out valueX4B);
            double valueX5A, valueX5B;
            Double.TryParse(textBoxValueX5A.Text, out valueX5A); Double.TryParse(textBoxValueX5B.Text, out valueX5B);
            double valueX6A, valueX6B;
            Double.TryParse(textBoxValueX6A.Text, out valueX6A); Double.TryParse(textBoxValueX6B.Text, out valueX6B);
            double valueX7A, valueX7B;
            Double.TryParse(textBoxValueX7A.Text, out valueX7A); Double.TryParse(textBoxValueX7B.Text, out valueX7B);
            double valueX8A, valueX8B;
            Double.TryParse(textBoxValueX8A.Text, out valueX8A); Double.TryParse(textBoxValueX8B.Text, out valueX8B);
            double valueX9A, valueX9B;
            Double.TryParse(textBoxValueX9A.Text, out valueX9A); Double.TryParse(textBoxValueX9B.Text, out valueX9B);
            double valueX10A, valueX10B;
            Double.TryParse(textBoxValueX10A.Text, out valueX10A); Double.TryParse(textBoxValueX10B.Text, out valueX10B);

            Polynomial polynomialResult = new Polynomial();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A, valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B, valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);

            polynomialResult = PolynomialAlgebra.dividePolynomialAB(polynomialA, polynomialB);
            if (comboBoxPartOfPolynomial.SelectedItem.Equals("Up"))
            {
                textBoxResultUpPolynomail.Text = polynomialResult.TextPolynomial;
            }
            else if (comboBoxPartOfPolynomial.SelectedItem.Equals("Down"))
            {
                textBoxResultDownPolynomail.Text = polynomialResult.TextPolynomial;
            }
        }



    }
}
