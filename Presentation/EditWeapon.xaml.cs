// <copyright file="EditWeapon.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for EditWeapon.xaml.
    /// </summary>
    public partial class EditWeapon : Window
    {
        private int itemId;

        public EditWeapon(int itemId)
        {
            this.InitializeComponent();
            this.EditInfo_Loaded(itemId);
            this.ItemId = itemId;
        }

        public int ItemId
        {
            get { return this.itemId; }
            set { this.itemId = value; }
        }

        private void EditWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditWeapon(this.ItemId, this.TypeBox.Text, this.NameBox.Text, decimal.Parse(this.PriceBox.Text), decimal.Parse(this.WeightBox.Text), int.Parse(this.NeededAmountBox.Text), int.Parse(this.AvailableAmountBox.Text), int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                var weapon = userService.GetWeaponById(itemId);

                this.TypeBox.Text = weapon.Type;
                this.NameBox.Text = weapon.Name;
                this.PriceBox.Text = weapon.Price.ToString();
                this.WeightBox.Text = weapon.Weight.ToString();
                this.NeededAmountBox.Text = weapon.NeededAmount.ToString();
                this.AvailableAmountBox.Text = weapon.AvailableAmount.ToString();
                this.UserIdBox.Text = weapon.UserId.ToString();
            }
        }

        private void Cancel_EditWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
