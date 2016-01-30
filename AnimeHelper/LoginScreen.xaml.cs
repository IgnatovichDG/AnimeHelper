using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace AnimeHelper
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }


        private async void SignInButton_OnClick(object sender, RoutedEventArgs e)
        {
            Model model = new Model();
            try
            {
                var check = await model.UserVerify(LoginTextBox.Text, PasswordBox.Password);
            
            if (check == HttpStatusCode.OK)
            {
                MessageBox.Show("Добро пожаловать!", "Welcome");
                MainWindow mw = new MainWindow(model);
                mw.Show();
                this.Close();
            }
            else if(check == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
            else
            {
                MessageBox.Show(check.ToString());
            }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Проверьте Ваше соединение с интернетом.");
            }

        }

        private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://myanimelist.net/register.php?from=%2F");
        }
    }
}
