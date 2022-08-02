using System;
using System.Collections.Generic;
using System.IO;
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

namespace Assignment5Group1
{
    //Assignment 5 done by Group 1:

    //Andrii Kosenko
    //301097272

    //Mucahit Aric 
    //301090476

    //Tereza Konstari 
    //301065539

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static List<StockData> stockDataList  = new List<StockData>();

        public void ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(',');

                    stockDataList.Add(new StockData(values[0], values[1], values[2], values[3], values[4], values[5]));
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //file path goes here
            //ReadFile(@"C:\Users\Mucahit\Desktop\Assignment5Group1\Assignment5Group1\StockData\stockData.csv");
            ReadFile(@"D:\Centennial\semester 4\Programming 3 - COMP 212 - 002\assignments\ass5\Assignment5Group1\Assignment5Group1\StockData\stockData.csv");

            var result = from st in stockDataList
                         where st.Symbol == txtUserEntry.Text ||
                               st.Date == txtUserEntry.Text ||
                               st.Low == txtUserEntry.Text ||
                               st.High == txtUserEntry.Text ||
                               st.Open == txtUserEntry.Text ||
                               st.Close == txtUserEntry.Text
                         orderby st.Date descending
                         select st;

            if (result == null)
            {
                dataGrid.ItemsSource = "No match";
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    pbSearchStatus.Value++;
                }
                dataGrid.ItemsSource = result.ToList();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserEntry.Text = null;
            dataGrid.ItemsSource = null;
            pbSearchStatus.Value = 0;
        }

        private void txtUserEntry_TextChanged(object sender, TextChangedEventArgs e) { }
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { }
    }
}