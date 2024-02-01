using CardinalL.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardinalL.ViewModel
{

    public class UserPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChatBox> _chats;
        private ObservableCollection<Message> _messages;
        private int _selectedChatId;

        public int SelectedChatId
        {
            get { return _selectedChatId; }
            set
            {
                _selectedChatId = value;
                OnPropertyChanged(nameof(SelectedChatId));
            }
        }
        public ObservableCollection<ChatBox> Chats
        {
            get { return _chats; }
            set
            {
                _chats = value;
                OnPropertyChanged(nameof(Chats));
            }
        }

        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }
        public UserPageViewModel()
        {
            Messages = new ObservableCollection<Message>();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
