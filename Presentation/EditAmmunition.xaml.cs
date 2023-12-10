using BLL;
using DAL;
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
    /// Interaction logic for EditAmmunition.xaml
    /// </summary>
    public partial class EditAmmunition : Window
    {
        private int itemId;
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public EditAmmunition(int itemId)
        {
            InitializeComponent();
            EditInfo_Loaded(itemId);
            ItemId = itemId;
        }

        private void EditAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditAmmunition(itemId, TypeBox.Text, NameBox.Text, 
                    decimal.Parse(PriceBox.Text), SizeBox.Text,
                    UsersGenderBox.Text, int.Parse(UserIdBox.Text), 
                    int.Parse(NeededAmountBox.Text), int.Parse(AvailableAmountBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);

                var ammunition = userService.GetAmmunitionById(itemId);

                TypeBox.Text = ammunition.Type;
                NameBox.Text = ammunition.Name;
                PriceBox.Text = ammunition.Price.ToString();
                SizeBox.Text = ammunition.Size;
                NeededAmountBox.Text = ammunition.NeededAmount.ToString();
                AvailableAmountBox.Text = ammunition.AvailableAmount.ToString();
                UsersGenderBox.Text = ammunition.UsersGender;
                UserIdBox.Text = ammunition.UserId.ToString();
            }
        }
    }
}
