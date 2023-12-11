using BLL;
using DAL;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for EditWeapon.xaml
    /// </summary>
    public partial class EditWeapon : Window
    {
        private int itemId;
        
        public int ItemId
        {
            get { return this.itemId; }
            set { this.itemId = value; }
        }

        public EditWeapon(int itemId)
        {
            this.InitializeComponent();
            this.EditInfo_Loaded(itemId);
            this.ItemId = itemId;    
        }

        private void EditWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditWeapon(this.ItemId, this.TypeBox.Text, this.NameBox.Text,
                                       decimal.Parse(this.PriceBox.Text), 
                                       decimal.Parse(this.WeightBox.Text), 
                                       int.Parse(this.NeededAmountBox.Text),
                                       int.Parse(this.AvailableAmountBox.Text),
                                       int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (sykhivgangContext context = new sykhivgangContext())
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
