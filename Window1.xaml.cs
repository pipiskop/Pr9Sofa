using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfAppPract9
{
    public partial class Window1 : Window
    {
        public Window1()
        { InitializeComponent(); }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        { Close(); }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            var credentails = ImapHelper.GetCredentials();
            var text = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);

            HTMLRtfConverter.ToHtml(new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd));
            text.Text = File.ReadAllText("send.html");

            //для очистки
            File.Delete("send.html");


            MailMessage m = new MailMessage(credentails.Email, To.Text, Subject.Text, text.Text);
            m.IsBodyHtml = true;

            SmtpClient smpt = new SmtpClient(credentails.SmtpHost);
            smpt.Credentials = new NetworkCredential(credentails.Email, credentails.Pass);
            smpt.EnableSsl = true;
            smpt.Send(m);
        }

        void Save_Rft(string _filename)
        {
            TextRange range = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
            FileStream fileStream = new FileStream(_filename, FileMode.Create);
            range.Save(fileStream, DataFormats.Rtf);
            fileStream.Close();
        }
        void Load_Rft(string _filename)
        {
            if (File.Exists(_filename))
            {
                TextRange textRange = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
                FileStream fileStream = new FileStream(_filename, FileMode.OpenOrCreate);
                textRange.Load(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }
        }

        private void LoadRft_Click(object sender, RoutedEventArgs e)
        {
            Load_Rft("C:\\Рабочий стол\\text.txt");
        }

        private void SaveRft_Click(object sender, RoutedEventArgs e)
        {
            Save_Rft("C:\\Рабочий стол\\text.txt");
        }
    }
}
