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

namespace ListBoxLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Product product = new Product("Potato", 30, "Grey");
            Shop.Items.Add(product);

           
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(PriceField.Text, out int res);
            Product product = new Product(NameField.Text, res, DescriptionField.Text);
            Shop.Items.Add(product);
            NameField.Text = "";
            PriceField.Text = "";
        }

        class Product
        {
            public Product(string name, int price, string description)
            {
                Name = name;
                Price = price;
                Description = description;  
            }

            public string Name { get; set; }
            public int Price { get; set; }

            public string Description { get; set; }

            public override string ToString()
            {
                return $"{Name}: {Price}";
            }


        }

        private void Shop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if( Shop.SelectedItem != null)
           {
                Product product = Shop.SelectedItem as Product;


                DescriptionOutput.Text = product.Description;
           }
        }

       
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Cart.Items.Add(Shop.SelectedItem);
        }
    }
}
