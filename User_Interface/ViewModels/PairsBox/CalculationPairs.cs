using MatLite.factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace User_Interface.ViewModels.PairsBox
{
    public class CalculationPairs
    {
        private Pairs pairs { get; set; }
        private ObservableCollection<TextBox> TextBoxes { get; set; }
        private PairsDictionary pairsDictionary;
        private string[] Text;

        private string ListPairs { get; set; }

        public CalculationPairs(Pairs pairs,ObservableCollection<TextBox> TextBoxes, PairsDictionary pairsDictionary, string ListPairs) 
        {
            this.pairs = pairs;
            this.TextBoxes = TextBoxes;
            this.pairsDictionary = pairsDictionary;
            this.ListPairs = ListPairs;
        }
        public void CalculationFormulaBox(TextBox TB)
        {
            int x = 1;
            if (TB.Text.EndsWith(";") || System.Text.RegularExpressions.Regex.IsMatch(TB.Text, @"[жЖ]$"))
            {
                if (TB.Text.Contains("="))
                {
                    Text = TB.Text.Split("=");
                    pairs.Name = Text[0];
                    x = Text[Text.Count() - 1].Length;
                }
                TB.Text = TB.Text.Remove(TB.Text.Length - x, x);

                ReversePolishNotation reverse = new ReversePolishNotation();
                Queue<string> formula = reverse.GetReversePolishNotations(TB.Text, pairsDictionary);
                Calculation calculation = new Calculation();
                string result = calculation.getResult(formula);
                pairs.Values = result;
                if (TB.Text.Contains("=") && Text.Count() > 2)
                {
                    pairsDictionary.AddDictionary(pairs);
                    pairsDictionary.WritePairs();
                    ListPairs = pairsDictionary.FullName;
                }
                TB.Text += $"{result};";
                TB.CaretIndex = TB.Text.Length;
            }
            else
            {
                if (TB.Text.Contains("="))
                {
                    Text = TB.Text.Split("=");
                    pairs.Name = Text[0];
                }
                ReversePolishNotation reverse = new ReversePolishNotation();
                Queue<string> formula = reverse.GetReversePolishNotations(TB.Text, pairsDictionary);
                Calculation calculation = new Calculation();
                string result = calculation.getResult(formula);
                pairs.Values = result;
                if (TB.Text.Contains("="))
                {
                    pairsDictionary.AddDictionary(pairs);
                    pairsDictionary.WritePairs();
                    ListPairs = pairsDictionary.FullName;
                }
                TB.Text += $"={result};";
                TB.CaretIndex = TB.Text.Length;
            }
        }
        public void CalculatoiunAll(ObservableCollection<TextBox> TextBoxes)
        {
            if (TextBoxes.Count > 0)
            {
                foreach (TextBox TBs in TextBoxes)
                {
                    if( TBs.Text.Length>2)
                    {
                        CalculationFormulaBox(TBs);
                    }                    
                }
            }
        }
    }
}
