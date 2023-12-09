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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for EditSoldier.xaml
    /// </summary>
    public partial class EditSoldier : Window
    {
        private int itemId;
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public EditSoldier(int itemId)
        {
            InitializeComponent();
            EditInfo_Loaded(itemId);
            ItemId = itemId;
        }

        private void EditSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditSoldier(itemId, CallSignBox.Text, int.Parse(UserIdBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                var soldier = userService.GetSoldierById(itemId);

                CallSignBox.Text = soldier.Callsign;
                UserIdBox.Text = soldier.UserId.ToString();
            }
        }
    }
}
