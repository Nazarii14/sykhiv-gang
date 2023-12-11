// <copyright file="EditAmmunition.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for EditAmmunition.xaml.
    /// </summary>
    public partial class EditAmmunition : Window
    {
        private int itemId;

        public EditAmmunition(int itemId)
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

        private void EditAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditAmmunition(this.itemId, this.TypeBox.Text, this.NameBox.Text, decimal.Parse(this.PriceBox.Text), this.SizeBox.Text, this.UsersGenderBox.Text, int.Parse(this.UserIdBox.Text), int.Parse(this.NeededAmountBox.Text), int.Parse(this.AvailableAmountBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                var ammunition = userService.GetAmmunitionById(itemId);

                this.TypeBox.Text = ammunition.Type;
                this.NameBox.Text = ammunition.Name;
                this.PriceBox.Text = ammunition.Price.ToString();
                this.SizeBox.Text = ammunition.Size;
                this.NeededAmountBox.Text = ammunition.NeededAmount.ToString();
                this.AvailableAmountBox.Text = ammunition.AvailableAmount.ToString();
                this.UsersGenderBox.Text = ammunition.UsersGender;
                this.UserIdBox.Text = ammunition.UserId.ToString();
            }
        }

        private void Cancel_EditAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
