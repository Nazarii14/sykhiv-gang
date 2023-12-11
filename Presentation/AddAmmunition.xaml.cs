// <copyright file="AddAmmunition.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for AddAmmunition.xaml.
    /// </summary>
    public partial class AddAmmunition : Window
    {
        public AddAmmunition()
        {
            this.InitializeComponent();
        }

        private void AddAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.AddAmmunition(this.TypeBox.Text, this.NameBox.Text, decimal.Parse(this.PriceBox.Text), this.SizeBox.Text, int.Parse(this.NeededAmountBox.Text), int.Parse(this.AvailableAmountBox.Text), this.UserGenderBox.Text, int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
