// <copyright file="Register.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for Register.xaml.
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = this.NameTextBox.Text;
            string surname = this.SurnameTextBox.Text;
            string role = this.PositionTextBox.Text;
            string password = this.SignUpPasswordBox.Password;
            string confirmPassword = this.ConfirmPasswordBox.Password;

            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, $"User with name {name} and surname {surname} trying to register.");

                if (userService.RegisterUser(name, surname, role, password, confirmPassword))
                {
                    userService.LogToFile(path, $"User is registered!");
                    Menu menuwindow = new Menu();
                    menuwindow.Show();
                    this.Close();
                }
                else
                {
                    userService.LogToFile(path, $"User is not registered!");
                    MessageBox.Show("Unsuccessful register!");
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login loginwindow = new Login();
            loginwindow.Show();
            this.Close();
        }
    }
}
