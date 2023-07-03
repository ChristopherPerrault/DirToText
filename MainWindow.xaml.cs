using System.Windows;
using System.Windows.Forms;

namespace DirToText
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


        private void Btn_SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedFolder = dialog.SelectedPath;
                    Lbl_SelectedFolder.Content = selectedFolder;
                    Btn_SelectFolder.Content = "Reselect Folder...";
                }
            }
        }

        private void ChkBox_IncludeFileExt_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkBox_IncludeFolderName_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkBox_IncludeFilepath_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioBtn_csv_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioBtn_txt_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioBtn_docx_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Export_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
