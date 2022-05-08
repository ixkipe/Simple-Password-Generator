using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Practice_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool lettersEnabled = false;
        private bool digitsEnabled = false;
        private bool symbolsEnabled = false;
        private int numberOfCharacters = 8;

        private string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private string symbols = "()~!@#$%^&*-+=|{}[]:;'<>,.?_";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AlphabeticChars_Checked(object sender, RoutedEventArgs e)
        {
            lettersEnabled = true;
        }
        private void AlphabeticChars_Unchecked(object sender, RoutedEventArgs e)
        {
            lettersEnabled = false;
        }

        private void NumericChars_Checked(object sender, RoutedEventArgs e)
        {
            digitsEnabled = true;
        }
        private void NumericChars_Unchecked(object sender, RoutedEventArgs e)
        {
            digitsEnabled = false;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (!lettersEnabled && !digitsEnabled && !symbolsEnabled)
                MessageBox.Show("You must select at least one option.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                NewPass.Visibility = Visibility.Visible;
                PasswordContainer.Visibility = Visibility.Visible;
                ClipboardCopy.Visibility = Visibility.Visible;
                PasswordContainer.Text = CreateRandomPassword();
            }
        }

        private void SymbolsChars_Checked(object sender, RoutedEventArgs e)
        {
            symbolsEnabled = true;
        }
        private void SymbolsChars_Unchecked(object sender, RoutedEventArgs e)
        {
            symbolsEnabled = false;
        }

        private void IncrementCharNumber_Click(object sender, RoutedEventArgs e)
        {
            numberOfCharacters = (numberOfCharacters + 1 <= 20) ? numberOfCharacters + 1 : numberOfCharacters;
            CharNumberEdit.Text = numberOfCharacters.ToString();
        }

        private void DecrementCharNumber_Click(object sender, RoutedEventArgs e)
        {
            numberOfCharacters = (numberOfCharacters - 1 > 0) ? numberOfCharacters - 1 : numberOfCharacters;
            CharNumberEdit.Text = numberOfCharacters.ToString();
        }

        private string CreateRandomPassword()
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();

            while (sb.Length < numberOfCharacters)
            {
                int randTemp = r.Next(3);
                if (randTemp == 0 && lettersEnabled)
                    sb.Append(r.Next(2) == 1? alphabet[r.Next(alphabet.Length)] : alphabet[r.Next(alphabet.Length)].ToString().ToUpper());
                else if (randTemp == 1 && symbolsEnabled)
                    sb.Append(symbols[r.Next(symbols.Length)]);
                else if (randTemp == 2 && digitsEnabled)
                    sb.Append(r.Next(10));
            }
            return sb.ToString();
        }

        private void ClipboardCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PasswordContainer.Text);
        }
    }
}
