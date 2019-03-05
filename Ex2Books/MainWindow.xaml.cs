using System.Windows;

using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System;

namespace Ex2Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> booklist;
        public ObservableCollection<Book> bookResults;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //create a new window
            AddBook ab = new AddBook();

            //set owner for that window
            ab.Owner = this;

            //display new window
            ab.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //add the genres to the combo box
            string[] genres = new string[] { "Fiction", "Biography", "Fantasy" };
            Array.Sort(genres);
            cbxGenre.ItemsSource = genres;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //check that i have items to write
            if (booklist.Count > 0)
            {
                //formulate json string
                string json = JsonConvert.SerializeObject(booklist, Formatting.Indented);

                //use a streamwriter
                using (StreamWriter sw = new StreamWriter(@"c:\temp\books.json"))
                {
                    //write json
                    sw.Write(json);
                }
                
            }

        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            //use a streamreader
            using (StreamReader sr = new StreamReader(@"c:\temp\books.json"))
            {
                //read info 
                string json = sr.ReadToEnd();

                //deserialise
                booklist = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
            }

            lbxBooks.ItemsSource = booklist;


        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //determine what was selected
            Book selectedBook = lbxBooks.SelectedItem as Book;

            if (selectedBook != null)
            {
                //remove from collection
                booklist.Remove(selectedBook);
            }

            
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //retrieve the search term
            string searchTerm = tbxSearch.Text.ToLower();

            //clear the results
            if (bookResults == null)
                bookResults = new ObservableCollection<Book>();
            bookResults.Clear();

            //loop through books to find matching book titles
            foreach (Book b in booklist)
            {
                if (b.Title.ToLower().Contains(searchTerm))
                    bookResults.Add(b);
            }

            //update the display
            lbxBooks.ItemsSource = bookResults;

        }

        private void TbxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSearch.Clear();
        }

        private void CbxGenre_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //retrieve the search term
            string searchTerm = cbxGenre.SelectedItem as string;

            //clear the results
            if (bookResults == null)
                bookResults = new ObservableCollection<Book>();
            bookResults.Clear();

            //loop through books to find matching book titles
            foreach (Book b in booklist)
            {
                if (b.Genre.Equals(searchTerm))
                    bookResults.Add(b);
            }

            //update the display
            lbxBooks.ItemsSource = bookResults;
        }
    }
}
