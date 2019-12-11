using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Rekenmachine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /* variabelen die worden gebruikt in de code
        string.empty zorgt ervoor dat de cijfers worden gewist die zijn opgeslagen in de variabelen */
        // result is 0.0 zorgt ervoor dat de result altijd bij het opstarten 0.0 is
        string input = string.Empty;
        public string operand1 = string.Empty;
        public string operand2 = string.Empty;
        double getal1, getal2;
        public double value;
        public double result = 0.0;
        public char operation;

        private void punt_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += ".";
            textbox1.Text += input;
        }

        private void nul_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "0";
            textbox1.Text += input;
        }

        private void antwoord_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input = result.ToString();
            textbox1.Text += input;
        }


        // Eerste paar lijnen van code maakt van getal1, getal2, operand1 en operand2 een double
        // als operation een operator is (+,-,/,x, enz.) dan is result getal1 *operator* getal2
        /* als bij gedeelt door getal2 niet 0 = dan gaat hij het berekenen en laat hij het zien
        en anders laat hij een error zien want je kunt iets niet door 0 delen */
        //bij de dollar en euro tekens gebruik ik *result is de formule van omrekenen van dollar naar euro*.

        public void equals_click(object sender, RoutedEventArgs e)
        {

            operand2 = input;
            double.TryParse(operand1, out getal1);
            double.TryParse(operand2, out getal2);

            if (operation == '+')
            {
                result = getal1 + getal2;
                textbox1.Text = result.ToString();
            }

            else if (operation == '-')
            {
                result = getal1 - getal2;
                textbox1.Text = result.ToString();
            }
            else if (operation == '*')
            {
                result = getal1 * getal2;
                textbox1.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (getal2 != 0)
                {
                    result = getal1 / getal2;
                    textbox1.Text = result.ToString();
                }
                else
                {
                    textbox1.Text = "error";
                }
            }
            else if (operation == '%')
            {
                result = getal1 % getal2;
                textbox1.Text = result.ToString();
            }

            else if (operation == '$')
            {
                result = getal1 * 1.10092510737;
                textbox1.Text = "€" + result.ToString();
            }

            else if (operation == '€')
            {
                result = getal1 * 0.908633;
                textbox1.Text = "$" + result.ToString();
            }

            if (operation == 'a')
            {

                double negatiefgetal = getal1 * -1;
                textbox1.Text = negatiefgetal.ToString();
            }
        }

        //ik snap dit zelf ook niet en weet niet hoe ik het moet maken
        private void plusMin_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "-";
            operand1 = '-' + input;
            operation = 'a';
            input = string.Empty;
        }

        /* maakt eerst de textbox leeg (hoefde niet per se ziet er alleen iets beter uit, het gaat raar doen wanneer ik dit niet doe. 
        De cijfers worden dan elke keer verdubbeld) */
        //input = 1 + het gene wat ervoor kwam
        //textbox.Text laat de nummers zien van input.
        //en dit word herhaald bij de nummers 0 t/m 9
        private void een_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "1";
            textbox1.Text += input;
        }

        private void twee_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "2";
            textbox1.Text += input;
        }

        private void drie_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "3";
            textbox1.Text += input;

        }

        //laat de min zien in de textbox
        //operand1 word input het dus alles op in de input en operand1 word alleen gebruikt voor operators
        //de operation is '-' hier word het gekozen welke operator je wilt gebruiken.
        //string.Empty heb ik eerder al uitgelegd en dat zorgt er voor dat input leeg word gemaakt
        // en dit word dan gewoon een paar keer herhaald bij ander buttons

        private void vier_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "4";
            textbox1.Text += input;
        }

        private void vijf_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "5";
            textbox1.Text += input;
        }

        private void zes_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "6";
            textbox1.Text += input;
        }

        private void zeven_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "7";
            textbox1.Text += input;
        }

        private void acht_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "8";
            textbox1.Text += input;
        }


        private void negen_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += "9";
            textbox1.Text += input;
        }

        private void keer_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "x";
            operand1 = input;
            operation = '*';
            input = string.Empty;
        }

        private void delen_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "÷";
            operand1 = input;
            operation = '/';
            input = string.Empty;
        }

        private void min_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "-";
            operand1 = input;
            operation = '-';
            input = string.Empty;
        }

        private void plus_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "+";
            operand1 = input;
            operation = '+';
            input = string.Empty;
        }

        //de clear knop zorgt er voor dat alles leeg komt te staan
        private void clear_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;

        }

        //ik heb deze code gevonden wist nameijk niet precies hoe ik het moest maken, maar snap de code wel.
        //https://www.dreamincode.net/forums/topic/116442-calculator-make-delete-button/
        //de eerste zorgt ervoor dat elke keer de text textbox tekst lengte met - 1 word gewist en de andere doet het bij de input 
        private void delete_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = textbox1.Text.Remove(textbox1.Text.Length - 1);
            input = input.Remove(input.Length - 1);
        }

        private void euro_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "€";
            operand1 = input;
            operation = '€';
            input = string.Empty;

        }
        private void modulo_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "%";
            operand1 = input;
            operation = '%';
            input = string.Empty;
        }

        private void dollar_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "$";
            operand1 = input;
            operation = '$';
            input = string.Empty;
        }
        //binary to hexidecimal
        private void bin_click(object sender, RoutedEventArgs e)
        {
            /* Here are all the variables that we are going to need to use */
            int i, n;
            int[] a = new int[10];
            string finalResult = "";


            if (textbox1.Text.Contains("."))
            {
                textbox1.Text = ("Syntax Error");

            }
            else
            {
                n = Convert.ToInt32(textbox1.Text);
                textbox2.Text = n + " =";

                if (n < 0)
                {
                    n *= -1;
                }

                /* This for-loop divides the number in the TextBoxDisplay to check how long the binary number is and to check where there has to be a '1' or a '0'*/
                for (i = 0; n > 0; i++)
                {
                    a[i] = n % 2; // 1
                    n /= 2;
                }

                /* This for-loop grabs the data from the array and stores it in the String 'finalResult' */
                for (i -= 1; i >= 0; i--)
                {
                    finalResult += "" + a[i];

                }

                textbox1.Text = finalResult;

            }
        }

        //textbox management that shows sql database history of previously inputted values to the calculator
        private void history_click(object sender, RoutedEventArgs e)
        {
            if (textbox2.Visibility == Visibility.Visible)
            {
                textbox2.Visibility = Visibility.Collapsed;
            }
            else if (textbox2.Visibility == Visibility.Collapsed)
            {
                textbox2.Visibility = Visibility.Visible;
            }
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            double newVar = getal1 + getal2 + result;
            textbox2.Text = newVar.ToString();
        }
    }
}