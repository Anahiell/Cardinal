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

namespace CardinalL.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CheckRegistrCode : Window
    {
        private readonly string userMail;
        private readonly int expectedCode;
        private int attemptsLeft = 5; // Количество попыток ввода кода

        public CheckRegistrCode(string userMail, int expectedCode)
        {
            InitializeComponent();
            this.userMail = userMail;
            this.expectedCode = expectedCode;
        }
        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox_Code.Text, out int enteredCode))
            {
                if (enteredCode == expectedCode)
                {
                    MessageBox.Show("Code is correct. Registration successful!");
                    DialogResult = true; // Закрытие окна с результатом "успех"
                }
                else
                {
                    attemptsLeft--;

                    if (attemptsLeft > 0)
                    {
                        MessageBox.Show($"Code is incorrect. {attemptsLeft} attempts left.");
                    }
                    else
                    {
                        MessageBox.Show("Too many incorrect attempts. Registration failed.");
                        DialogResult = false; // Закрытие окна с результатом "неудача"
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid code format. Please enter a valid numeric code.");
            }
        }
    }
}
