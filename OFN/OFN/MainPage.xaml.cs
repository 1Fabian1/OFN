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

            plotView.Model.Series.Add(PlotModelDefine.drawFuzzyNumber(fuzzyNumberA,disPara, "Number A"));
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
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }

                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Up",
                        discretizationValue));

                    countUpForAandB(algebra, polynomialA, polynomialB, polynomialResult);
                }
                else
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }

                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Down",
                        discretizationValue));

                    countDownforAandB(algebra, polynomialA, polynomialB, polynomialResult);
                }
            }

            representResult();

            plotView.Model.InvalidatePlot(true);
        }

      

        private void ButtonSubstractPolynomials_Click(object sender, RoutedEventArgs e)
        {
            ParsePolynomialTextBoxes();

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
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }

                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Up",
                        discretizationValue));

                    countUpForAandB(algebra, polynomialA, polynomialB, polynomialResult);
                }
                else
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }

                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Down",
                        discretizationValue));

                    countDownforAandB(algebra, polynomialA, polynomialB, polynomialResult);
                }
            }

            representResult();
            //PlotModelDefine.ScalePlotPolynomialPlot(plotView.Model, 250);
            plotView.Model.InvalidatePlot(true);
        }

        private void ButtonMultiplyPolynomials_Click(object sender, RoutedEventArgs e)
        {
            ParsePolynomialTextBoxes();

            Polynomial polynomialResult = new Polynomial();
            PolynomialAlgebra algebra = new PolynomialAlgebra();
            Polynomial polynomialA = new Polynomial(freeValueA, valueXA, valueX2A, valueX3A, valueX4A, valueX5A,
                valueX6A, valueX7A, valueX8A, valueX9A, valueX10A);
            Polynomial polynomialB = new Polynomial(freeValueB, valueXB, valueX2B, valueX3B, valueX4B, valueX5B,
                valueX6B, valueX7B, valueX8B, valueX9B, valueX10B);
            polynomialResult = PolynomialAlgebra.multiplyPolynomialAB(polynomialA, polynomialB);
            Double.TryParse(textBoxDiscretization.Text.ToString(), out var discretizationValue);

            if (comboBoxPartOfPolynomial.SelectedItem != null)
            {
                if (comboBoxPartOfPolynomial.SelectedItem.ToString().Equals("Up"))
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Up"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }

                    textBoxResultUpPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Up",
                        discretizationValue));

                    countUpForAandB(algebra, polynomialA, polynomialB, polynomialResult);
                }
                else
                {
                    for (int i = 0; i < plotView.Model.Series.Count; i++)
                    {
                        if (plotView.Model.Series.ElementAt(i).Title.Equals("Down"))
                        {
                            plotView.Model.Series.RemoveAt(i);
                        }
                    }

                    textBoxResultDownPolynomail.Text = polynomialResult.ToString();
                    plotView.Model.Series.Add(PlotModelDefine.DrawFunction(polynomialResult, "Down",
                        discretizationValue));

                    countDownforAandB(algebra, polynomialA, polynomialB, polynomialResult);
                }
            }
            representResult();

            plotView.Model.InvalidatePlot(true);
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
            /*
            PolynomialTextBoes boes = new PolynomialTextBoes();
            bool test = boes.checkIfNumber(textBox4PB.Text.ToString());
            if (test)
            {

            }
            else
            {
                textBox4PB.Text = "";
            }
            */
        }
    }
}