// <copyright file="Login.xaml.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

namespace Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using DAL.Data;
    using DAL.Models;
    using BLL;
    using Microsoft.Extensions.Logging;
    using DAL;
    using System.IO;

    /// <summary>
    /// Interaction logic for Login.xaml
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
            string password = this.PasswordBox.Password;

            using (MilitaryProjectContext context = new MilitaryProjectContext())
            {
                Bll userService = new Bll(context);

                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User with name {name} trying to log in.");

                // Checking if is connected to db
                // Create some user in db
                userService.AddUser("Oleg", "Lozovyi", "123456789", "Commander");

                if (userService.AuthenticateUser(name, password))
                {
                    userService.LogToFile(path, $"User is logged in!");
                    // Showing next window after login (menu)
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
        private void Hyperlink_Click (object sender, RoutedEventArgs e)
        {
            Register registerwindow = new Register();
            this.Close();
            registerwindow.Show();
        }
    }
}