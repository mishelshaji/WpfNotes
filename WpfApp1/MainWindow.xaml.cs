﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    
    private void WindowCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        MessageBox.Show("Window Handler Executed");
    }

    private void StackPanelCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        MessageBox.Show("Stack Panel Command Handler Executed");
    }
}
