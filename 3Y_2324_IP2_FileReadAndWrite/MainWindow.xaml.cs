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

namespace _3Y_2324_IP2_FileReadAndWrite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager fm = new FileManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbFilePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbFilePath.Text.Length > 0) 
            {
                btnIOManage.IsEnabled = true;
                if(fm.fileCheck(tbFilePath.Text)) 
                {
                    btnIOManage.Content = "Open File";
                }
                else
                {
                    btnIOManage.Content = "Create File";
                }
            }
            else
            {
                btnIOManage.IsEnabled = false;
            }
        }

        private void btnIOManage_Click(object sender, RoutedEventArgs e)
        {
            if(btnIOManage.Content.ToString() == "Open File")
            {
                List<string> things = new List<string>(); 

                things = fm.readFile(tbFilePath.Text);

                foreach(string thing in things) 
                {
                    tbPlaceToReadWrite.Text += thing + "\n";
                }
            }
            else
            {
                //MessageBox.Show(tbPlaceToReadWrite.Text);
                fm.writeFile(tbFilePath.Text, tbPlaceToReadWrite.Text);
            }
        }
    }
}
