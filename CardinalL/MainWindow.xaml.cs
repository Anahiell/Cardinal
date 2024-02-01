using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardinalL.Data.Entityes;
using CardinalL.Views;
namespace CardinalL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();
            dataContext = new DataContext();
        }

        private void Button_Click_SingIn(object sender, RoutedEventArgs e)
        {
            // Получение введенных пользователем данных
            string usernameOrEmail = TextBox_Username.Text;
            string password = PassBox.Password.ToString();

            if (dataContext.AuthenticateUser(usernameOrEmail, password))
            {
                // Если аутентификация успешна, отобразить интерфейс пользователя
                int userId = dataContext.GetUserIdByUsernameOrEmail(usernameOrEmail); 

                if (userId != -1)
                {
                    ShowUserProfileInterface(userId);
                }
            }
            else
            {
                // Вывести сообщение об ошибке или предложить повторить попытку
                MessageBox.Show("Invalid username/email or password. Please try again.");
            }
        }
        private void ShowUserProfileInterface(int userID)
        {
            UserPage userPage = new UserPage(userID);
            this.Content = userPage;
        }
        private void Button_Click_SingUp(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            RegistrationWindow registrationWindow = new RegistrationWindow(dataContext);
            registrationWindow.ShowDialog();

            // После завершения регистрации разблокир главное окно
            this.IsEnabled = true;
        }
    }
}