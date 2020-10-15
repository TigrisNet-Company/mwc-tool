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

namespace MWCTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                textBoxEmail.Text = Properties.Settings.Default.UserName;
                passwordBox1.Password = Properties.Settings.Default.PassUser;
            }
        }


        ToolsWindow settingsWindow = new ToolsWindow();
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

            if (checkRemember.IsChecked == true)
            {
                Properties.Settings.Default.UserName = textBoxEmail.Text;
                Properties.Settings.Default.PassUser = passwordBox1.Password;
                Properties.Settings.Default.Save();
            }

            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "please enter an email";
            }

            if (textBoxEmail.Text.Equals("admin"))
            {
                if (passwordBox1.Password.Equals("123TNC"))
                {
                    settingsWindow.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "invalid password";
                }

            }
            else
            {
                errormessage.Text = "invalid email and password";
            }

        }
    }
}

