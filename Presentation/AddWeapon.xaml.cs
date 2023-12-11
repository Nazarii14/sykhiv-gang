// <copyright file="AddWeapon.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for AddWeapon.xaml.
    /// </summary>
    public partial class AddWeapon : Window
    {
        public AddWeapon()
        {
            this.InitializeComponent();
        }

        private void AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.AddWeapon(this.TypeBox.Text, this.NameBox.Text, decimal.Parse(this.PriceBox.Text), decimal.Parse(this.WeightBox.Text), int.Parse(this.NeededAmountBox.Text), int.Parse(this.AvailableAmountBox.Text), int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void Cancel_AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
