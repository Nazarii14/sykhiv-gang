// <copyright file="ChangeBrigadeName.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation
{
    using System.Windows;
    using BLL;
    using DAL;

    /// <summary>
    /// Interaction logic for ChangeBrigadeName.xaml.
    /// </summary>
    public partial class ChangeBrigadeName : Window
    {
        public ChangeBrigadeName()
        {
            this.InitializeComponent();
            var existingBrigadeAttributes = this.BrigadeAttributesLoaded();
            var brName = existingBrigadeAttributes[0];
            var comName = existingBrigadeAttributes[1];
            var estDate = existingBrigadeAttributes[2];
            var location = existingBrigadeAttributes[3];

            this.BrigadeNameBox.Text = brName;
            this.CommanderNameBox.Text = comName;
            this.EstablishedDateBox.Text = estDate;
            this.LocationBox.Text = location;
        }

        private string[] BrigadeAttributesLoaded()
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                return userService.GetBrigadeInfo();
            }
        }

        private void ChangeBrigadeInfoButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.ChangeBrigadeInfo(this.BrigadeNameBox.Text, this.CommanderNameBox.Text, this.EstablishedDateBox.Text, this.LocationBox.Text);
            }

            Menu menu = new Menu();
            menu.Show();

            this.Close();
        }

        private void Cancel_ChangeBrigadeInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();

            this.Close();
        }
    }
}
