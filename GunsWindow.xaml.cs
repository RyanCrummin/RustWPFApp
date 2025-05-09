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

namespace RustWPFApp
{
    public partial class GunsWindow : Window
    {
        private readonly RustData _context; // This links to my RustData that is in the DataManageMentRust Program.cs
        public GunsWindow()
        {
            InitializeComponent();
            _context = new RustData(); // Setting the _context to a new instance of RustData
            LoadGunsData();
        }

        private void LoadGunsData()
        {
            var gunsData = _context.Guns.ToList();// This links to my RustData that is in the DataManageMentRust Program.cs

            gunNameStckPanel.Children.Clear(); // clears the data.
            gunDescStackPanel.Children.Clear();

            foreach (var gun in gunsData)
            {
                TextBlock nameTextBlock = new TextBlock
                {
                    Text = gun.GunName,
                    FontSize = 16,
                    Margin = new Thickness(5),
                    Foreground = System.Windows.Media.Brushes.White // name text block
                };

                TextBlock descTextBlock = new TextBlock
                {
                    Text = gun.GunDescription,
                    FontSize = 14,
                    Margin = new Thickness(5),
                    Foreground = System.Windows.Media.Brushes.LightGray, // description text block
                    TextWrapping = TextWrapping.Wrap
                };

                gunNameStckPanel.Children.Add(nameTextBlock); // adds text blocks to stack panels
                gunDescStackPanel.Children.Add(descTextBlock);
            }
        }

        private void itemsBTN_Click(object sender, RoutedEventArgs e)
        {
            ItemsWindow itemsWindow = new ItemsWindow();
            itemsWindow.Show();
            this.Close();
            MessageBox.Show("This is the items window (search is case sensitive)"); // hops to the item window
        }

        private void animalsBTN2_Click(object sender, RoutedEventArgs e)
        {
            AnimalsWindow animalsWindow = new AnimalsWindow();
            animalsWindow.Show();
            this.Close();
            MessageBox.Show("This is the animals window (search is case sensitive)"); // hops ot the animals window
        }

        private void mainMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            MessageBox.Show("Welcome back to the Main Menu"); // hops to the main menu
        }

        private void searchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchTxtBox.Text; // search term
            searchTerm.ToUpper();
            MessageBox.Show($"Searching for: {searchTerm}");
            gunNameStckPanel.Children.Clear(); // clears the stack panels
            gunDescStackPanel.Children.Clear();

            // SEARCHES THE DATABASE
            var gunsData = _context.Guns.ToList();
            foreach (var gun in gunsData)
            {
                if (searchTerm == gun.GunName) // if serarch term is equal to the gun in the database it only displays that gun
                {
                    TextBlock nameTextBlock = new TextBlock
                    {
                        Text = gun.GunName,
                        FontSize = 16,
                        Margin = new Thickness(5),
                        Foreground = System.Windows.Media.Brushes.White // creates name text block
                    };

                    TextBlock descTextBlock = new TextBlock
                    {
                        Text = gun.GunDescription,
                        FontSize = 14,
                        Margin = new Thickness(5),
                        Foreground = System.Windows.Media.Brushes.LightGray, //creates desc text block
                        TextWrapping = TextWrapping.Wrap
                    };

                    gunNameStckPanel.Children.Add(nameTextBlock); // adds txtblocks to stack panels
                    gunDescStackPanel.Children.Add(descTextBlock);
                }
                else if (searchTerm == "") // if search term is empty it displays all the guns again.
                {
                    foreach (var gun1 in gunsData)
                    {

                        TextBlock nameTextBlock = new TextBlock
                        {
                            Text = gun1.GunName,
                            FontSize = 16,
                            Margin = new Thickness(5),
                            Foreground = System.Windows.Media.Brushes.White
                        };

                        TextBlock descTextBlock = new TextBlock
                        {
                            Text = gun1.GunDescription,
                            FontSize = 14,
                            Margin = new Thickness(5),
                            Foreground = System.Windows.Media.Brushes.LightGray,
                            TextWrapping = TextWrapping.Wrap
                        };

                        gunNameStckPanel.Children.Add(nameTextBlock);
                        gunDescStackPanel.Children.Add(descTextBlock);

                    }
                }

            }
        }

        private void searchTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTxtBox.Clear();
        }
    }
}