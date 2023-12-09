using BLL;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            Weapon_Loaded();
            BrigadeName.Text = BrigadeName_Loaded();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string presentationFolderPath = System.IO.Path.Combine(baseDirectory, "Presentation");

            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, presentationFolderPath);

            }

            //logoutImage.Source = new BitmapImage(new Uri(presentationFolderPath + "\\Icons\\logOut.png", 
            //    UriKind.RelativeOrAbsolute));
        }

        private void DeleteWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DeleteWeapon(itemId);

                WeaponListView.ItemsSource = null;
                WeaponListView.ItemsSource = userService.GetWeapons();
            }
        }

        private void EditWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                EditWeapon editWeapon = new EditWeapon(itemId);

                editWeapon.Closed += (s, args) =>
                {
                    WeaponListView.ItemsSource = null;
                    WeaponListView.ItemsSource = userService.GetWeapons();
                };

                editWeapon.Show();
            }
        }

        private void DeleteAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DeleteAmmunition(itemId);

                WeaponListView.ItemsSource = null;
                WeaponListView.ItemsSource = userService.GetAmmunitions();
            }
        }

        private string BrigadeName_Loaded()
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);
                return userService.GetBrigadeName();
            }
        }

        private void BrigadeName_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeBrigadeName changeBrigadeName = new ChangeBrigadeName();
            changeBrigadeName.Show();
            Close();
        }


        private void WeaponButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Weapon_Loaded()
        {
            using sykhivgangContext context = new();
            Bll bll = new(context);
            List<Weapon> weapons = bll.GetWeapons();

            this.WeaponListView.ItemsSource = weapons;
        }

        private void AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            AddWeapon addWeaponWindow = new AddWeapon();
            addWeaponWindow.Show();
        }

        private void AmmunitionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ammunition_Loaded()
        {
            using sykhivgangContext context = new();
            Bll bll = new(context);
            List<Ammunition> ammunitions = bll.GetAmmunitions();

            //this.AmmunitionListView.ItemsSource = ammunitions;
        }

        private void AddAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            AddAmmunition addAmmunitionWindow = new AddAmmunition();
            addAmmunitionWindow.Show();
        }

        private void SoldierButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void AddSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            AddSoldier addSoldierWindow = new AddSoldier();
            addSoldierWindow.Show();
        }

        private void RoutesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Routes are currently in development!");
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginwindow = new Login();
            loginwindow.Show();
            this.Close();
        }
    }
}
