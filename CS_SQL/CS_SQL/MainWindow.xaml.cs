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
    }
}
