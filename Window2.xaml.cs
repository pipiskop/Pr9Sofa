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
using System.Collections.ObjectModel;
using ImapX.Collections;
using ImapX;
using Microsoft.Graph.Models;
using Microsoft.Graph.Privacy;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Message = Microsoft.Graph.Models.Message;

namespace WpfAppPract9
{
    public partial class EmailFoldersWindow : Window
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();
        private List<string> listFolders = new();
        private MessageCollection messages;
        private List<string> listMessages = new();

        private Task task;

        public EmailFoldersWindow()
        {
            InitializeComponent();
            foreach (var item in folders) {
                listFolders.Add(item.Name);
            }
            FoldersList.ItemsSource = listFolders;
            /*FoldersList.ItemsSource = folders; 
            FoldersList.DisplayMemberPath = folders.ToString();*/ //НЕ РАБОТАЕТ

        }

        private async void FoldersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MessageList.ItemsSource = "";
            //progBar.Visibility = Visibility.Visible;
            await LoadMessages();

            listMessages.Clear();
            foreach (var item in messages)
            {
                listMessages.Add(item.Subject);
            }
            MessageList.ItemsSource = listMessages;
            //MessageList.ItemsSource = messages; неа
            //progBar.Visibility = Visibility.Hidden;
            //task.Dispose();
        }

        /*
sysysy_sy@mail.ru
12NpK2tLFx9fwYp4GiSg
        */

        /*что эта*/
        private async Task LoadMessages()
        {
            messages = ImapHelper.GetMessagesForFolder(FoldersList.SelectedItem.ToString());
        }
        /*конец*/



        private void MessageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //(MessageList.SelectedItem as Message);
            Window3 OpenedMessage = new();
            OpenedMessage.Show();
            OpenedMessage.Date.Text = messages[1].Date.ToString(); //wtf
            //OpenedMessage.Date.Text = (sender as Message).SentDateTime.ToString(); //wtf
            OpenedMessage.From.Text = messages[1].From.ToString();
            //OpenedMessage.From.Text = (sender as Message).From.ToString();
            OpenedMessage.Subject.Text = messages[1].Subject.ToString();
            //OpenedMessage.Subject.Text = (sender as Message).Subject.ToString();
            OpenedMessage.BodyBox.Text = messages[1].Body.Text;
            //OpenedMessage.BodyBox.Text = (sender as Message).Body.Content;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 NewMessage = new();
            NewMessage.Show();
        }
    }
}

        

