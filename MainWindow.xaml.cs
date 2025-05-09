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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RustWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Main menu is all navigation, does nothing special
        private void animalsBTN_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the Animals window
            AnimalsWindow animalsWindow = new AnimalsWindow();
            animalsWindow.Show();
            this.Close();
            MessageBox.Show("This is the animals page (search is case-sensitive)"); // hops to the animals window
        }


        private void mainMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            // This is already the main window
            MessageBox.Show("Already in Main Menu"); // says its already in the main menu
        }

 

        private void gunsBTN_Click_1(object sender, RoutedEventArgs e)
        {

            // Open Guns window
            GunsWindow gunsWindow = new GunsWindow();
            gunsWindow.Show();
            this.Close();
            MessageBox.Show("This is the guns window (search is case sensitive"); // hops to the guns window
        }

        private void itemsBTN_Click_1(object sender, RoutedEventArgs e)
        {
            ItemsWindow itemsWindow = new ItemsWindow();
            itemsWindow.Show();
            this.Close();
            MessageBox.Show("This is the items page (search is case-sensitive)"); // hops to the items window
        }
    }
}