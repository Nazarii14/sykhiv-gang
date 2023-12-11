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
    /// Interaction logic for AddWeapon.xaml
    /// </summary>
    public partial class AddWeapon : Window
    {
        public AddWeapon()
        {
            this.InitializeComponent();
        }
        private void AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.AddWeapon(this.TypeBox.Text, this.NameBox.Text, 
                                       decimal.Parse(this.PriceBox.Text), decimal.Parse(this.WeightBox.Text), 
                                       int.Parse(this.NeededAmountBox.Text), int.Parse(this.AvailableAmountBox.Text),
                                       int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }
        private void Cancel_AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
