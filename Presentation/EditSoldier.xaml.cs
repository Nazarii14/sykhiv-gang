// <copyright file="EditSoldier.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for EditSoldier.xaml.
    /// </summary>
    public partial class EditSoldier : Window
    {
        private int itemId;

        public EditSoldier(int itemId)
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

        private void EditSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditSoldier(this.itemId, this.CallSignBox.Text, int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                var soldier = userService.GetSoldierById(itemId);

                this.CallSignBox.Text = soldier.Callsign;
                this.UserIdBox.Text = soldier.UserId.ToString();
            }
        }

        private void Cancel_EditSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
