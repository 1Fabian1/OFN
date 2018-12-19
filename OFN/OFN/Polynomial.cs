using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.IO;
using Windows.UI.Popups;
using Windows.UI.Xaml;
namespace OFN
{
    class Polynomial
    {
        public async void CreateTextBoxes(TextBox textbox, Grid polynomialGrid, TextBox test)
        {
            polynomialGrid.Children.Clear();
            int numberOfTextBoxes = 3;
            int rightMargin = 70;
            int textBoxWidth = 200;
            var dialog = new MessageDialog("Stopień wielomianu musi być liczbą całkowitą i nie większą niż 20");
            try
            {
                numberOfTextBoxes = Int32.Parse(textbox.Text);
            }
            catch (Exception e)
            {
                if (!textbox.Text.Equals(""))
                {

                    await dialog.ShowAsync();
                    return;
                }
                return;
            }

            if (numberOfTextBoxes <= 20)
            {
                for (int i = 0; i < numberOfTextBoxes; i++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Name = "textBoxPolynomial" + i.ToString();
                    textBox.Width = 100;
                    textBox.Height = 70;
                    textBox.Header = "Value x^" + (numberOfTextBoxes - i).ToString();
                    textBox.Margin = new Thickness(0, 0, 0 +textBox.Width*i*2, 0);                 
                    polynomialGrid.Children.Add(textBox);

                }
            }
            else
            {
                dialog = new MessageDialog("Podaj liczbę mniejszą niż 20");
                await dialog.ShowAsync();
            }

             test.Text = polynomialGrid.Children.Count().ToString();


        }
    }
}
