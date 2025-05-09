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
    public partial class ItemsWindow : Window
    {
        private readonly RustData _context; // This links to my RustData that is in the DataManageMentRust Program.cs
        public ItemsWindow()
        {
            InitializeComponent();
            _context = new RustData(); // setting _context to a new instance of RustData
            LoadItemsData(); // function for loading all my information from the Items table in my database
        }
        private void LoadItemsData()
        {
            var itemsData = _context.Items.ToList(); // This links to my RustData that is in the DataManageMentRust Program.cs

            itemNameStckPanel.Children.Clear(); // clears my itemNameStckPanel
            itemDescStackPanel.Children.Clear(); // clears my itemDescStackPanel



            foreach (var item in itemsData) // for each item in the database is pulled an displayed
            {
                TextBlock nameTextBlock = new TextBlock
                {
                    Text = item.ItemName,
                    FontSize = 16,
                    Margin = new Thickness(5),
                    Foreground = System.Windows.Media.Brushes.White
                };

                TextBlock descTextBlock = new TextBlock
                {
                    Text = item.ItemDescription,
                    FontSize = 14,
                    Margin = new Thickness(5),
                    Foreground = System.Windows.Media.Brushes.LightGray,
                    TextWrapping = TextWrapping.Wrap
                };

                itemNameStckPanel.Children.Add(nameTextBlock); // this adds the items to the Name stack panel
                itemDescStackPanel.Children.Add(descTextBlock); // this adds the item desc to the desc stack panel
            }
        }
        private void animalsBTN3_Click(object sender, RoutedEventArgs e)
        {
            AnimalsWindow animalsWindow = new AnimalsWindow();
            animalsWindow.Show();
            this.Close();
            MessageBox.Show("This is the animals window (search is case sensitive)"); // hops to the animals window
        }

        private void gunsBTN_Click(object sender, RoutedEventArgs e)
        {
            GunsWindow gunsWindow = new GunsWindow();
            gunsWindow.Show();
            this.Close();
            MessageBox.Show("This is the guns window (search is case sensitive)"); // hops to the guns window
        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
        }

        private void searchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void searchBTN_Click_1(object sender, RoutedEventArgs e)
        {

            string searchTerm = searchTxtBox.Text; // search bar term
            searchTerm.ToUpper();
            MessageBox.Show($"Searching for: {searchTerm}");
            itemNameStckPanel.Children.Clear();
            itemDescStackPanel.Children.Clear(); // clears the stack panels

            // SEARCHES THE DATABASE
            var itemsData = _context.Items.ToList(); // itemsData is equal to the data that is stored within the Items database.
            foreach (var item in itemsData)
            {
                if (searchTerm == item.ItemName) // if the search term is equal to a name in the database it only displays that item
                {
                    TextBlock nameTextBlock = new TextBlock
                    {
                        Text = item.ItemName,
                        FontSize = 16,
                        Margin = new Thickness(5),
                        Foreground = System.Windows.Media.Brushes.White // creating text block for item name
                    };

                    TextBlock descTextBlock = new TextBlock
                    {
                        Text = item.ItemDescription,
                        FontSize = 14,
                        Margin = new Thickness(5),
                        Foreground = System.Windows.Media.Brushes.LightGray,
                        TextWrapping = TextWrapping.Wrap // creating text block for item description
                    };

                    itemNameStckPanel.Children.Add(nameTextBlock); // adding the text blocks to the stack panels
                    itemDescStackPanel.Children.Add(descTextBlock);
                }
                else if (searchTerm == "") /// if search term is empty displays all data
                {
                    foreach (var item1 in itemsData)
                    {

                        TextBlock nameTextBlock = new TextBlock
                        {
                            Text = item1.ItemName,
                            FontSize = 16,
                            Margin = new Thickness(5),
                            Foreground = System.Windows.Media.Brushes.White
                        };

                        TextBlock descTextBlock = new TextBlock
                        {
                            Text = item1.ItemDescription,
                            FontSize = 14,
                            Margin = new Thickness(5),
                            Foreground = System.Windows.Media.Brushes.LightGray,
                            TextWrapping = TextWrapping.Wrap
                        };

                        itemNameStckPanel.Children.Add(nameTextBlock);
                        itemDescStackPanel.Children.Add(descTextBlock);

                    }
                }

            }
        }

        private void animalsBTN3_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void searchTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTxtBox.Clear();
        }

        private void mainMenuBTN_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            MessageBox.Show("Welcome back to the Main Menu"); // hops back to the main menu
        }
    }
}
