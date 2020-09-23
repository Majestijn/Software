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

		string csvFilePath;

		public MainWindow()
		{
			InitializeComponent();
			GenerateHeaders();
		}

		public void GenerateHeaders()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			if (fileDialog.ShowDialog() == true)
			{
				dataGrid.
				testBox.Text = File.ReadAllText(fileDialog.FileName);
			}
		}
	}
}
