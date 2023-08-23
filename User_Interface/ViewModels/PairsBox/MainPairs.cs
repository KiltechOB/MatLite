using MatLite.factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace User_Interface.ViewModels.PairsBox
{
    public class MainPairs:CalculationPairs
    {
        private Pairs pairs { get; set; }
        private ObservableCollection<TextBox> pairsBoxes { get; set; }
        private ObservableCollection<TextBox> TextBoxes { get; set; }
        private string[] Text;
        private PairsDictionary pairsDictionary { get; set; }
        private string ListPairs { get; set; }

        public MainPairs(Pairs pairs, ObservableCollection<TextBox> TextBoxes, ObservableCollection<TextBox> pairsBoxes, PairsDictionary pairsDictionary, string ListPairs)
            :base(pairs, TextBoxes, pairsDictionary, ListPairs)
        {
            this.pairs = pairs;
            this.TextBoxes = TextBoxes;
            this.pairsBoxes = pairsBoxes;
            this.pairsDictionary = pairsDictionary;
            this.ListPairs = ListPairs;
        }
        public void AddMainPairs(string ListPairs, PairsDictionary pairsDictionary, TextBox ActiveTextBox, ObservableCollection<TextBox> TextBoxes)
        {
            if (ActiveTextBox != null)
            {
                ActiveTextBox.Text = ActiveTextBox.Text.Remove(ActiveTextBox.SelectionStart - 1, 1);
                if (ActiveTextBox.Text.Contains(";"))
                {
                    ActiveTextBox.Text = ActiveTextBox.Text.Remove(ActiveTextBox.Text.Length - 1, 1);
                }
                Text = ActiveTextBox.Text.Split("=");
                pairs.Name = Text[0]; pairs.Values = Text[1];

                ActiveTextBox.Text += ';';
                ActiveTextBox.Focus();
                ActiveTextBox.CaretIndex = ActiveTextBox.Text.Length;
                pairsDictionary.AddDictionary(pairs);
                CalculatoiunAll(TextBoxes);
                
            }
        }
        public string WritePairs(PairsDictionary pairsDictionary)
        {           
            return ListPairs= pairsDictionary.WritePairs();
        }
    }
}
