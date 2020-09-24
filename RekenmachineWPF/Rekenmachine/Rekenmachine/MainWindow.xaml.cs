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

namespace Rekenmachine
{

    public partial class MainWindow : Window
    {
        TextBlock outputBlock;
        

        public MainWindow()
        {
            InitializeComponent();
            outputBlock = (TextBlock)FindName("label");
        }

        private void onButton1Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "1";
        }

        private void onButton2Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "2";
        }

        private void onButton3Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "3";
        }

        private void onButton4Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "4";
        }

        private void onButton5Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "5";
        }

        private void onButton6Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "6";
        }

        private void onButton7Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "7";
        }

        private void onButton8Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "8";
        }

        private void onButton9Click(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + "9";
        }

        private void onButtonAddClick(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + " + ";
        }

        private void onButtonSubtractClick(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = outputBlock.Text + " - ";
        }

        private void onButtonEqualsClick(object sender, RoutedEventArgs e)
        {
            string[] numbers = outputBlock.Text.Split(' ');
            int result = 0;

            if (numbers[1] == "+")
            {
                result = int.Parse(numbers[0]) + int.Parse(numbers[2]);
            }
            else
            {
                result = int.Parse(numbers[0]) - int.Parse(numbers[2]);
            }
            outputBlock.Text = result.ToString();
        }

        private void onButtonClearClick(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = "";
        }
    }
}
