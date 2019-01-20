using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using static System.Int32;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OFN
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool isPolynomialMode = false;

        FuzzyNumber resultToContinue = new FuzzyNumber();

        //Polynomial values
        private double freeValueA, freeValueB;
        private double valueXA, valueXB;
        private double valueX2A, valueX2B;
        private double valueX3A, valueX3B;
        private double valueX4A, valueX4B;
        private double valueX5A, valueX5B;
        private double valueX6A, valueX6B;
        private double valueX7A, valueX7B;
        private double valueX8A, valueX8B;
        private double valueX9A, valueX9B;
        private double valueX10A, valueX10B;
        List<double> upValuesOfPolynomials = new List<double>();
        List<double> downValuesOfPolynomials = new List<double>();

        //FN values
        private double a1;
        private double a2;
        private double a3;
        private double a4;
        private double b1;
        private double b2;
        private double b3;
        private double b4;

        List<Series> serie = new List<Series>();

        string polynomialUp = "", polynomialDown = "";

        public MainPage()
        {

            this.InitializeComponent();
            comboBoxPartOfPolynomial.Items.Add("Up");
            comboBoxPartOfPolynomial.Items.Add("Down");
            plotView.Model = PlotModelDefine.ZeroCrossingForOFN(30);
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            double scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result;
            ParseFNTextBoxes();
            TryParse(textBoxDiscretization.Text, out var disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.addAplusB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result + "}";
            var scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
            PlotModelDefine.ScalePlotOFN(plotView.Model, scale);
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, disPara, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, disPara, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, disPara, "Result"));
            plotView.InvalidatePlot();
        }


        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result;
            int scale = 0;
            ParseFNTextBoxes();

            TryParse(textBoxDiscretization.Text, out var disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.subtractAminusB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result + "}";
            scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
            PlotModelDefine.ScalePlotOFN(plotView.Model, scale);

            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, disPara, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, disPara, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, disPara, "Result"));
            plotView.InvalidatePlot();
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result;
            ParseFNTextBoxes();
            int disPara;
            TryParse(textBoxDiscretization.Text, out disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.multiplyAB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result + "}";
            var scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
            PlotModelDefine.ScalePlotOFN(plotView.Model, scale);

            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, disPara, "Number A"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, disPara, "Number B"));
            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, disPara, "Result"));
            plotView.InvalidatePlot();
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            FuzzyNumber result = new FuzzyNumber();
            int scale;
            ParseFNTextBoxes();
            TryParse(textBoxDiscretization.Text, out var disPara);
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4, disPara);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4, disPara);
            result = FNAlgebra.divideAB(fuzzyNumberA, fuzzyNumberB);
            if (fuzzyNumberA.detectFailureChange(result))
            {
                textBoxOutput.Text = "You can't divide by 0";
            }
            else
            {
                resultToContinue = result;
                textBoxOutput.Text = "{ " + result + "}";
                scale = result.findMaxValueOfFuzzyNumber(fuzzyNumberA, fuzzyNumberB, result);
                PlotModelDefine.ScalePlotOFN(plotView.Model, scale);

                plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA, disPara, "Number A"));
                plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberB, disPara, "Number B"));
                plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(result, disPara, "Result"));
                plotView.InvalidatePlot();
            }
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

        public void ParsePolynomialTextBoxes()
        {
            Double.TryParse(textBoxFreeValueA.Text, out freeValueA);
            Double.TryParse(textBoxFreeValueB.Text, out freeValueB);
            Double.TryParse(textBoxValueXA.Text, out valueXA);
            Double.TryParse(textBoxValueXB.Text, out valueXB);
            Double.TryParse(textBoxValueX2A.Text, out valueX2A);
            Double.TryParse(textBoxValueX2B.Text, out valueX2B);
            Double.TryParse(textBoxValueX3A.Text, out valueX3A);
            Double.TryParse(textBoxValueX3B.Text, out valueX3B);
            Double.TryParse(textBoxValueX4A.Text, out valueX4A);
            Double.TryParse(textBoxValueX4B.Text, out valueX4B);
            Double.TryParse(textBoxValueX5A.Text, out valueX5A);
            Double.TryParse(textBoxValueX5B.Text, out valueX5B);
            Double.TryParse(textBoxValueX6A.Text, out valueX6A);
            Double.TryParse(textBoxValueX6B.Text, out valueX6B);
            Double.TryParse(textBoxValueX7A.Text, out valueX7A);
            Double.TryParse(textBoxValueX7B.Text, out valueX7B);
            Double.TryParse(textBoxValueX8A.Text, out valueX8A);
            Double.TryParse(textBoxValueX8B.Text, out valueX8B);
            Double.TryParse(textBoxValueX9A.Text, out valueX9A);
            Double.TryParse(textBoxValueX9B.Text, out valueX9B);
            Double.TryParse(textBoxValueX10A.Text, out valueX10A);
            Double.TryParse(textBoxValueX10B.Text, out valueX10B);
        }

        public void ParseFNTextBoxes()
        {
            Double.TryParse(textBox1LA.Text.ToString(), out a1);
            Double.TryParse(textBox2mA.Text.ToString(), out a2);
            Double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            Double.TryParse(textBox4PA.Text.ToString(), out a4);
            Double.TryParse(textBox1LB.Text.ToString(), out b1);
            Double.TryParse(textBox2mB.Text.ToString(), out b2);
            Double.TryParse(textBox3pB.Text.ToString(), out b3);
            Double.TryParse(textBox4PB.Text.ToString(), out b4);
        }

        private void ButtonAddPolynomials_Click(object sender, RoutedEventArgs e)
        {
            
            ParsePolynomialTextBoxes();
            PolynomialAlgebra polynomialAlgebra = new PolynomialAlgebra();
            Polynomial polynomialResult = new Polynomial();
            PolynomialAlgebra algebra = new PolynomialAlgebra();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A,
                valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B,
                valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);
            polynomialResult = PolynomialAlgebra.addPolynomialAB(polynomialA, polynomialB);
            Double discretizationValue;
            Double.TryParse(textBoxDiscretization.Text.ToString(), out discretizationValue);

            if (comboBoxPartOfPolynomial.SelectedItem != null)
            {
                if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Up"))
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fa+Fb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fa)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }
                    upValuesOfPolynomials.Clear();
                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Up(Fa+Fb)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialA, "Up(Fa)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialB, "Up(Fb)", discretizationValue));
                    countUpForAandB(algebra, polynomialA, polynomialB, polynomialResult);
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 0));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 0));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 0));
                    upValuesOfPolynomials.Sort();
                }
                else
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Ga+Gb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Ga)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Gb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }
                    downValuesOfPolynomials.Clear();
                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Down(Ga+Gb)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialA, "Down(Ga)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialB, "Down(Gb)", discretizationValue));
                    countDownforAandB(algebra, polynomialA, polynomialB, polynomialResult);

                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 0));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 0));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 0));
                    downValuesOfPolynomials.Sort();
                }
            }

            if(upValuesOfPolynomials.Count > 0 && downValuesOfPolynomials.Count > 0)
            {
                if (upValuesOfPolynomials[5] >= downValuesOfPolynomials[5])
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = upValuesOfPolynomials[5] + 5;
                }
                else
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = downValuesOfPolynomials[5] + 5;
                }


                if (upValuesOfPolynomials[0] <= downValuesOfPolynomials[0])
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = upValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = upValuesOfPolynomials[0] - 5;
                }
                else
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = downValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = downValuesOfPolynomials[0] - 5;
                }
            }
            else
            {
                if (upValuesOfPolynomials.Count > 0)
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = upValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = upValuesOfPolynomials[0] - 5;
                } else if (downValuesOfPolynomials.Count > 0)
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = downValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = downValuesOfPolynomials[0] - 5;
                }
            }


            representResult();
            plotView.InvalidatePlot(true);
            
        }

      

        private void ButtonSubstractPolynomials_Click(object sender, RoutedEventArgs e)
        {
            ParsePolynomialTextBoxes();
            PolynomialAlgebra polynomialAlgebra = new PolynomialAlgebra();
            Polynomial polynomialResult = new Polynomial();
            PolynomialAlgebra algebra = new PolynomialAlgebra();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A,
                valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B,
                valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);
            polynomialResult = PolynomialAlgebra.substractPolynomialAB(polynomialA, polynomialB);
            Double discretizationValue;
            Double.TryParse(textBoxDiscretization.Text.ToString(), out discretizationValue);

            if (comboBoxPartOfPolynomial.SelectedItem != null)
            {
                if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Up"))
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fa+Fb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fa)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }
                    upValuesOfPolynomials.Clear();
                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Up(Fa+Fb)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialA, "Up(Fa)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialB, "Up(Fb)", discretizationValue));
                    countUpForAandB(algebra, polynomialA, polynomialB, polynomialResult);
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 0));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 0));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 0));
                    upValuesOfPolynomials.Sort();
                }
                else
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Ga+Gb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Ga)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Gb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }
                    downValuesOfPolynomials.Clear();
                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Down(Ga+Gb)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialA, "Down(Ga)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialB, "Down(Gb)", discretizationValue));
                    countDownforAandB(algebra, polynomialA, polynomialB, polynomialResult);

                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 0));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 0));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 0));
                    downValuesOfPolynomials.Sort();
                }
            }

            if (upValuesOfPolynomials.Count > 0 && downValuesOfPolynomials.Count > 0)
            {
                if (upValuesOfPolynomials[5] >= downValuesOfPolynomials[5])
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = upValuesOfPolynomials[5] + 5;
                }
                else
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = downValuesOfPolynomials[5] + 5;
                }


                if (upValuesOfPolynomials[0] <= downValuesOfPolynomials[0])
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = upValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = upValuesOfPolynomials[0] - 5;
                }
                else
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = downValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = downValuesOfPolynomials[0] - 5;
                }
            }
            else
            {
                if (upValuesOfPolynomials.Count > 0)
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = upValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = upValuesOfPolynomials[0] - 5;
                }
                else if (downValuesOfPolynomials.Count > 0)
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = downValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = downValuesOfPolynomials[0] - 5;
                }
            }


            representResult();
            plotView.InvalidatePlot(true);

        }

        private void ButtonMultiplyPolynomials_Click(object sender, RoutedEventArgs e)
        {
            ParsePolynomialTextBoxes();
            PolynomialAlgebra polynomialAlgebra = new PolynomialAlgebra();
            Polynomial polynomialResult = new Polynomial();
            PolynomialAlgebra algebra = new PolynomialAlgebra();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A,
                valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B,
                valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);
            polynomialResult = PolynomialAlgebra.multiplyPolynomialAB(polynomialA, polynomialB);
            Double discretizationValue;
            Double.TryParse(textBoxDiscretization.Text.ToString(), out discretizationValue);

            if (comboBoxPartOfPolynomial.SelectedItem != null)
            {
                if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Up"))
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fa+Fb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fa)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up(Fb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }
                    upValuesOfPolynomials.Clear();
                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Up(Fa+Fb)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialA, "Up(Fa)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialB, "Up(Fb)", discretizationValue));
                    countUpForAandB(algebra, polynomialA, polynomialB, polynomialResult);
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 1));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 0));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 0));
                    upValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 0));
                    upValuesOfPolynomials.Sort();
                }
                else
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Ga+Gb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Ga)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down(Gb)"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }
                    downValuesOfPolynomials.Clear();
                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Down(Ga+Gb)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialA, "Down(Ga)", discretizationValue));
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialB, "Down(Gb)", discretizationValue));
                    countDownforAandB(algebra, polynomialA, polynomialB, polynomialResult);

                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 1));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialA, 0));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialB, 0));
                    downValuesOfPolynomials.Add(polynomialAlgebra.countValueFromFunction(polynomialResult, 0));
                    downValuesOfPolynomials.Sort();
                }
            }

            if (upValuesOfPolynomials.Count > 0 && downValuesOfPolynomials.Count > 0)
            {
                if (upValuesOfPolynomials[5] >= downValuesOfPolynomials[5])
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = upValuesOfPolynomials[5] + 5;
                }
                else
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = downValuesOfPolynomials[5] + 5;
                }


                if (upValuesOfPolynomials[0] <= downValuesOfPolynomials[0])
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = upValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = upValuesOfPolynomials[0] - 5;
                }
                else
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = downValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = downValuesOfPolynomials[0] - 5;
                }
            }
            else
            {
                if (upValuesOfPolynomials.Count > 0)
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = upValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = upValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = upValuesOfPolynomials[0] - 5;
                }
                else if (downValuesOfPolynomials.Count > 0)
                {
                    plotView.Model.Axes.ElementAt(0).AbsoluteMaximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).Maximum = downValuesOfPolynomials[5] + 5;
                    plotView.Model.Axes.ElementAt(0).AbsoluteMinimum = downValuesOfPolynomials[0] - 5;
                    plotView.Model.Axes.ElementAt(0).Minimum = downValuesOfPolynomials[0] - 5;
                }
            }


            representResult();
            plotView.InvalidatePlot(true);

        }

        private void ButtonChangeMode_Click(object sender, RoutedEventArgs e)
        {
            if (isPolynomialMode)
            {
                PolynomialFNGrid.Margin = new Thickness(960, 0, 0, 0);
                PlotViewGrid.Margin = new Thickness(0, 540, 0, 0);
                plotView.Width = 1920;
                plotView.Height = 540;
                PlotViewGrid.Height = 540;
                PlotViewGrid.Width = 1920;
                plotView.Model = PlotModelDefine.ZeroCrossingForOFN(30);
                isPolynomialMode = false;
                buttonAddPolynomials.IsEnabled = false;
                buttonSubstractPolynomials.IsEnabled = false;
                buttonMultiplyPolynomials.IsEnabled = false;
                buttonDividePolynomials.IsEnabled = false;
                buttonAdd.IsEnabled = true;
                buttonSubtract.IsEnabled = true;
                buttonMultiply.IsEnabled = true;
                buttonDivide.IsEnabled = true;
            }
            else
            {
                PolynomialFNGrid.Margin = new Thickness(0, 400, 0, 0);
                PlotViewGrid.Margin = new Thickness(960, 0, 0, 0);
                plotView.Width = 960;
                plotView.Height = 1080;
                PlotViewGrid.Height = 1080;
                PlotViewGrid.Width = 960;
                plotView.Model = PlotModelDefine.ZeroCrossingForPolynomial(30);
                isPolynomialMode = true;
                buttonAddPolynomials.IsEnabled = true;
                buttonSubstractPolynomials.IsEnabled = true;
                buttonMultiplyPolynomials.IsEnabled = true;
                buttonDividePolynomials.IsEnabled = true;
                buttonAdd.IsEnabled = false;
                buttonSubtract.IsEnabled = false;
                buttonMultiply.IsEnabled = false;
                buttonDivide.IsEnabled = false;

            }
        }

        private void ButtonDividePolynomials_Click(object sender, RoutedEventArgs e)
        {
            ParsePolynomialTextBoxes();
            plotView.Model.Series.Clear();
            plotView.Model.InvalidatePlot(true);
        }


        private void ButtonClearPlot_Click(object sender, RoutedEventArgs e)
        {
            plotView.Model.Series.Clear();
            plotView.Model.InvalidatePlot(true);

        }

        private void representResult()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(polynomialUp);
            builder.Append(" ");
            builder.Append(polynomialDown);
            textBoxOutput.Text = builder.ToString();
        }

        private void countDownforAandB(PolynomialAlgebra algebra, Polynomial polynomialA, Polynomial polynomialB,
            Polynomial polynomialResult)
        {
            a3 = algebra.countValueFromFunction(polynomialA, 0);
            a4 = algebra.countValueFromFunction(polynomialA, 1);
            b3 = algebra.countValueFromFunction(polynomialB, 0);
            b4 = algebra.countValueFromFunction(polynomialB, 1);
            
            textBoxk3pA.Text = a3.ToString();
            textBox4PA.Text = a4.ToString();
            textBox3pB.Text = b3.ToString();
            textBox4PB.Text = b4.ToString();
            polynomialDown = algebra.countValueFromFunction(polynomialResult, 0).ToString() + " " +
                             algebra.countValueFromFunction(polynomialResult, 1).ToString();
        }

        private void countUpForAandB(PolynomialAlgebra algebra, Polynomial polynomialA, Polynomial polynomialB,
            Polynomial polynomialResult)
        {
            a1 = algebra.countValueFromFunction(polynomialA, 0);
            a2 = algebra.countValueFromFunction(polynomialA, 1);
            b1 = algebra.countValueFromFunction(polynomialB, 0);
            b2 = algebra.countValueFromFunction(polynomialB, 1);
            textBox1LA.Text = a1.ToString();
            textBox2mA.Text = a2.ToString();
            textBox1LB.Text = b1.ToString();
            textBox2mB.Text = b2.ToString();
            polynomialUp = algebra.countValueFromFunction(polynomialResult, 0).ToString() + " " +
                           algebra.countValueFromFunction(polynomialResult, 1).ToString();
        }

        private void TextBox1LA_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox2mA_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBoxk3pA_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox4PA_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBoxDiscretization_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox1LB_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox2mB_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox3pB_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox4PB_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}