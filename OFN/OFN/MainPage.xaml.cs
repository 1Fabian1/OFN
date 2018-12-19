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
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            double scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);

            Debug.WriteLine("Trochę działań - podgląd w debugu");
            FuzzyNumber f1 = new FuzzyNumber(1, 2, 30, 1);
            FuzzyNumber f2 = new FuzzyNumber(1, 2, 3, 4);
            FuzzyNumber result = new FuzzyNumber(0, 0, 0, 0);
            Debug.WriteLine("f1: " + f1.ToString());
            Debug.WriteLine("f2: " + f2.ToString());
            result = FNAlgebra.divideAB(f1, f2);
            Debug.WriteLine("result: " + result.ToString());

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            FuzzyNumber result = new FuzzyNumber();
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4);
            result = FNAlgebra.addAplusB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
        }


        private void Canva_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 3;
            //line.Width = 50;
            line.X1 = 20;
            line.Y1 = 0;
            line.X2 = 150;
            line.Y2 = 100;

            Canvas.SetTop(line, 50);
            Canvas.SetLeft(line, 50);


            //CanvasGrid.Children.Add(line);
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            FuzzyNumber result = new FuzzyNumber();
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4);
            result = FNAlgebra.subtractAminusB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            FuzzyNumber result = new FuzzyNumber();
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4);
            result = FNAlgebra.multiplyAB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            double a1; double.TryParse(textBox1LA.Text.ToString(), out a1);
            double a2; double.TryParse(textBox2mA.Text.ToString(), out a2);
            double a3; double.TryParse(textBoxk3pA.Text.ToString(), out a3);
            double a4; double.TryParse(textBox4PA.Text.ToString(), out a4);
            double b1; double.TryParse(textBox1LB.Text.ToString(), out b1);
            double b2; double.TryParse(textBox2mB.Text.ToString(), out b2);
            double b3; double.TryParse(textBox3pB.Text.ToString(), out b3);
            double b4; double.TryParse(textBox4PB.Text.ToString(), out b4);
            FuzzyNumber result = new FuzzyNumber();
            FuzzyNumber fuzzyNumberA = new FuzzyNumber(a1, a2, a3, a4);
            FuzzyNumber fuzzyNumberB = new FuzzyNumber(b1, b2, b3, b4);
            result = FNAlgebra.divideAB(fuzzyNumberA, fuzzyNumberB);
            resultToContinue = result;
            textBoxOutput.Text = "{ " + result.ToString() + "}";
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
        }

        private void ButtonCountFromResult_Click(object sender, RoutedEventArgs e)
        {
            textBox1LA.Text = resultToContinue.Pos1.ToString();
            textBox2mA.Text = resultToContinue.Pos2.ToString();
            textBoxk3pA.Text = resultToContinue.Pos3.ToString();
            textBox4PA.Text = resultToContinue.Pos4.ToString();
        }

        private void TextBoxDegreeOfPolynomial_TextChanged(object sender, TextChangedEventArgs e)
        {
            Polynomial polynomial = new Polynomial();
            polynomial.CreateTextBoxes(textBoxDegreeOfPolynomial, polynomialGrid, textBox1LA);
        }
    }
}
