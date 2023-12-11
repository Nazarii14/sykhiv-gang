using BLL;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            this.InitializeComponent();
            this.Weapon_Loaded();
            this.WeaponButton.Background = Brushes.LightGray;

            this.BrigadeName.Text = this.BrigadeName_Loaded();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string presentationFolderPath = System.IO.Path.Combine(baseDirectory, "Presentation");

            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                string path = Directory.GetCurrentDirectory() + "\\logs.txt";
                userService.LogToFile(path, presentationFolderPath);

            }
        }

        private void WeaponButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeaponBorder.Visibility = Visibility.Visible;
            this.AmmunitionBorder.Visibility = Visibility.Collapsed; 
            this.SoldierBorder.Visibility = Visibility.Collapsed;
            this.WeaponListView.ItemsSource = null;
            this.Weapon_Loaded();
        }

        private void AmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeaponBorder.Visibility = Visibility.Collapsed;
            this.AmmunitionBorder.Visibility = Visibility.Visible;
            this.SoldierBorder.Visibility = Visibility.Collapsed;
            this.AmmunitionListView.ItemsSource = null;
            this.Ammunition_Loaded();
        }

        private void SoldierButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeaponBorder.Visibility = Visibility.Collapsed;
            this.AmmunitionBorder.Visibility = Visibility.Collapsed;
            this.SoldierBorder.Visibility = Visibility.Visible;
            this.SoldierListView.ItemsSource = null;
            this.Soldiers_Loaded();
        }

        private void DeleteWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DeleteWeapon(itemId);

                this.WeaponListView.ItemsSource = null;
                this.WeaponListView.ItemsSource = userService.GetWeapons();
            }
        }

        private void DeleteSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DeleteSoldier(itemId);

                this.SoldierListView.ItemsSource = null;
                this.SoldierListView.ItemsSource = userService.GetSoldiers();
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
                    this.WeaponListView.ItemsSource = null;
                    this.WeaponListView.ItemsSource = userService.GetWeapons();
                };

                editWeapon.Show();
            }
        }

        private void EditAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                EditAmmunition editAmmunition = new EditAmmunition(itemId);
                
                editAmmunition.Show();

                editAmmunition.Closed += (s, args) =>
                {
                    this.AmmunitionListView.ItemsSource = null;
                    this.AmmunitionListView.ItemsSource = userService.GetAmmunitions();
                };
            }
        }

        private void EditSoldierButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                EditSoldier editSoldier = new EditSoldier(itemId);

                editSoldier.Closed += (s, args) =>
                {
                    this.SoldierListView.ItemsSource = null;
                    this.SoldierListView.ItemsSource = userService.GetSoldiers();
                };

                editSoldier.Show();
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

                this.AmmunitionListView.ItemsSource = null;
                this.AmmunitionListView.ItemsSource = userService.GetAmmunitions();
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
            this.Close();
        }



        private void DecrementNeededAmountOfWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DecrementNeededAmountOfWeaponById(itemId);

                this.WeaponListView.ItemsSource = null;
                this.WeaponListView.ItemsSource = userService.GetWeapons();
            }
        }

        private void IncrementNeededAmountOfWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.IncrementNeededAmountOfWeaponById(itemId);

                this.WeaponListView.ItemsSource = null;
                this.WeaponListView.ItemsSource = userService.GetWeapons();
            }
        }

        private void DecrementAvailableAmountOfWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DecrementAvailableAmountOfWeaponById(itemId);

                this.WeaponListView.ItemsSource = null;
                this.WeaponListView.ItemsSource = userService.GetWeapons();
            }
        }

        private void IncrementAvailableAmountOfWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.IncrementAvailableAmountOfWeaponById(itemId);

                this.WeaponListView.ItemsSource = null;
                this.WeaponListView.ItemsSource = userService.GetWeapons();
            }
        }



        private void DecrementNeededAmountOfAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DecrementNeededAmountOfAmmunitionById(itemId);

                this.AmmunitionListView.ItemsSource = null;
                this.AmmunitionListView.ItemsSource = userService.GetAmmunitions();
            }
        }

        private void IncrementNeededAmountOfAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.IncrementNeededAmountOfAmmunitionById(itemId);

                this.AmmunitionListView.ItemsSource = null;
                this.AmmunitionListView.ItemsSource = userService.GetAmmunitions();
            }
        }

        private void DecrementAvailableAmountOfAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.DecrementAvailableAmountOfAmmunitionById(itemId);

                this.AmmunitionListView.ItemsSource = null;
                this.AmmunitionListView.ItemsSource = userService.GetAmmunitions();
            }
        }

        private void IncrementAvailableAmountOfAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            using (sykhivgangContext context = new sykhivgangContext())
            {
                Bll userService = new Bll(context);

                Button button = (Button)sender;
                var itemId = (int)button.CommandParameter;

                userService.IncrementAvailableAmountOfAmmunitionById(itemId);

                this.AmmunitionListView.ItemsSource = null;
                this.AmmunitionListView.ItemsSource = userService.GetAmmunitions();
            }
        }


        private void Weapon_Loaded()
        {
            using sykhivgangContext context = new();
            Bll bll = new(context);
            List<Weapon> weapons = bll.GetWeapons();

            this.WeaponListView.ItemsSource = weapons;
        }

        private void Ammunition_Loaded()
        {
            using sykhivgangContext context = new();
            Bll bll = new(context);
            List<Ammunition> ammunitions = bll.GetAmmunitions();

            this.AmmunitionListView.ItemsSource = ammunitions;
        }

        private void Soldiers_Loaded()
        {
            using sykhivgangContext context = new();
            Bll bll = new(context);
            List<SoldierAttrb> soldiers = bll.GetSoldiers();

            this.SoldierListView.ItemsSource = soldiers;
        }

        private void AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            AddWeapon addWeaponWindow = new AddWeapon();
            addWeaponWindow.Show();
        }

        private void AddAmmunitionButton_Click(object sender, RoutedEventArgs e)
        {
            AddAmmunition addAmmunitionWindow = new AddAmmunition();
            addAmmunitionWindow.Show();
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
