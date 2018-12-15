using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OFN
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine("Trochę działań - podgląd w debugu");
            FuzzyNumber f1 = new FuzzyNumber(1, 2, 30, 0);
            FuzzyNumber f2 = new FuzzyNumber(1, 2, 3, 4);
            FuzzyNumber result = new FuzzyNumber(0, 0, 0, 0);
            Debug.WriteLine("f1: " + f1.ToString());
            Debug.WriteLine("f2: " + f2.ToString());
            result = FNAlgebra.divideAB(f1, f2);
            Debug.WriteLine("result: " + result.ToString());
            Debug.WriteLine("Fabianngita");
        }
    }
}
