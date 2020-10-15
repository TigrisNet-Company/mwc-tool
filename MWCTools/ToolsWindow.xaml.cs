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
using System.Text.RegularExpressions;
using System.IO;

namespace MWCTools
{
    /// <summary>
    /// Interaction logic for ToolsWindow.xaml
    /// </summary>
    public partial class ToolsWindow : Window
    {
        CustomerSettings customerSettings = new CustomerSettings();
        LicenseVerification licenseVerification = new LicenseVerification();
        LicenseInstall licenseInstall = new LicenseInstall();
        TroubleShoot trouble = new TroubleShoot();
        StreamWriter sw; 
        public ToolsWindow()
        {
            InitializeComponent();
        }

        private void snButton_Click(object sender, RoutedEventArgs e)
        {
            if(Sn.Text.Length == 0)
            {
                errormessage.Text = "please enter station number";
            }else
            {
                errormessage.Text = "";

                customerSettings.generatePort(Sn.Text, sw);
                MessageBox.Show("Updated!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void CoolTabButton2_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            ComboBoxItem en = (ComboBoxItem)Lang.SelectedItem;
            if (en == null)
            {
                errormessage.Text = "please choose a language";
            }
            else
            {
                s = en.Content.ToString();

                customerSettings.createLangFile(s, sw);
                MessageBox.Show("Done", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            if (checkD.IsChecked == true)
            {
                customerSettings.CheckDuplicationFile(sw, true);

            }
            else if(checkD.IsChecked == false)
            {
                customerSettings.CheckDuplicationFile(sw, false);

            }
        }
        private void portNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            licenseInstall.Show();

        }

        private void SendM_Click(object sender, RoutedEventArgs e)
        {
            licenseVerification.sendEmail(Name.Text, Email.Text, License.Text);
            MessageBox.Show("Email Sent! \r\n Please wait for reply", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            License.Text = licenseVerification.generateLicense();
        }

        private void IpButton_Click(object sender, RoutedEventArgs e)
        {
            trouble.checkIp(sw);
            MessageBox.Show("Checked!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void PortButton_Click(object sender, RoutedEventArgs e)
        {
            trouble.checkPort(sw);
           MessageBox.Show("Updated!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void uploadButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
