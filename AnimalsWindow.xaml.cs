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

namespace RustWPFApp // Matching your namespace from the XAML
{
    public partial class AnimalsWindow : Window
    {
        private readonly RustData _context; // This links to my RustData that is in the DataManageMentRust Program.cs
        public AnimalsWindow()
        {
            InitializeComponent();
            _context = new RustData(); // _context is set to a new instance of RustData
            LoadAnimalsData(); // Loads the Animals data in the Database.
        }

        private void LoadAnimalsData()
        {
            var animalsData = _context.Animals.ToList(); // This links to my RustData that is in the DataManageMentRust Program.cs

            animalNameStckPanel.Children.Clear();
            animalDescStackPanel.Children.Clear();

            foreach (var animal in animalsData)
            {
                TextBlock nameTextBlock = new TextBlock
                {
                    Text = animal.AnimalName,
                    FontSize = 16,
                    Margin = new Thickness(5),
                    Foreground = System.Windows.Media.Brushes.White // creates a textblock for the name part of the Aniamls
                };

                TextBlock descTextBlock = new TextBlock
                {
                    Text = animal.AnimalDescription,
                    FontSize = 14,
                    Margin = new Thickness(5),
                    Foreground = System.Windows.Media.Brushes.LightGray, // creates a new textblock for the description part of the Animals
                    TextWrapping = TextWrapping.Wrap
                };

                animalNameStckPanel.Children.Add(nameTextBlock); // adds the txtblock name
                animalDescStackPanel.Children.Add(descTextBlock); // add the txtblock desc
            }
        }
        private void animalsBTN1_Click(object sender, RoutedEventArgs e)
        {
 

        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
        }


        private void searchTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTxtBox.Clear();
        }

        private void gunsBTN_Click_1(object sender, RoutedEventArgs e)
        {
            GunsWindow gunsWindow = new GunsWindow();
            gunsWindow.Show();
            this.Close();
            MessageBox.Show("This is the guns page (search is case-sensitive)"); // hops to guns menu
        }

        private void itemsBTN_Click_1(object sender, RoutedEventArgs e)
        {
            ItemsWindow itemsWindow = new ItemsWindow();
            itemsWindow.Show();
            this.Close();
            MessageBox.Show("This is the items page (search is case-sensitive)"); // hops to items menu
        }

        private void mainMenuBTN_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            MessageBox.Show("Welcome back to the Main Menu"); // hops back to the main menu
        }

        private void searchBTN_Click_1(object sender, RoutedEventArgs e)
        {


            string searchTerm = searchTxtBox.Text; // search bar 
            searchTerm.ToUpper();
            MessageBox.Show($"Searching for: {searchTerm}");
            animalNameStckPanel.Children.Clear(); // clears the animalNameStckPanel
            animalDescStackPanel.Children.Clear(); // clears the animalDescStackPanel

            // SEARCHES THE DATABASE
            var animalsData = _context.Animals.ToList();
            foreach (var animal in animalsData)
            {
                if (searchTerm == animal.AnimalName) // if the search term is equal to the animal name is adds it to the table and removes the others
                {
                    TextBlock nameTextBlock = new TextBlock
                    {
                        Text = animal.AnimalName,
                        FontSize = 16,
                        Margin = new Thickness(5),
                        Foreground = System.Windows.Media.Brushes.White
                    };

                    TextBlock descTextBlock = new TextBlock
                    {
                        Text = animal.AnimalDescription,
                        FontSize = 14,
                        Margin = new Thickness(5),
                        Foreground = System.Windows.Media.Brushes.LightGray,
                        TextWrapping = TextWrapping.Wrap
                    };

                    animalNameStckPanel.Children.Add(nameTextBlock);
                    animalDescStackPanel.Children.Add(descTextBlock);
                }
                else if (searchTerm == "") // if the search term is empty it displays all the animals again.
                {
                    foreach (var animal1 in animalsData)
                    {

                        TextBlock nameTextBlock = new TextBlock
                        {
                            Text = animal1.AnimalName,
                            FontSize = 16,
                            Margin = new Thickness(5),
                            Foreground = System.Windows.Media.Brushes.White
                        };

                        TextBlock descTextBlock = new TextBlock
                        {
                            Text = animal1.AnimalDescription,
                            FontSize = 14,
                            Margin = new Thickness(5),
                            Foreground = System.Windows.Media.Brushes.LightGray,
                            TextWrapping = TextWrapping.Wrap
                        };

                        animalNameStckPanel.Children.Add(nameTextBlock);
                        animalDescStackPanel.Children.Add(descTextBlock);

                    }
                }

            }
        }
    }
}