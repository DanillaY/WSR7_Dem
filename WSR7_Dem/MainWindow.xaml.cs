using System.Windows;
using WSR7_Dem.Frame;
using WSR7_Dem.Pages;

namespace WSR7_Dem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.frameObj = MainFrame;
            MainFrame.Navigate(new MainPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.CanGoBack)
                MainFrame.GoBack();
        }
    }
}
