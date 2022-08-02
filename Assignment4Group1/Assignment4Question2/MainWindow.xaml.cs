﻿using System;
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

namespace Assignment4Question2
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

        private void txtEntry_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtExit_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtEntryNum_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtExitSentence_TextChanged(object sender, TextChangedEventArgs e) { }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder(txtEntry.Text);
            IEnumerable<string> words = sb.ToString().Split(' ');
            txtExit.Text = words.Count().ToString();

            /* counts characters
            int count = 0;
            for(int i = 0; i < sb.Length; i++)
            {                
                count += sb.ToString()[i];
            }
            txtExit.Text = count.ToString();*/
        }

        private void btnStartNum_Click(object sender, RoutedEventArgs e)
        {
            //words generated by https://www.randomlists.com/random-words
            string[] myWords = { "agreement", "field", "ruin", "button", "unruly", "afternoon", "noise", "turn", "second",
                                    "acceptable", "coil", "mist", "pretty" };

            Sentence mySentence = new Sentence(myWords);
            int entryNum = Convert.ToInt32(txtEntryNum.Text);
            mySentence.GenerateSentence(entryNum);
            txtExitSentence.Text = mySentence.SentenceContent;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtEntry.Text = null;
            txtExit.Text = null;
            txtEntryNum.Text = null;
            txtExitSentence.Text = null;
        }              
    }
}
