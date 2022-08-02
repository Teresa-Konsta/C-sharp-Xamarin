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

namespace Assignment4Group1
{
    //Assignment 4 done by Group 1:

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

        private double[] dblNumbers  = new double[10];
        private int[] intNumbers = new int[10];

        public static int Search<T>(T[]array, T valueToSearch) where T : IComparable<T>
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index].CompareTo(valueToSearch) == 0)
                    return index;
            }
            return -1;
        }        

        private int countInt = 0;
        private int countDbl = 0;
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            bool isInt = true;
           
            txtUserEntry.Text = "";
            try
            {
                if (isInt)
                {
                    int intEntry = int.Parse(txtEntry.Text);
                   
                        intNumbers[countInt] = intEntry;

                    for (int i = 0; i < intNumbers.Length; i++)
                    {
                        txtUserEntry.Text += intNumbers[i] + " ";
                    }
                    countInt++;
                    if (countInt == 10)
                    {
                        countInt = 0;
                    }
                }                
            }
            catch
            {
                isInt = false;
            }
            if (!isInt)
            {
                for (int i = 0; i < 10; i++)
                {
                    double doubleEntry = Convert.ToDouble(txtEntry.Text);                    
                    dblNumbers[countDbl] += doubleEntry;
                    txtEntry.Text = null;
                }               

                countDbl++;
                for (int i = 0; i < dblNumbers.Length; i++)
                {
                    txtUserEntry.Text += dblNumbers[i] + " ";
                }
            }
        }

        //should be modified and accepts int values -> Convert.ToInt32(value);
        //not sure we need it
        //public static double SearchNum<T>(T x, T y) where T : IComparable<T>
        //{
        //    return x.CompareTo(y);
        //}

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {   
            if (txtEntrySearch.Text.Equals(String.Empty))
            {
                MessageBox.Show("Enter a value in" + "the seach box");
                return;
            }
            try
            {
                if(intNumbers == null)
                {
                    double searchValue = Convert.ToDouble(txtEntrySearch.Text);
                    int resultIndex = Search(dblNumbers, searchValue);
                    if(resultIndex == -1)
                    {
                        MessageBox.Show("The searched" + "value is not found in" + "the array");
                    }
                    else
                    {
                        MessageBox.Show("The value is" + "found at index" + resultIndex);
                    }
                }
                else
                {
                    int searchValue = Convert.ToInt32(txtEntrySearch.Text);
                    int resultIndex = Search(intNumbers,searchValue);
                    if (resultIndex == -1)
                    {
                        MessageBox.Show("The searched" + "value is not found" + "in array!");
                    }
                    else
                    {
                        MessageBox.Show("The value" + "is found at index" + resultIndex);
                    }
                }
            }catch
            {
                MessageBox.Show("Enter valid values only" );
            }
        }        

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtEntry.Text = null;
            txtUserEntry.Text = null;
            txtEntrySearch.Text = null;
        }

        private void txtExit_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtUserEntry_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtEntrySearch_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtEntry_TextChanged(object sender, TextChangedEventArgs e) { }

        private void btnRandomIntArray_Click(object sender, RoutedEventArgs e)
        {            
            intNumbers = new int[10];
            txtUserEntry.Text = null;
            Random random = new Random();

            for (int v = 0; v < 10; v++)
            {
                intNumbers[v] = random.Next() % 100;
            }
           
            foreach (int item in intNumbers)
            {
                txtUserEntry.Text += item + " ";
            }
        }

        private void btnRandomDoubleArray_Click(object sender, RoutedEventArgs e)
        {
            dblNumbers = new double[10];
            intNumbers = null;
            Random random = new Random();
            for(int v = 0; v < 10; v++)
            {
                dblNumbers[v] = Math.Round(random.NextDouble(), 2);
            }

            txtUserEntry.Text = null;
            foreach(double item in dblNumbers)
            {
                txtUserEntry.Text += item + " ";
            }
        }       
    }
}
