﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookRegister.Views
{
    /// <summary>
    /// Interaction logic for RemoveBookConfirmationView.xaml
    /// </summary>
    public partial class RemoveBookConfirmationView : Window
    {
        public RemoveBookConfirmationView()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
