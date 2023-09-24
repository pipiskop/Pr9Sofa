using System.Windows;
using System.Windows.Controls;
using ImapX;

namespace WpfAppPract9
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void authenticateButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTxt.Text.Trim();
            string password = Passwordtxt.Password;

            if (email == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Поля не должны оставаться пустыми!");
            }
            else {
                ImapHelper.Initialize((MailClientCbx.SelectedItem as ComboBoxItem).Tag.ToString());
                if (ImapHelper.Login(email, password)) 
                {
                    //переход на новое окно
                    EmailFoldersWindow emailFoldersWindow = new EmailFoldersWindow();
                    emailFoldersWindow.Show();
                    Close();
                }
            }
        }
    }
}
