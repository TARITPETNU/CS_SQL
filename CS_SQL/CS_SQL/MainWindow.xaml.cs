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

namespace CS_SQL
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.InitializeDatabase();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.AddData(0, "T", "P", "R");
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            string data = "";
            foreach (string inside in dataAccess.GetData())
            {
                data = data + " " + inside;
            }
            MessageBox.Show(data);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 nextPage = new Window2();
            nextPage.Show();
        }

        private void Showw_Click(object sender, RoutedEventArgs e)
        {
            string data = " ";
            foreach (string _data in dataAccess.search(searchTxt.Text))
            {
                    data = data + "\n " + _data;
                  
            }

            MessageBox.Show(data);
        }

        private void createStore_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.ceareTable();
        }

        private void Insert_Click_1(object sender, RoutedEventArgs e)
        {
            dataAccess.addBook(00, "Kino I", 250);
            dataAccess.addBook(01, "Kino II", 249);
        }

       
    }
}
