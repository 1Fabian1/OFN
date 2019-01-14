using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.IO;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using System.Text.RegularExpressions;

namespace OFN
{
    class PolynomialTextBoes
    {

        List<TextBox> listOfTextBoxes = new List<TextBox>();
        public async void CreateTextBoxes(TextBox textBoxNumberTextBoxes, Grid polynomialGrid)
        {
            int numberOfTextBoxes = 0;
            var dialog = new MessageDialog("Stopień wielomianu musi być liczbą całkowitą i nie większą niż 10.");

            foreach (TextBox children in polynomialGrid.Children)
            {
                listOfTextBoxes.Add(children);

            }
            System.Diagnostics.Debug.Write(listOfTextBoxes.Count().ToString());
            for (int i = 2; i <= listOfTextBoxes.Count() - 1; i++)
            {
                listOfTextBoxes[i].Visibility = Visibility.Collapsed;
            }

            try
            {
                numberOfTextBoxes = Int32.Parse(textBoxNumberTextBoxes.Text);
            }
            catch (Exception e)


            {
                if (!textBoxNumberTextBoxes.Text.Equals(""))
                {

                    await dialog.ShowAsync();
                    return;
                }
                return;
            }


            if (numberOfTextBoxes > 10)
            {
                dialog = new MessageDialog("Podaj liczbę mniejszą lub równą 10.");
                await dialog.ShowAsync();
            }
            else
            {
                for (int i = 1; i <= numberOfTextBoxes; i++)
                {
                    if (numberOfTextBoxes <= listOfTextBoxes.Count())
                        listOfTextBoxes[i + 1].Visibility = Visibility.Visible;
                }

                for (int i = numberOfTextBoxes + 3; i <= listOfTextBoxes.Count(); i++)
                {
                    listOfTextBoxes[i - 1].Text = "";
                }

            }
            listOfTextBoxes.Clear();




        }

        public bool checkIfNumber(String textBoxInput)
        {
            bool checkIfNumber = false;

            try
            {
                if (Regex.IsMatch(textBoxInput, @"^\d+$"))
                {
                    checkIfNumber = true;
                }
            }
            catch (Exception e)
            {
                checkIfNumber = false;
            }
            return checkIfNumber;
        }
    }
}
