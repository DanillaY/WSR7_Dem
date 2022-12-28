using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WSR7_Dem.DataBase;
using WSR7_Dem.Frame;

namespace WSR7_Dem.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Captcha1TextBlock.Text = CreateCaptcha();
            Captcha2TextBlock.Text = CreateCaptcha();
        }
        private static string CreateCaptcha()
        {
            string symbols = "qwertyuiopadhfgjklvcxnm";
            string captcha = string.Empty;
            for (int i = 0; i < 3; i++)
                captcha += symbols[new Random().Next(symbols.Length)];
            return captcha;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(Captcha1TextBlock.Text + Captcha2TextBlock.Text == CaptchaTextBox.Text)
            {
                foreach(User user in WSR7EntitiesDemexam.GetContext().User.ToList())
                {
                    if (user.UserPassword == PasswordTextBox.Text && user.UserLogin == LoginTextBox.Text && user.UserRole == 1)
                        FrameManager.frameObj.Navigate(new AdminPage(user));
                    if (user.UserPassword == PasswordTextBox.Text && user.UserLogin == LoginTextBox.Text && user.UserRole == 2 || user.UserRole == 3)
                        FrameManager.frameObj.Navigate(new ManagerPage(user));
                }
            }
            else
            {
                MessageBox.Show("Ошибка","Введен неверная капча",MessageBoxButton.OK,MessageBoxImage.Error);
                Thread.Sleep(10000);
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frameObj.Navigate(new ShowProductPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Ошибка", "Не удалось выйти из приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
