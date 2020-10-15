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

namespace MWCTools
{
    /// <summary>
    /// Interaction logic for LicenseInstall.xaml
    /// </summary>
    public partial class LicenseInstall : Window
    {
        LicenseVerification verification = new LicenseVerification();
        public LicenseInstall()
        {
            InitializeComponent();
        }

        private void install_Click(object sender, RoutedEventArgs e)
        {
            verification.copyLicense(FileNameTextBox.Text);
            MessageBox.Show("File Copied!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".txt";
            openFileDlg.Filter = "Text documents (.txt)|*.txt";
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                FileNameTextBox.Text = openFileDlg.FileName;

            }
        }
    }
}
