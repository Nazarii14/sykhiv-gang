// <copyright file="Сhoose.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.IO;
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for Сhoose.xaml.
    /// </summary>
    public partial class Сhoose : Window
    {
        public Сhoose()
        {
            this.InitializeComponent();
        }

        private void CommanderButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User pressed Commander button.");
            }

            Login loginwindow = new Login();
            this.Close();
            loginwindow.Show();
        }

        private void SoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User pressed Soldier button.");
            }

            Login loginwindow = new Login();
            this.Close();
            loginwindow.Show();
        }
    }
}
