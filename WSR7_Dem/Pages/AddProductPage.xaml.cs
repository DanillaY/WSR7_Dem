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
using WSR7_Dem.DataBase;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WSR7_Dem.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WSR7EntitiesDemexam.GetContext().Product.Add(new Product()
                {
                    ID = WSR7EntitiesDemexam.GetContext().Product.Max(x=>x.ID)+1,
                    ProductName = TitleTextBox.Text,
                    ProductDescription = DiscTextBox.Text,
                    ProductCategory = CategoryTextBox.Text,
                    ProductPhoto = null,
                    ProductManufacturer = ManufacturerTextBox.Text,
                    ProductCost =decimal.Parse( PriceTextBox.Text),
                    ProductDiscountAmount = null,
                    ProductQuantityInStock = int.Parse(InStockTextBox.Text),
                    ProductStatus = null,
                    ProductPath = null
                });
                WSR7EntitiesDemexam.GetContext().SaveChanges();
                MessageBox.Show("Выполнено", "Продукт был успешно добавлен", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка", "Не удалось добавить продукт", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
