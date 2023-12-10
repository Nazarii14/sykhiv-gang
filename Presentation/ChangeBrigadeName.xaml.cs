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
    /// Interaction logic for ChangeBrigadeName.xaml
    /// </summary>
    public partial class ChangeBrigadeName : Window
    {
        public ChangeBrigadeName()
        {
            InitializeComponent();
            var ExistingBrigadeAttributes = BrigadeAttributesLoaded();
            var BrName = ExistingBrigadeAttributes[0];
            var ComName = ExistingBrigadeAttributes[1];
            var EstDate = ExistingBrigadeAttributes[2];
            var Location = ExistingBrigadeAttributes[3];

            BrigadeNameBox.Text = BrName;
            CommanderNameBox.Text = ComName;
            EstablishedDateBox.Text = EstDate;
            LocationBox.Text = Location;
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
                userService.ChangeBrigadeInfo(BrigadeNameBox.Text, CommanderNameBox.Text, EstablishedDateBox.Text, LocationBox.Text);
            }

            Menu menu = new Menu();
            menu.Show();
            
            Close();
        }
    }
}
