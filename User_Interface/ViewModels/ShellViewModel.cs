﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Reflection;
using MatLite;
using MatLite.factory;
using MatLite.constants;
using System.Diagnostics.CodeAnalysis;
using MathNet.Symbolics;
using User_Interface.ViewModels.PairsBox;

namespace User_Interface.ViewModels
{
    public class ShellViewModel : Screen
    {
        private Constants constants;

        private string forbiddenChars = "`~!@#$&_|{}><?₴\'!№?_\"";
        public string [] Text { get; set; }
        private string listPairs;
        public string ListPairs
        {
            get { return listPairs; }
            set
            {
                listPairs = value;
                NotifyOfPropertyChange(() => ListPairs);
            }
        }

        private Pairs pair;
        public Pairs pairs
        {
            get { return pair; }
            set
            {
                pair = value;
                NotifyOfPropertyChange(() => pairs);
            }
        }

        private PairsDictionary pairsdictionary;
        public PairsDictionary pairsDictionary
        {
            get { return pairsdictionary; }
            set
            {
                pairsdictionary = value;
                NotifyOfPropertyChange(() => pairsDictionary);
            }
        }
        private ObservableCollection<TextBox> pairsBoxes;
        public ObservableCollection<TextBox> PairsBoxes
        {
            get { return pairsBoxes; }
            set
            {
                pairsBoxes = value;
                NotifyOfPropertyChange(() => PairsBoxes);
            }
        }
        private ObservableCollection<TextBox> textBoxes;
        public ObservableCollection<TextBox> TextBoxes
        {
            get { return textBoxes; }
            set
            {
                textBoxes = value;
                NotifyOfPropertyChange(() => TextBoxes);
            }
        }

        private TextBox box;
        public TextBox Box
        {
            get { return box; }
            set
            {
                box = value;
                NotifyOfPropertyChange(() => Box);
            }
        }

        private TextBox activeTextBox;
        public TextBox ActiveTextBox
        {
            get { return activeTextBox; }
            set
            {
                activeTextBox = value;
                NotifyOfPropertyChange(() => ActiveTextBox);
            }
        }
        public MainPairs mainPairs;
        public CalculationPairs calculationPairs;
        public ShellViewModel()
        {
            TextBoxes = new ObservableCollection<TextBox>();
            Box = new TextBox();
            PairsBoxes = new ObservableCollection<TextBox>();
            pairs = new Pairs();
            pairsDictionary = new PairsDictionary();            
            constants = new Constants();
            constants.AddConstants(pairsDictionary);
            mainPairs = new MainPairs(pairs, TextBoxes, PairsBoxes, pairsDictionary, ListPairs);
            calculationPairs = new CalculationPairs(pairs, TextBoxes, pairsDictionary, ListPairs);
        }     
        public void CreateMainPairs()
        {
            Box = new TextBox();
            StylesPairsBox(Box);
            PairsBoxes.Add(Box);
            Box.Focus();
        }
        public void CreateTextBox()
        {
            Box = new TextBox();
            StylesFornulaBox(Box);
            TextBoxes.Add(Box);
            Box.Focus();
        }

        public void Clear_All()
        {
            ListPairs = "";
            TextBoxes.Clear();
            PairsBoxes.Clear();
            forbiddenChars = forbiddenChars.Replace("=","");
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (ActiveTextBox.Text.Contains("="))
            {
                forbiddenChars += "=";
            }
            else
            {
                forbiddenChars = forbiddenChars.Replace("=", "");
            }

            if (forbiddenChars.Contains(e.Text))
            {
                e.Handled = true;
            }           
        }
        public void AddingMainPairs(object sender, KeyEventArgs e)
        {
            if (PairsBoxes.Count() > 0 && e.Key == Key.OemSemicolon)
            {
                mainPairs.AddMainPairs(ListPairs,pairsDictionary,ActiveTextBox,TextBoxes);
                ListPairs=mainPairs.WritePairs(pairsDictionary);
            }
        }
        public void AddingFormula(object sender, KeyEventArgs e)
        {
            if ((TextBoxes.Count() > 0 && e.Key == Key.OemSemicolon))
            {
                if (ActiveTextBox != null)
                {
                    ActiveTextBox.Text = ActiveTextBox.Text.Remove(ActiveTextBox.SelectionStart - 1, 1);
                    calculationPairs.CalculatoiunAll(TextBoxes);
                    ListPairs = mainPairs.WritePairs(pairsDictionary);
                }
            }
        }
        private void StylesPairsBox(TextBox x)
        {
            x.Background = Brushes.White;
            x.BorderBrush = new SolidColorBrush(Color.FromRgb(0xcc, 0xcc, 0xcc));
            x.Padding = new Thickness(2);
            x.FontFamily = new FontFamily("Times New Roman");
            x.FontSize = 18;
            x.MinWidth = 80;
            x.Height = 60;
            x.VerticalContentAlignment = VerticalAlignment.Center;
            x.HorizontalContentAlignment = HorizontalAlignment.Center;
            x.KeyUp += AddingMainPairs;
            x.GotFocus += TextBox_GotFocus;
            x.PreviewTextInput += TextBox_PreviewTextInput;
        }

        private void StylesFornulaBox(TextBox x)
        {
            x.Background = Brushes.White;
            x.BorderBrush = new SolidColorBrush(Color.FromRgb(0xcc, 0xcc, 0xcc));
            x.Padding = new Thickness(2);
            x.FontFamily = new FontFamily("Times New Roman");
            x.FontSize = 18;
            x.MinWidth = 40;
            x.MinHeight = 40;
            x.MaxHeight = 110;
            x.AcceptsReturn = true;
            x.AcceptsTab = true;
            x.VerticalContentAlignment = VerticalAlignment.Center;
            x.HorizontalContentAlignment = HorizontalAlignment.Center;
            x.KeyUp += AddingFormula;
            x.GotFocus += TextBox_GotFocus;
            x.PreviewTextInput += TextBox_PreviewTextInput;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ActiveTextBox = sender as TextBox;
        }
        public void SymbolInsert(TextBox x, string values)
        {
            int caretIndex = x.CaretIndex;
            x.Text = x.Text.Insert(caretIndex, values);
            x.Focus();
            x.CaretIndex = caretIndex + 1;
        }
        public void Pi(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "π");
            }
        }
        public void e(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "e");
            }
        }
        public void Root(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "√");
            }
        }
        public void Square(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "^");
            }
        }
        public void One(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "1");
            }
        }
        public void Two(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "2");
            }
        }
        public void Three(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "3");
            }
        }
        public void Four(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "4");
            }
        }
        public void Five(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "5");
            }
        }
        public void Six(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "6");
            }
        }
        public void Seven(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "7");
            }
        }
        public void Eight(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "8");
            }
        }
        public void Nine(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "9");
            }
        }
        public void Zero(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "0");
            }
        }
        public void Plus(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "+");
            }
        }
        public void Minus(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "-");
            }
        }
        public void Multiplication(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "*");
            }
        }
        public void Division(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "/");
            }
        }
        public void OpenBrackets(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "(");
            }
        }
        public void CloseBrackets(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, ")");
            }
        }
        public void Сalculation(object sender, KeyEventArgs e)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "=");
                calculationPairs.CalculatoiunAll(TextBoxes);
            }
        }
        public void Equalse()
        {
            if(ActiveTextBox!= null)
            {
                SymbolInsert(ActiveTextBox, "=");
            }
        }
    }
}
