// <copyright file="Login.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for Login.xaml.
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string name = this.UsernameTextBox.Text;
            string surname = this.SurnameTextBox.Text;
            string password = this.PasswordBox.Password;

            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User with name {name} and surname {surname} trying to log in.");

                if (userService.AuthenticateUser(name, surname, password))
                {
                    userService.LogToFile(path, $"User is logged in!");
                    Menu menuwindow = new Menu();
                    menuwindow.Show();
                    this.Close();
                }
                else
                {
                    userService.LogToFile(path, $"User is not logged in!");
                    MessageBox.Show("Unsuccessful login!");
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Register registerwindow = new Register();
            registerwindow.Show();
            this.Close();
        }
    }
}