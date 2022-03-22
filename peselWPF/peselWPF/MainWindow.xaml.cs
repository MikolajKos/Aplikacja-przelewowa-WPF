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

namespace peselWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(null, null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pesel pesel = new Pesel(peselTx.Text);
                plecTB.Text = pesel.Plec;
                dataTB.Text = pesel.Data;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Błąd");
            }
        }
    }
}
