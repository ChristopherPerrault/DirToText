using System.IO;
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
            using (var folderSelectDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderSelectDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedFolder = folderSelectDialog.SelectedPath;
                    if (!string.IsNullOrEmpty(selectedFolder))
                    {
                        Lbl_SelectedFolder.Content = selectedFolder;
                        Btn_SelectFolder.Content = "Reselect Folder...";
                    }
                    else
                    {
                        //TODO: does not trigger properly
                        TB_Message.Text = "❌ Folder has no contents!";
                    }


                }
            }
        }
        private void Btn_Export_Click(object sender, RoutedEventArgs e)
        {

            string selectedFolder = Lbl_SelectedFolder.Content as string;
            if (string.IsNullOrEmpty(selectedFolder) || !Directory.Exists(selectedFolder))
            {
                TB_Message.Text = "❌ Folder is either empty or doesn't exist!";
                return;
            }

            string[] fileNames = Directory.GetFiles(selectedFolder);

            string selectedFormat = GetSelectedFormat();

            string outputFile = Path.Combine(selectedFolder, "file_names" + selectedFormat);
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                // Includes folder name at top of output file
                if (ChkBox_IncludeFolderName.IsChecked == true)
                {
                    string folderName = Path.GetFileName(selectedFolder);
                    writer.WriteLine("Folder Name: " + folderName);
                    writer.WriteLine();
                }

                foreach (string fileName in fileNames)
                {
                    // Include full file path (includes file extension)
                    if (ChkBox_IncludeFilepath.IsChecked == true)
                    {
                        writer.WriteLine(fileName);
                    }
                    else
                    {
                        string fileNameToWrite = fileName;

                        // Exclude file extension (but if 'full file path' selected it will override this)
                        if (ChkBox_IncludeFileExt.IsChecked == false)
                        {
                            fileNameToWrite = Path.GetFileNameWithoutExtension(fileName);
                        }

                        writer.WriteLine(fileNameToWrite);
                    }
                }
            }

            TB_Message.Text = "✔ File names exported successfully to selected folder!";


        }
        private string GetSelectedFormat()
        {
            if (RadioBtn_txt.IsChecked == true)
            {
                return ".txt";
            }
            else if (RadioBtn_docx.IsChecked == true)
            {
                return ".docx";
            }
            else if (RadioBtn_csv.IsChecked == true)
            {
                return ".csv";
            }
            else
            {
                // as a failsafe will always revert to .xt format
                return ".txt";
            }
        }

    }
}
