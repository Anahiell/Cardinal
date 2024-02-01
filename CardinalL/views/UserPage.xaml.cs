using CardinalL.Data.Entityes;
using CardinalL.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CardinalL.Views
{
    public partial class UserPage : UserControl
    {
        public UserPageViewModel viewModel;

        private int selectedChatId;
        public int UserId { get; set; }

        public UserPage(int userId)
        {
            this.UserId = userId;
            InitializeComponent();

            viewModel = new UserPageViewModel();
            DataContext = viewModel;

            LoadChatListAsync();
        }

        public async void LoadChatListAsync()
        {
            using (var context = new DataContext())
            {
                var userChats = await context.UserChats.Where(uc => uc.User.Id == UserId).ToListAsync();

                viewModel.Chats = new ObservableCollection<ChatBox>();

                foreach (var userChat in userChats)
                {
                    var chat = await context.Chats.FirstOrDefaultAsync(c => c.ChatId == userChat.ChatId);
                    if (chat != null)
                    {
                        viewModel.Chats.Add(chat);
                    }
                }

                chatListBox.ItemsSource = viewModel.Chats;
            }
        }

        public async Task LoadMessageListAsync()
        {
            using (var context = new DataContext())
            {
                viewModel.Messages.Clear();

                if (viewModel.SelectedChatId != 0)
                {
                    var newMessages = await context.Messages
    .Where(message => message.ChatBox.ChatId == viewModel.SelectedChatId)
    .OrderByDescending(message => message.Timestamp)
    .ToListAsync();

                    foreach (var newMessage in newMessages)
                    {
                        viewModel.Messages.Add(newMessage);
                    }

                    messageListBox.ItemsSource = viewModel.Messages;
                }
            }
        }

        private void ChatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chatListBox.SelectedItem is ChatBox selectedChat)
            {
                viewModel.SelectedChatId = selectedChat.ChatId;

                MessageBox.Show($"{viewModel.SelectedChatId}");
                LoadMessageListAsync();
            }
        }
    }
}

