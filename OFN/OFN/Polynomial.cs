﻿using System;
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
        
        List<UIElement> listOfTextBoxes = new List<UIElement>();
        public async void CreateTextBoxes(TextBox textBoxNumberTextBoxes, Grid polynomialGrid)
        {           
            int numberOfTextBoxes = 0;
            var dialog = new MessageDialog("Stopień wielomianu musi być liczbą całkowitą i nie większą niż 10.");

            foreach (var children in polynomialGrid.Children)
            {
                listOfTextBoxes.Add(children);
                
            }

            for (int i = 0; i <= listOfTextBoxes.Count() - 3; i++)
            {
                listOfTextBoxes[i + 2].Visibility = Visibility.Collapsed;
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
                for(int i=0; i <= numberOfTextBoxes; i++)
                {
                    if(numberOfTextBoxes <= listOfTextBoxes.Count() - 2)
                        listOfTextBoxes[i + 1].Visibility = Visibility.Visible;                 
                }
            }
            listOfTextBoxes.Clear();


            // TODO -----------> Algorytm liczacy up&down podanych wielomianow
            // test.Text = polynomialGrid.Children.Count().ToString();


        }
    }
}
