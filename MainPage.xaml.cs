using System;
using System.Collections.Generic;
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

namespace rekenmachine1sprint2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string text = "";
        private bool komma = false;
        private double getal1, getal2, uitkomst;
        private bool euro = true;
        private bool dollar = false;
        private bool erbij = false, eraf = false, maal = false, delen = false;
        public MainPage()
        {
            this.InitializeComponent();
        }
        //knop 0
        private void btnNul_Click(object sender, RoutedEventArgs e)
        {
            text += "0";
            tbDisplay.Text = text;
        }
        //knop 1
        private void btnEen_Click(object sender, RoutedEventArgs e)
        {
            text += "1";
            tbDisplay.Text = text;
        }
        //knop 2
        private void btnTwee_Click(object sender, RoutedEventArgs e)
        {
            text += "2";
            tbDisplay.Text = text;
        }
        //knop 3
        private void btnDrie_Click(object sender, RoutedEventArgs e)
        {
            text += "3";
            tbDisplay.Text = text;
        }
        //knop 4
        private void btnVier_Click(object sender, RoutedEventArgs e)
        {
            text += "4";
            tbDisplay.Text = text;
        }
        //knop 5
        private void btnVijf_Click(object sender, RoutedEventArgs e)
        {
            text += "5";
            tbDisplay.Text = text;
        }
        //knop 6
        private void btnZes_Click(object sender, RoutedEventArgs e)
        {
            text += "6";
            tbDisplay.Text = text;
        }
        //knop 7
        private void btnZeven_Click(object sender, RoutedEventArgs e)
        {
            text += "7";
            tbDisplay.Text = text;
        }
        //knop 8
        private void btnAcht_Click(object sender, RoutedEventArgs e)
        {
            text += "8";
            tbDisplay.Text = text;
        }
        //knop 9
        private void btnNegen_Click(object sender, RoutedEventArgs e)
        {
            text += "9";
            tbDisplay.Text = text;
        }
        //knop komma
        private void komma_Click(object sender, RoutedEventArgs e)
        {
            if (komma != true)
            {
                komma = true;
                if (text == "")
                    text = "0,";
                else
                    text += ",";

                tbDisplay.Text = text;
            }
        }
        //knop plus
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                erbij = true;
                text = "";
                tbDisplay.Text = "";
                komma = false;
            }
        }
        //knop min
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                eraf = true;
                text = "";
                tbDisplay.Text = "";
                komma = false;
            }
        }
        //knop keer
        private void btnKeer_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                maal = true;
                text = "";
                tbDisplay.Text = "";
                komma = false;
            }
        }
        //knop delen
        private void btnDeel_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                delen = true;
                text = "";
                tbDisplay.Text = "";
                komma = false;
            }
        }
        //knop Percentage
        private void btnPrencentage_Click(object sender, RoutedEventArgs e)
        {

        }
        //knop euro
        private void btnEuro_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                if (!euro)
                {
                    string newText = tbDisplay.Text.Replace(',', '.');
                    getal1 = Convert.ToDouble(newText);
                    newText = EuroConverter(getal1).ToString();
                    tbDisplay.Text = newText.Replace('.', ',');
                    euro = true;
                    dollar = false;
                }
            }
        }
        //knop Dollar
        private void btnDollar_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                if (!dollar)
                {
                    string newText = tbDisplay.Text.Replace(',', '.');
                    getal1 = Convert.ToDouble(newText);
                    newText = DollarConverter(getal1).ToString();
                    tbDisplay.Text = newText.Replace('.', ',');
                    euro = false;
                    dollar = true;
                }
            }
        }
        //knop Wissen
        private void btnWis_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            tbDisplay.Text = text;
            komma = false;
            erbij = false;
            eraf = false;
            maal = false;
            delen = false;
            getal1 = 0;
            getal2 = 0;
        }
        //knop Reset
        private void btnWis1_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            tbDisplay.Text = text;
            komma = false;
            erbij = false;
            eraf = false;
            maal = false;
            delen = false;
            getal1 = 0;
            getal2 = 0;
        }
        //knop komma getallen
        private void btnBinear_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal1 = Convert.ToInt32(newText);

                int i;

                int[] binaryArray = new int[10];

                for (i = 0; getal1 > 0; i++)
                {
                    binaryArray[i] = (int)getal1 % 2;
                    getal1 = (int)getal1 / 2;
                }
                newText = "";
                for (i = i - 1; i >= 0; i--)
                {
                    newText += (binaryArray[i]);
                    tbDisplay.Text = newText.Replace('.', ',');
                }
            }
           
        }
        //knop Hex
        private void btnHex_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                
                
                tbDisplay.Text = newText.Replace('.', ',');

            }

        }
        //knop plus-min
        private void btnPlusmin_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                getal1 = getal1 * -1;
                newText = (getal1).ToString();
                tbDisplay.Text = newText.Replace('.', ',');
            }
        }

        //Rekenen plus
        private double add(double a, double b)
        {
            return a + b;
        }
        //Rekenen min
        private double minus(double a, double b)
        {
            return a - b;
        }
        //Rekenen keer
        private double multply(double a, double b)
        {
            return a * b;
        }
        //Rekenen gedeeld
        private double divide(double a, double b)
        {
            return a / b;
        }
        //Rekenen Euro Omrekenen
        private double EuroConverter(double a)
        {
            return a * 1.3;
        }
        //Rekenen Dollar Omrekenen
        private double DollarConverter(double a)
        {
            return a / 1.3;
        }
        //knop Bereken
        private void btnBereken_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplay.Text != "")
            {
                string newText = tbDisplay.Text.Replace(',', '.');
                getal2 = Convert.ToDouble(newText);
                text = "";
                tbDisplay.Text = "";
                komma = false;

                if (eraf == true)
                {
                    newText = minus(getal1, getal2).ToString();
                    tbDisplay.Text = newText.Replace('.', ',');
                    eraf = false;
                }
                else if (erbij == true)
                {
                    newText = add(getal1, getal2).ToString();
                    tbDisplay.Text = newText.Replace('.', ',');
                    erbij = false;
                }
                else if (maal == true)
                {
                    newText = multply(getal1, getal2).ToString();
                    tbDisplay.Text = newText.Replace('.', ',');
                    maal = false;
                }
                else if (delen == true)
                {
                    newText = divide(getal1, getal2).ToString();
                    tbDisplay.Text = newText.Replace('.', ',');
                    delen = false;
                }
            }
        }
    }
}
    