using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using CardinalL.Data.Entityes;

namespace CardinalL.Views
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly DataContext dataContext;
        private string? host { get; set; } = null!;
        private string? port { get; set; }
        private string? mailbox { get; set; }
        private string? key { get; set; }
        private string? userMail { get; set; }
        private string? password { get; set; }
        private int codeValid { get; set; }
        private Random random { get; set; }
        public RegistrationWindow(DataContext dataContext)
        {
            InitializeComponent();
            var some = JsonSerializer.Deserialize<JsonNode>(
          File.ReadAllText("CardinalPconfig.json"));
            host = some?["emails"]?["gmail"]?["host"]?.ToString();
            port = some?["emails"]?["gmail"]?["port"]?.ToString();
            mailbox = some?["emails"]?["gmail"]?["mailbox"]?.ToString();
            key = some?["emails"]?["gmail"]?["key"]?.ToString();
            if (host == null || port == null || mailbox == null || key == null)
            {
                MessageBox.Show("reading config fail");
                return;
            }

            this.dataContext = dataContext;

            random = new Random();
            TextBlockCapcha.Text = $"{random.Next(10)}+{random.Next(10)}=";
        }

        private async void Button_Regist_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Mail.Text == null || (PassBox.Password == null && PassBox2.Password == null))
                return;

            userMail = TextBox_Mail.Text;
            password = PassBox.Password;

            if (!IsValidRegistration())
            {
                return; // Отмена регистрации в случае неудачи
            }
            codeValid = random.Next(1000, 9999);

            await SendCode(codeValid.ToString(), new SmtpClient(host)
            {
                Port = Convert.ToInt32(port),
                Credentials = new NetworkCredential(mailbox, key),
                EnableSsl = true
            });
            await AddUserToDatabase(userMail, TextBox_Username.Text, PassBox.Password, TextBox_Login.Text, TextBox_Phone.Text, codeValid);

            // Закрытие окна после успешной регистрации
            CheckRegistrCode checkCodeWindow = new CheckRegistrCode(userMail, codeValid);
            if (checkCodeWindow.ShowDialog() == true)
            {
                Close();
            }
        }
        private async Task AddUserToDatabase(string email, string username, string password, string login, string phone, int code)
        {
            try
            {
                User newUser = new User
                {
                    Email = email,
                    Name = username,
                    Password = password,
                    Login = login,
                    Phone = phone,
                    CheckCode = code
                };

                dataContext.Users.Add(newUser);
                dataContext.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user to the database: {ex.Message}");

                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }
        private bool IsValidRegistration()
        {
            if (!userMail.Contains("@"))
            {
                MessageBox.Show("Invalid email address.");
                return false;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return false;
            }

            return true;
        }
        private async Task SendCode(string code, SmtpClient smtpClient)
        {
            if (smtpClient == null)
            {
                return;
            }

            MailMessage message = new()
            {
                From = new MailAddress(mailbox),
                Subject = "Cardinal: Registration Code",
                IsBodyHtml = true,
                Body = $"<h2>Hello, user!</h2><p>Your registration code is: <b>{code}</b></p>"
            };
            message.To.Add(new MailAddress(userMail));

            try
            {
                await Task.Run(() => smtpClient.Send(message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
