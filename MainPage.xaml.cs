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

        //punt knop
        //in XAML wordt door de "onclick" attribute een functie gedraaid  met die naam.
        //Door middel van de twee argumenten "Object sender, RouterEventArgs e" wordt de klik actie (event) geregistreert en gestuurd
        private void punt_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            input += ".";
            textbox1.Text += input;
        }

        private void hex_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            operand1 = input;
            input = "HEX";
            operation = 'h';
            textbox1.Text = input;

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

           /* TryParse(String, Double) probeert te converteren van een getal naar het dubbele precisie-getal met drijvende-kommagetal.Een retourwaarde geeft aan of de conversie is geslaagd of mislukt. 
            Als het is mislukt geeft hij geen error aan.*/
            double.TryParse(operand1, out getal1);
            double.TryParse(operand2, out getal2);

            //hier berekent hij de resultaten van de operators die zijn aangegeven.
            //if staat voor als, dus als het gelijk is aan. anders gaat hij naar de else-if.
            //als het false is.
            if (operation == '+')
            {
                result = getal1 + getal2;
                textbox1.Text = result.ToString();
            }

            else if (operation == 'h')
            {
                if (textbox1.Text.Contains("."))
                {
                    textbox1.Text = ("Syntax Error");
                }
                else
                {
                    int index = Convert.ToInt32(operand1);
                    if (index < 0)
                    {
                        index *= -1;
                    }

                    int result = index / 16;
                    int rest = index % 16;
                    String finalResult = "";

                    if (result != 0)
                    {
                        finalResult = "" + result;
                    }


                    /* These if statements check if we have to add a letter to the hexadecimal number or not. */
                    if (rest == 15)
                    {
                        finalResult += "F";
                    }
                    else if (rest == 14)
                    {
                        finalResult += "E";
                    }
                    else if (rest == 13)
                    {
                        finalResult += "D";
                    }
                    else if (rest == 12)
                    {
                        finalResult += "C";
                    }
                    else if (rest == 11)
                    {
                        finalResult += "B";
                    }
                    else if (rest == 10)
                    {
                        finalResult += "A";
                    }
                    else
                    {
                        finalResult += "" + rest;
                    }

                    textbox1.Text = finalResult;
                    textbox2.Text = index + " =";
                }
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


            // de wisselkoers van euro naar dollar is 1.11293 
            // de wisselkoers van dollar naar euro is 0.898528
            //Gebruik: Klik getal, klik dollar, klik = voor uitkomst
            else if (operation == '$')
            {
                result = getal1 * 0.898528;
                textbox1.Text = "€" + result.ToString();
            }

            else if (operation == '€')
            {
                result = getal1 * 1.11293;
                textbox1.Text = "$" + result.ToString();
            }

            if (operation == 'a')
            {

                double negatiefgetal = getal1 * -1;
                textbox1.Text = "-" + negatiefgetal.ToString();
            }
        }

        //(?)
        private void plusMin_click(object sender, RoutedEventArgs e)
        {

            operand1 = '-' + input;
            operation = 'a';
            //string empty zorgt er voor dat input leeg word gemaakt
            input = string.Empty;

            textbox1.Text = "-" + textbox1.Text;
        }

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
        //operand1 word input en het slaat dus alles op in de input.
        //operand1 word alleen gebruikt voor operators
        //de operation is '-' hier word het gekozen welke operator je wilt gebruiken.
        // en dit word dan gewoon een paar keer herhaald bij andere buttons.
        private void min_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "-";
            operand1 = input;
            operation = '-';
            input = string.Empty;
        }
        //plus klik
        private void plus_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "+";
            operand1 = input;
            operation = '+';
            input = string.Empty;
        }

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
        private void delen_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "÷";
            operand1 = input;
            operation = '/';
            input = string.Empty;
        }

        private void keer_click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "x";
            operand1 = input;
            operation = '*';
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
            if (textbox1.Text != "" && CheckSymbol(textbox1.Text))
            {
                textbox1.Text = textbox1.Text.Remove(textbox1.Text.Length - 1);
                if (input.Length > 0)
                    input = input.Remove(input.Length - 1);
            }
        }

        //met != && str geef je aan dat als je op alles klikt dat het dan geen
        //error geeft, geen bugs meer voorkomt.
        private bool CheckSymbol(string str)
        {
            if (str != "-" && str != "+" && str != "x" && str != "€" && str != "$" && str != "%" && str != "." && str != "NaN" && str != "÷" && str[0] != '-')
                return true;
            else
                return false;
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

        //Collapsed geeft het besturingselement niet weer en reserveert niet de witruimte.
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

            //Een CNN bestaat uit meerdere lagen. Elke laag is in feite een filter dat invoergegevens verwerkt en specifieke kenmerken van objecten extraheert.

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost;Database=master;Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageDialog dialog = new MessageDialog("text");
            cnn.Close();
        }

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
            //alleen uitvoeren als het textvak gevuld is EN als het aantal getallen niet meer is dan 3 EN dat de textbox niet gevuld is met iets anders dan een INT
            else if (textbox1.Text != "" && textbox1.Text.Length <= 3 && CheckSymbol(textbox1.Text))
            {
                //
                n = Convert.ToInt32(textbox1.Text);
                textbox2.Text = n + " =";

                if (n < 0)
                {
                    n *= -1;
                }

                /* Deze  FOR-loop verdeelt het nummer in het TextBoxDisplay om te controleren hoe lang het binaire getal is en om te controleren waar er een '1' of een '0' moet zijn */
                for (i = 0; n > 0; i++)
                {
                    a[i] = n % 2; // 1
                    n /= 2;
                }

                /* Deze FOR-loop gebruikt de date vanaf de array en stores het in de strings it 'finalResult' */
                for (i -= 1; i >= 0; i--)
                {
                    finalResult += "" + a[i];

                }

                textbox1.Text = finalResult;

            }


        }



        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            double newVar = result;
            textbox2.Text = newVar.ToString();
        }
    }
}