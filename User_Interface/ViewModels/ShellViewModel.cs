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

namespace User_Interface.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string listPairs;
        public string ListPairs
        {
            get { return listPairs; }
            set
            {
                listPairs = value;
                NotifyOfPropertyChange(() => listPairs);
            }
        }

        private Pairs pair;
        public Pairs pairs
        {
            get { return pair; }
            set
            {
                pair = value;
                NotifyOfPropertyChange(() => pair);
            }
        }

        private PairsDictionary pairsdictionary;
        public PairsDictionary pairsDictionary
        {
            get { return pairsdictionary; }
            set
            {
                pairsdictionary = value;
                NotifyOfPropertyChange(() => pairsdictionary);
            }
        }

        private ObservableCollection<TextBox> pairsBoxes;
        public ObservableCollection<TextBox> PairsBoxes
        {
            get { return pairsBoxes; }
            set
            {
                pairsBoxes = value;
                NotifyOfPropertyChange(() => pairsBoxes);
            }
        }

        private ObservableCollection<TextBox> textBoxes;
        public ObservableCollection<TextBox> TextBoxes
        {
            get { return textBoxes; }
            set
            {
                textBoxes = value;
                NotifyOfPropertyChange(() => textBoxes);
            }
        }

        private TextBox box;
        public TextBox Box
        {
            get { return box; }
            set
            {
                box = value;
                NotifyOfPropertyChange(() => box);
            }
        }

        private TextBox activeTextBox;
        public TextBox ActiveTextBox
        {
            get { return box; }
            set
            {
                box = value;
                NotifyOfPropertyChange(() => activeTextBox);
            }
        }

        public ShellViewModel()
        {
            TextBoxes = new ObservableCollection<TextBox>();
            Box = new TextBox();
            PairsBoxes = new ObservableCollection<TextBox>();
            pairs = new Pairs();
            pairsDictionary=new PairsDictionary();
        }

        public void CreateTextBoxPairs()
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
        }


        public void formulaSize(object sender, KeyEventArgs e)
        {
            if (TextBoxes.Count() > 0 && e.Key == Key.OemPlus)
            {
                //ActiveTextBox = sender as TextBox;

                if (ActiveTextBox != null && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
                {
                    ActiveTextBox.Text = ActiveTextBox.Text.Remove(ActiveTextBox.SelectionStart - 1, 1);


                    ReversePolishNotation reverse = new ReversePolishNotation();

                    Queue<string> formula = reverse.GetReversePolishNotations(ActiveTextBox.Text, pairsDictionary);

                    Calculation calculation = new Calculation();
                    double result = calculation.getResult(formula);

                    ActiveTextBox.Text += $"={result};";
                    ActiveTextBox.Focus();
                    ActiveTextBox.CaretIndex = ActiveTextBox.Text.Length;
                }
            }
        }

        public void AddMainPairs(object sender, KeyEventArgs e)
        {
            if (PairsBoxes.Count() > 0 && e.Key == Key.OemSemicolon)
            {
                if (ActiveTextBox != null)
                {
                    ActiveTextBox.Text = ActiveTextBox.Text.Remove(ActiveTextBox.SelectionStart - 1, 1);

                    string [] textPairs = ActiveTextBox.Text.Split("=");
                    pairs.Name = textPairs[0]; pairs.Values = textPairs[1];
                    pairsDictionary.AddDictionary(pairs);
                    
                    ActiveTextBox.Text += ';';
                    ActiveTextBox.Focus();
                    ActiveTextBox.CaretIndex = ActiveTextBox.Text.Length;
                    
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
            x.KeyUp += AddMainPairs;
            x.GotFocus += TextBox_GotFocus;
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
            x.KeyUp += formulaSize;
            x.GotFocus += TextBox_GotFocus;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ActiveTextBox = sender as TextBox;
        }
        public void SymbolInsert(TextBox x, string number)
        {
            int caretIndex = x.CaretIndex;
            x.Text = x.Text.Insert(caretIndex, number);
            x.Focus();
            x.CaretIndex = caretIndex + 1;
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
        public void Equal(object sender)
        {
            if (ActiveTextBox != null)
            {
                SymbolInsert(ActiveTextBox, "=");
            }
        }

    }
}
