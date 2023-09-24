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

namespace WpfAppPract9
{
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие нового письма уеуе
            Window1 newMessage = new();
            newMessage.To.Text = From.Text;
            newMessage.Subject.Text = "ответ на Ваше письмо";
            newMessage.Show();
        }
    }
}
