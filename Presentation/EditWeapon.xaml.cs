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
            get { return itemId; }
            set { itemId = value; }
        }

        public EditWeapon(int itemId)
        {
            InitializeComponent();
            EditInfo_Loaded(itemId);
            ItemId = itemId;    
        }

        private void EditWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditWeapon(ItemId, TypeBox.Text, NameBox.Text,
                                       decimal.Parse(PriceBox.Text), 
                                       decimal.Parse(WeightBox.Text), 
                                       int.Parse(NeededAmountBox.Text),
                                       int.Parse(AvailableAmountBox.Text),
                                       int.Parse(UserIdBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                var weapon = userService.GetWeaponById(itemId);

                TypeBox.Text = weapon.Type;
                NameBox.Text = weapon.Name;
                PriceBox.Text = weapon.Price.ToString();
                WeightBox.Text = weapon.Weight.ToString();
                NeededAmountBox.Text = weapon.NeededAmount.ToString();
                AvailableAmountBox.Text = weapon.AvailableAmount.ToString();
                UserIdBox.Text = weapon.UserId.ToString();
            }
        }
    }
}
