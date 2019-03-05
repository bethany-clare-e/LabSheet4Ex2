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

namespace Ex2Books
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read info from screen
            string title = tbxTitle.Text;

            decimal price;
            if (!Decimal.TryParse(tbxPrice.Text, out price))
                MessageBox.Show("Invalid format for price");

            DateTime purchaseDate = dpDate.SelectedDate.Value;

            string genre = cbxGenre.SelectedItem as string;

            //create object with data
            Book b1 = new Book() { Title = title, Price = price, PurchaseDate = purchaseDate, Genre = genre };

            //add object to collection on main window
            MainWindow main = this.Owner as MainWindow;
            main.booklist.Add(b1);

            //close
            this.Close();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string [] genres = new string[] { "Fiction", "Biography", "Fantasy" };
            Array.Sort(genres);
            cbxGenre.ItemsSource = genres;
        }
    }
}
