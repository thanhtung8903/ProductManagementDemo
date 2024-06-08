using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using Services;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService iProductService;
        private readonly ICatergoryService iCatergoryService;
        private ObservableCollection<Product> products;

        public MainWindow()
        {
            InitializeComponent();
            iProductService = new ProductService();
            iCatergoryService = new CategoryService();
            products = new ObservableCollection<Product>();
            dgData.ItemsSource = products;
        }

        public void LoadCategoryList()
        {
            try
            {
                var catList = iCatergoryService.GetCategories();
                cboCategory.ItemsSource = catList;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public void LoadProductList()
        {
            try
            {
                var prodList = iProductService.GetProducts();
                products.Clear();
                foreach (var product in prodList)
                {
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of products");
            }
            finally
            {
                ResetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    ProductName = txtProductName.Text,
                    UnitPrice = Int32.Parse(txtPrice.Text),
                    UnitsInStock = short.Parse(txtUnitsInStock.Text),
                    CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                };
                iProductService.SaveProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on create product");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            Product selectedProduct = dgData.SelectedItem as Product;
            if (selectedProduct != null)
            {
                txtProductID.Text = selectedProduct.ProductID.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtPrice.Text = selectedProduct.UnitPrice.ToString();
                txtUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
                cboCategory.SelectedValue = selectedProduct.CategoryId;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product
                    {
                        ProductID = Int32.Parse(txtProductID.Text),
                        ProductName = txtProductName.Text,
                        UnitPrice = Int32.Parse(txtPrice.Text),
                        UnitsInStock = short.Parse(txtUnitsInStock.Text),
                        CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                    };
                    iProductService.UpdateProduct(product);
                    LoadProductList();
                }
                else
                {
                    MessageBox.Show("Please select a product to update", "Error on update product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on update product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product
                    {
                        ProductID = Int32.Parse(txtProductID.Text),
                        ProductName = txtProductName.Text,
                        UnitPrice = Int32.Parse(txtPrice.Text),
                        UnitsInStock = short.Parse(txtUnitsInStock.Text),
                        CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                    };
                    iProductService.DeleteProduct(product);
                    LoadProductList();
                }
                else
                {
                    MessageBox.Show("Please select a product to delete", "Error on delete product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on delete product");
            }
        }

        private void ResetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }
    }
}