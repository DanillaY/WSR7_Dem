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
using System.Windows.Navigation;
using WSR7_Dem.Pages;
using WSR7_Dem.DataBase;
using WSR7_Dem.Frame;

namespace WSR7_Dem.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage(User user)
        {
            InitializeComponent();
            UserRole.Text = user.Role.RoleName;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frameObj.Navigate(new AddProductPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frameObj.Navigate(new DeleteProductpage());
        }
    }
}
