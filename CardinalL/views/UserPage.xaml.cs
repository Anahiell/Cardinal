using CardinalL.Data.Entityes;
using CardinalL.DataService;
using CardinalL.views.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CardinalL.views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserPage : UserControl
    {
        private UserViewModel userViewModel;
        private int userId;
        private DataContext dataContext;
        private List<FriendViewModel> friendsList;
        private DataServ dataServ;

        public UserPage(int userID)
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
            this.userId = userID;
            this.dataContext = new DataContext();
            dataServ = new DataServ(dataContext);

            // Загрузка профиля при открытии страницы
            _ = LoadUserProfileDataAsync();
            MessageBox.Show($"{userID}");
        }

        private async Task LoadUserProfileDataAsync()
        {
            userViewModel = await dataServ.LoadUserProfileDataAsync(userId);
            // Обновите биндинги или другие элементы управления согласно вашей логике
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchingTextBox.Text;
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ваш код обработки изменения выбранной вкладки
        }

    }
}
