using System;
using System.IO;
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
using Microsoft.Win32;

namespace ExcelLite
{
	public partial class MainWindow : Window
	{

        IEnumerable<string> csvLines;
        IEnumerable<string> csvHeaders;

		public MainWindow()
		{
			InitializeComponent();
		}

        public void OpenCsvFile()
        {
            StackPanel datagridRoot = new StackPanel()
            {
                Width = RootGrid.Width - 30,
                Height = RootGrid.Height - 60,
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                CanVerticallyScroll = true
            };

            RootGrid.Children.Add(datagridRoot);

            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == true)
            {
                csvLines = File.ReadAllLines(fileDialog.FileName);
                csvHeaders = csvLines.ElementAt(0).Split(',');
            }

            for (int i = 0; i < csvLines.Count(); i++)
            {
                datagridRoot.Children.Add(GenerateRow(csvLines.ElementAt(i).Split(',')));
            }

        }

        public StackPanel GenerateRow(string[] values)
        {
            StackPanel row = new StackPanel() { Orientation = Orientation.Horizontal };

            for (int i = 0; i < values.Count(); i++)
            {
                TextBox textBox = new TextBox()
                {
                    MinWidth = 50,
                    Height = 30,
                    Text = values.ElementAt(i),
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    BorderThickness = new Thickness(0),
                    FontSize = 20
                };

                textBox.GotFocus += TextBoxGotFocus;
                textBox.LostFocus += TextBoxLostFocus;

                Border border = new Border()
                {
                    BorderThickness = new Thickness(2),
                    BorderBrush = Brushes.Gray,
                    Padding = new Thickness(5)
                };

                border.Child = textBox;
                row.Children.Add(border);
            }

            return row;
        }

		public void GenerateHeaders()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == true)
            {
                string[] csvLines = File.ReadAllLines(fileDialog.FileName);
                string[] headers = csvLines[0].Split(',');

                StackPanel stackPanel = new StackPanel()
                {
                    Width = RootGrid.Width - 30,
                    Height = RootGrid.Height - 30,
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    TextBox textBox = new TextBox()
                    {
                        MinWidth = 50,
                        Height = 30,
                        Text = headers[i],
                        TextAlignment = TextAlignment.Center,
                        TextWrapping = TextWrapping.Wrap,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        BorderThickness = new Thickness(0),
                        FontSize = 20
                    };

                    textBox.GotFocus += TextBoxGotFocus;
                    textBox.LostFocus += TextBoxLostFocus;

                    Border border = new Border()
                    {
                        BorderThickness = new Thickness(2),
                        BorderBrush = Brushes.Gray,
                        Padding = new Thickness(5)
                    };

                    border.Child = textBox;
                    stackPanel.Children.Add(border);
                }
            }
        }

        public void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)e.Source;
            Border border = (Border)textBox.Parent;
            border.BorderBrush = Brushes.Green;
        }
        public void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBlock = (TextBox)e.Source;
            Border border = (Border)textBlock.Parent;
            border.BorderBrush = Brushes.Gray;
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenCsvFile();
        }
    }
}
