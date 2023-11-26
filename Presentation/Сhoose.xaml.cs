using BLL;
using DAL.Data;
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
using System.Xml.Linq;
using System.IO;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Сhoose.xaml
    /// </summary>
    public partial class Сhoose : Window
    {
        public Сhoose()
        {
            InitializeComponent();
        }

        private void CommanderButton_Click(object sender, RoutedEventArgs e)
        {
            using (MilitaryProjectContext context = new MilitaryProjectContext())
            {
                Bll userService = new Bll(context);
                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User pressed Commander button.");
            }

            Login loginwindow = new Login();
            loginwindow.Show();
        }
        private void SoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (MilitaryProjectContext context = new MilitaryProjectContext())
            {
                Bll userService = new Bll(context);
                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User pressed Soldier button.");
            }

            Login loginwindow = new Login();
            loginwindow.Show();
        }

    }
}
