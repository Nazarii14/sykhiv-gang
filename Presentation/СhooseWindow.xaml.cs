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
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for СhooseWindow.xaml
    /// </summary>
    public partial class СhooseWindow : Window
    {
        public СhooseWindow()
        {
            InitializeComponent();
        }

        private void CommanderButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginwindow = new MainWindow();
            loginwindow.Show();
        }
        private void SoldierButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginwindow = new MainWindow();
            loginwindow.Show();
        }

    }
}
