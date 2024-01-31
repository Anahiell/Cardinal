using CardinalL.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CardinalL.views.ViewModels
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if(email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                { phone = value;
                    OnPropertyChanged();
                }

            }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(); }
        }
        private ImageSource avatarImage;
        public ImageSource AvatarImage
        {
            get { return avatarImage; }
            set
            {
                if (avatarImage != value)
                {
                    avatarImage = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
