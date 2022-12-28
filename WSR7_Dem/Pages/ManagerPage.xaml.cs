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
using System.Windows.Shapes;
using WSR7_Dem.DataBase;

namespace WSR7_Dem.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage(User user)
        {
            InitializeComponent();
            RoleTextBlock.Text = user.Role.RoleName;
            ListProduct.ItemsSource = WSR7EntitiesDemexam.GetContext().Product.ToList();
            SetUpComboBox();
        }
        private void SetUpComboBox()
        {
            FilterTextBox.ItemsSource = WSR7EntitiesDemexam.GetContext().Product.Select(x => x.ProductManufacturer).Distinct().ToList();
            FilterTextBox.Text.Insert(0, "Все производители");
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var source = WSR7EntitiesDemexam.GetContext().Product.ToList();
            if (SearchTextBox.Text != "")
                source = source.Where(x => x.ProductName.ToLower().StartsWith(SearchTextBox.Text.ToLower())).ToList();
            ListProduct.ItemsSource = source;
        }
        private void UpdateSource(object sender, SelectionChangedEventArgs e)
        {
            var source = WSR7EntitiesDemexam.GetContext().Product.ToList();
            if (SearchTextBox.Text != "")
                source = source.Where(x => x.ProductName.ToLower().StartsWith(SearchTextBox.Text.ToLower())).ToList();
            if (SearchTextBox.Text != "")
                source = source.Where(x => x.ProductName.ToLower() == SearchTextBox.Text.ToLower()).ToList();
            switch (SortTextBox.SelectedIndex)
            {
                case 0:
                    source = source.OrderBy(x => x.ProductCost).ToList();
                    break;
                case 1:
                    source = source.OrderByDescending(x => x.ProductCost).ToList();
                    break;
            }
            switch (FilterTextBox.SelectedIndex)
            {
                case 0:
                    source = source.Where(x => x.ProductManufacturer == "Alaska").ToList();
                    break;
                case 1:
                    source = source.Where(x => x.ProductManufacturer == "Apollo").ToList();
                    break;
                case 2:
                    source = source.Where(x => x.ProductManufacturer == "Attribute").ToList();
                    break;
                case 3:
                    source = source.Where(x => x.ProductManufacturer == "Davinci").ToList();
                    break;
                case 4:
                    source = source.Where(x => x.ProductManufacturer == "Doria").ToList();
                    break;
                case 5:
                    source = source.Where(x => x.ProductManufacturer == "Mayer & Boch").ToList();
                    break;
                case 6:
                    source = source.Where(x => x.ProductManufacturer == "Smart Home").ToList();
                    break;
            }
            ListProduct.ItemsSource = source;
        }
    }
}
