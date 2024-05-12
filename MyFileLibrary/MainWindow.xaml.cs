using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFileLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DriveInfo[] drives;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
               DriveList.Items.Add(drive);
            }

       }

        private void DriveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var d = drives[DriveList.SelectedIndex];
            if (d.IsReady)
            {
                string[] directories = Directory.GetDirectories(d.RootDirectory.FullName);
                DriveInfoList.Items.Clear();
                foreach (string directory in directories)
                {
                    DriveInfoList.Items.Add(directory);
                }
                string[] files = Directory.GetFiles(d.RootDirectory.FullName);
               InfoList.Items.Clear();  
                foreach (string file in files)
                {
                    InfoList.Items.Add(file);
                }
            }
            else { MessageBox.Show("Drive is not ready"); }
        }
        private void InfoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}



//if (drive.IsReady)
//{
//    string[] directories = Directory.GetDirectories(drive.RootDirectory.FullName);
//    foreach (string directory in directories)
//    {
//        DriveInfoList.Items.Add(directory);
//    }
//    string[] files = Directory.GetFiles(drive.RootDirectory.FullName);
//    foreach (string file in files)
//    {
//        InfoList.Items.Add(file);
//    }
//}
//else { MessageBox.Show("Drive is not ready"); }