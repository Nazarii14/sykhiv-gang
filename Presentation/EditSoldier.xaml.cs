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
            get { return this.itemId; }
            set { this.itemId = value; }
        }
        public EditSoldier(int itemId)
        {
            this.InitializeComponent();
            this.EditInfo_Loaded(itemId);
            this.ItemId = itemId;
        }

        private void EditSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);
                userService.EditSoldier(this.itemId, this.CallSignBox.Text, int.Parse(this.UserIdBox.Text));
            }

            this.Close();
        }

        private void EditInfo_Loaded(int itemId)
        {
            using (sykhivgangContext context = new sykhivgangContext())
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
