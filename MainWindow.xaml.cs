using Office365EasyImporter.Models;
using Office365EasyImporter.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;

namespace Office365EasyImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CopyOptionViewModel copyOption;
        public MainWindow()
        {
            InitializeComponent();
            copyOption = new CopyOptionViewModel();
            DataContext = copyOption;
            
        }
    }
}
