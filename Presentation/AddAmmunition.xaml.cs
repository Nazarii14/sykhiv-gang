using BLL;
using DAL.Data;
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
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.AddAmmunition(TypeBox.Text, NameBox.Text, 
                    decimal.Parse(PriceBox.Text), SizeBox.Text, 
                    UserGenderBox.Text, int.Parse(UserIdBox.Text));
            }

            this.Close();
        }
    }
}
