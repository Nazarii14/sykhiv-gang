// <copyright file="AddSoldier.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for AddSoldier.xaml.
    /// </summary>
    public partial class AddSoldier : Window
    {
        public AddSoldier()
        {
            this.InitializeComponent();
        }

        private void AddSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new(context);
                userService.AddSoldier(this.CallsignBox.Text, int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void Cancel_AddSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
