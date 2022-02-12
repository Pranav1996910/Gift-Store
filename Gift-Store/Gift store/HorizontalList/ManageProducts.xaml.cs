using ComboBoxWPF;
using HorizontalList.Resources;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for ManageProducts.xaml
    /// </summary>
    public partial class ManageProducts : Window
    {
        public bool firstTime = true;
        public string newProductFileName;
        public string giftFor = "";
        public string ocassion = "";
        public string sortBy = "Price -> Low";
        public double totalAmount;
        public int lastEditedProductID;
        public ObservableCollection<Product> showingProducts;
        public List<AddedProduct> addedProducts = new List<AddedProduct>();
        public ManageProducts()
        {
            InitializeComponent(); 
            var lang = Settings.Default.language;
            CultureInfo.CurrentUICulture = new CultureInfo(lang);
            CultureInfo.CurrentCulture = new CultureInfo(lang);
            DataContext = new ComboBoxViewModel();
            showingProducts = App._Products;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewProducts.ItemsSource = showingProducts; 
            CBx_language.ItemsSource = Resource.languageselection.Split(',');
            if (Settings.Default.language == "en")
            {
                CBx_language.SelectedIndex = 0;
            }
            else
            {
                CBx_language.SelectedIndex = 1;
            }
        }
        public void giftForSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {


            if (e.AddedItems.Contains("Him"))
            {
                giftFor = "Him";
                DataContext = new ComboBoxViewModel("Him");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Her"))
            {
                giftFor = "Her";
                DataContext = new ComboBoxViewModel("Her");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Teen -> boy"))
            {
                giftFor = "Teen -> boy";
                DataContext = new ComboBoxViewModel("Teen -> boy");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Teen -> girl"))
            {
                giftFor = "Teen -> girl";
                DataContext = new ComboBoxViewModel("Teen -> girl");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Kids -> boy"))
            {
                giftFor = "Kids -> boy";
                DataContext = new ComboBoxViewModel("Kids -> boy");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Kids -> girl"))
            {
                giftFor = "Kids -> girl";
                DataContext = new ComboBoxViewModel("Kids -> girl");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Baby -> boy"))
            {
                giftFor = "Baby -> boy";
                DataContext = new ComboBoxViewModel("Baby -> boy");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Baby -> girl"))
            {
                giftFor = "Baby -> girl";
                DataContext = new ComboBoxViewModel("Baby -> girl");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else
            {
                giftFor = "Show All";
                DataContext = new ComboBoxViewModel("Show All");
                CBx_OcassionCategory.IsEnabled = false;
            }
            ocassion = "";
            ocassion = "";
            sortShowingItems();
        }
        public void sortShowingItems()
        {
            if (giftFor != "" && ocassion != "" && giftFor != "Show All" && ocassion != "Show All")
            {
                showingProducts = new ObservableCollection<Product>(App._Products.Where(x => x.GiftFor == giftFor && x.Ocassion == ocassion));
            }
            else if (ocassion != "" && ocassion != "Show All")
            {
                showingProducts = new ObservableCollection<Product>(App._Products.Where(x => x.Ocassion == ocassion));
            }
            else if (giftFor != "" && giftFor != "Show All" || giftFor != "" && ocassion == "Show All" && giftFor != "Show All")
            {
                showingProducts = new ObservableCollection<Product>(App._Products.Where(x => x.GiftFor == giftFor));
            }
            else
            {
                showingProducts = App._Products;
            }
            if (sortBy.Contains("Price -> Low"))
            {
                showingProducts = new ObservableCollection<Product>(showingProducts.OrderBy(x => x.Value));
            }
            else
            {
                showingProducts = new ObservableCollection<Product>(showingProducts.OrderByDescending(x => x.Value));
            }
            ListViewProducts.ItemsSource = showingProducts;
        }
        public void giftSearch(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ocassion = e.AddedItems[0].ToString();
                sortShowingItems();
            }
        }
        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            int maxID = 0;
            if (App._Products.Count() > 0)
            {
                maxID = App._Products.Max(x => x.ID);
            }
            Product newProduct = new Product { ID = maxID + 1, Name = AddProductName.Text, Value = double.Parse(AddProductPrice.Text), ItemsLeft = int.Parse(AddProductTotalItems.Text), Description = AddProductDescription.Text, ImagePath = newProductFileName, GiftFor = giftForcomboAdd.Text, Ocassion = ocassionAdd.Text };
            App._Products.Add(newProduct);
        }
        private void AddImage(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG|*.jpg|PNG|.png";
            ofd.ValidateNames = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == true)
            {
                newProductFileName = "/Assets/" + ofd.SafeFileName;
            }
        }
        private void giftSearchForAdd(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Contains("Him"))
            {
                giftFor = "Him";
                DataContext = new ComboBoxViewModel("Him");
            }
            else if (e.AddedItems.Contains("Her"))
            {
                giftFor = "Her";
                DataContext = new ComboBoxViewModel("Her");
            }
            else if (e.AddedItems.Contains("Teen -> boy"))
            {
                giftFor = "Teen -> boy";
                DataContext = new ComboBoxViewModel("Teen -> boy");
            }
            else if (e.AddedItems.Contains("Teen -> girl"))
            {
                giftFor = "Teen -> girl";
                DataContext = new ComboBoxViewModel("Teen -> girl");
            }
            else if (e.AddedItems.Contains("Kids -> boy"))
            {
                giftFor = "Kids -> boy";
                DataContext = new ComboBoxViewModel("Kids -> boy");
            }
            else if (e.AddedItems.Contains("Kids -> girl"))
            {
                giftFor = "Kids -> girl";
                DataContext = new ComboBoxViewModel("Kids -> girl");
            }
            else if (e.AddedItems.Contains("Baby -> boy"))
            {
                giftFor = "Baby -> boy";
                DataContext = new ComboBoxViewModel("Baby -> boy");
            }
            else
            {
                giftFor = "Baby -> girl";
                DataContext = new ComboBoxViewModel("Baby -> girl");
            }
        }

        private void EditProductDetails(object sender, RoutedEventArgs e)
        {
            lastEditedProductID = (int)((System.Windows.FrameworkElement)sender).Tag;
            Product editProduct = App._Products.First(x => x.ID == (int)((System.Windows.FrameworkElement)sender).Tag);
            giftForcomboEdit.SelectedItem = editProduct.GiftFor;
            ocassionEdit.SelectedItem = editProduct.Ocassion;
            EditProductName.Text = editProduct.Name;
            newProductFileName = editProduct.ImagePath;
            EditProductPrice.Text = editProduct.Value.ToString();
            EditProductDescription.Text = editProduct.Description;
            EditProductTotalItems.Text = editProduct.ItemsLeft.ToString();
            EditTab.IsSelected = true;
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            App._Products.First(x => x.ID == lastEditedProductID).GiftFor = giftForcomboEdit.Text;
            App._Products.First(x => x.ID == lastEditedProductID).Ocassion = ocassionEdit.Text;
            App._Products.First(x => x.ID == lastEditedProductID).Name = EditProductName.Text;
            App._Products.First(x => x.ID == lastEditedProductID).Value = double.Parse(EditProductPrice.Text);
            App._Products.First(x => x.ID == lastEditedProductID).Description = EditProductDescription.Text;
            App._Products.First(x => x.ID == lastEditedProductID).ItemsLeft = int.Parse(EditProductTotalItems.Text);
            App._Products.First(x => x.ID == lastEditedProductID).ImagePath = newProductFileName;
            addedProducts = new List<AddedProduct>();
            ListViewProducts.ItemsSource = showingProducts;
        }

        private void SortByPrice(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                sortBy = e.AddedItems[0].ToString();
                if (e.AddedItems[0].ToString().Contains("Price -> Low"))
                {
                    showingProducts = new ObservableCollection<Product>(showingProducts.OrderBy(x => x.Value));
                }
                else
                {
                    showingProducts = new ObservableCollection<Product>(showingProducts.OrderByDescending(x => x.Value));
                }
            }
            ListViewProducts.ItemsSource = showingProducts;
        }


        private void TBx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = TBx_filter.Text.ToLower();
            if (filter == "")
                ListViewProducts.ItemsSource = showingProducts;
            else
            {
                var lst = (from b in showingProducts where b.Name.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) select b).ToList();
                var lst2 = (from m in showingProducts where m.Name.ToLower().Contains(filter) select m).ToList();
                lst.AddRange(lst2);
                ListViewProducts.ItemsSource = lst.Distinct();



            }
        }


        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Collapsed; 
            var windows = Application.Current.Windows;
            foreach (var item in windows)
            {
                if ((item as Window).Title.ToLower() == "mainwindow") continue;
                (item as Window).Close();
            }
        }

        private void Btn_Navigation_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            win.Owner = this;
            Visibility = Visibility.Collapsed;
            win.Width = Width;
            win.Height = Height;
            win.Show();
        }

        private void CBx_language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstTime)
            {
                firstTime = false;
                return;
            }
            switch (CBx_language.SelectedIndex)
            {
                case 0:
                    Settings.Default.language = "en";
                    break;
                case 1:
                    Settings.Default.language = "de";
                    break;
            }
            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

    }
}
