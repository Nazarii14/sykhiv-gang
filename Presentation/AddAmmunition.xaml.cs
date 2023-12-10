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
    /// Interaction logic for AddAmmunition.xaml
    /// </summary>
    public partial class AddAmmunition : Window
    {
        public AddAmmunition()
        {
            InitializeComponent();
        }

        private void AddAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (SykhivgangContext context = new SykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.AddAmmunition(TypeBox.Text, NameBox.Text, 
                    decimal.Parse(PriceBox.Text), SizeBox.Text,
                    int.Parse(NeededAmountBox.Text), int.Parse(AvailableAmountBox.Text),
                    UserGenderBox.Text, int.Parse(UserIdBox.Text));
            }

            this.Close();
        }
    }
}
