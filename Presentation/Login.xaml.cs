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

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login() => this.InitializeComponent();

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string name = this.UsernameTextBox.Text;
            string password = this.PasswordBox.Password;

            using (MilitaryProjectContext context = new MilitaryProjectContext())
            {
                Bll userService = new Bll(context);

                if (userService.AuthenticateUser(name, password))
                {
                    // Something has to be shown
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unsuccessful login!");
                }
            }
        }
    }
}