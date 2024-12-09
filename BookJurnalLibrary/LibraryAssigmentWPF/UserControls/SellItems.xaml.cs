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
using System.IO;
using BookJurnalLibrary;

namespace LibraryAssigmentWPF.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SellItems.xaml
    /// </summary>
    public partial class SellItems : UserControl
    {
        List<AbstractItem> itemCart = new List<AbstractItem>();
        List<string> itemsToDisplay = new List<string>();
        bool HasActivatedDiscount;
        public SellItems()
        {
            InitializeComponent();
            AssignButtonNames();
            AssignButtonEvents();
            DisplayItems();
        }
        private void BtnDiscount_ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            if (HasActivatedDiscount)
            {
                e.Handled = true;
            }
            else
            {
                try
                {
                    HasActivatedDiscount = true;
                    clubDiscount.txtInput.IsReadOnly = true;
                    double totalPrice = GetCartTotalPrice();
                    totalPrice = 0.9;
                    title.Text = $"You need to pay {totalPrice:C}";
                    clubDiscount.tbText.Text = "Club Discount Activated";
                    MessageBox.Show($"10% Club Discount activated! \nCustomer's ID: {clubDiscount.txtInput.Text}",
                        "Discount Activated", MessageBoxButton.OK, MessageBoxImage.Information);
                    clubDiscount.txtInput.Text = string.Empty;
                }
                catch (IllegalIdException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    clubDiscount.txtInput.Focus();
                }
            }
        }

        public void DisplayItems()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = DataBase.GetItems();
        }
        private void BtnRemove_ButtonClickEvent(object sender, RoutedEventArgs e)
        {

            if (listBox.SelectedItem != null)
            {
                string isbn = itemsToDisplay[listBox.SelectedIndex].Substring(6, 6);
                AbstractItem item = DataBase.FindItem(isbn);
                item.Quantity++;
                itemCart.Remove(item);
                itemsToDisplay.Remove(itemsToDisplay[listBox.SelectedIndex]);
                listBox.ItemsSource = null;
                listBox.ItemsSource = itemsToDisplay;
                double totalPrice = GetCartTotalPrice();
                if (HasActivatedDiscount) totalPrice *= 0.9;
                title.Text = $"Your cart (total price ({totalPrice:C})):";
                MessageBox.Show($"{item.Name} has been removed from the cart", "Item Removed", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select an item before clicking on remove!", "ERROR", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnAdd)
            {
                if (listBox.SelectedItem != null)
                {
                    try
                    {
                        AbstractItem item = DataBase.GetItemByIndex(listBox.SelectedIndex);
                        item.SubstractItemFromLibrary();
                        itemCart.Add(item);
                        string itemToDisplay = item.PartialToString();
                        itemsToDisplay.Add(itemToDisplay);
                        listBox.ItemsSource = null;
                        listBox.ItemsSource = DataBase.GetItems();
                        MessageBox.Show($"{item.Name} has been added to the cart", "Item Added", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    catch (ItemOutOfStockExceptions ex)
                    {
                        DataBase.LogException(ex);
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item before clicking on add!", "ERROR", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else if (sender == btnCart)
            {
                if (itemCart.Count == 0)
                {
                    MessageBox.Show("The cart is empty!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    ProceedToCartMenu();
                }
            }
            else
            {
                ReStockItems();
                ReturnToworkerMenuFromStart();
            }
        }
        private void Button_ClickCheckOut(object sender, RoutedEventArgs e)
        {
            double totalPrice = GetCartTotalPrice();
            MessageBoxResult result = MessageBox.Show("Are you sure you want to checkout?", "Checkout",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (totalPrice != 0) ProceedToCheckoutMenu();
                else MessageBox.Show("The cart is empty!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_ClickPay(object sender, RoutedEventArgs e)
        {
            double totalPrice = GetCartTotalPrice();
            if (HasActivatedDiscount) totalPrice *= 0.9;
            float totalPriceFloat = (float)totalPrice;
            if (amountToPay.txtInput.Text == totalPriceFloat.ToString())
            {
                try
                {
                    if (HasActivatedDiscount) DataBase.SaveReceipt(itemCart, totalPrice, true);
                    else DataBase.SaveReceipt(itemCart, totalPrice);

                    SaveItemInformation();
                    MessageBox.Show("Thank you for your purchase! \nThe receipt has been saved in the Data Base and can be accessed by the manager.",
                        "Purchase", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReturnToWorkerMenu();
                }
                catch (DirectoryNotFoundException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please pay the specified amount!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                amountToPay.txtInput.Focus();
            }
        }
        private void Button_ClickReturnCheckout(object sender, RoutedEventArgs e)
        {
            ReturnToSecondMenu();
        }
        private void Button_ClickReturnCart(object sender, RoutedEventArgs e)
        {
            ReturnToFirstMenu();
        }
        private void ReturnToWorkerMenu()
        {
            ReturnToworkerMenuFromStart();
            gridCheckout.Visibility = Visibility.Collapsed;
            amountToPay.txtInput.Clear();

            blueViewbox.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Visible;
            btnReturn.Visibility = Visibility.Visible;
            btnCart.Visibility = Visibility.Visible;
            title.Text = "Items available for sale:";

            itemCart.Clear();
            itemsToDisplay.Clear();
            DisplayItems();
        }
        private void ReturnToworkerMenuFromStart()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid workerGrid = (Grid)mainWindow.FindName("workerGrid");
            workerGrid.Visibility = Visibility.Visible;
            Grid SellItemsGrid = (Grid)mainWindow.FindName("SellItemsGrid");
            SellItemsGrid.Visibility = Visibility.Collapsed;
            RevertDiscountOptions();
        }
        private void RevertDiscountOptions()
        {
            HasActivatedDiscount = false;
            clubDiscount.txtInput.IsReadOnly = false;
            clubDiscount.tbText.Text = "ID for club discount";
        }
        private void ReStockItems()
        {
            foreach (var item in itemCart)
            {
                item.Quantity++;
            }
            listBox.ItemsSource = DataBase.GetItems();
            itemCart.Clear();
            itemsToDisplay.Clear();
        }
        private void ProceedToCartMenu()
        {
            btnAdd.Visibility = Visibility.Collapsed;
            btnReturn.Visibility = Visibility.Collapsed;
            btnCart.Visibility = Visibility.Collapsed;

            double totalPrice = GetCartTotalPrice();
            if (HasActivatedDiscount) totalPrice *= 0.9;
            title.Text = $"Your cart (total price {totalPrice:C}):";
            btnReturnCart.Visibility = Visibility.Visible;
            btnCheckout.Visibility = Visibility.Visible;
            btnRemove.Visibility = Visibility.Visible;

            listBox.ItemsSource = itemsToDisplay;
        }
        private void ReturnToFirstMenu()
        {
            btnReturnCart.Visibility = Visibility.Collapsed;
            btnCheckout.Visibility = Visibility.Collapsed;
            btnRemove.Visibility = Visibility.Collapsed;

            btnAdd.Visibility = Visibility.Visible;
            btnReturn.Visibility = Visibility.Visible;
            btnCart.Visibility = Visibility.Visible;

            DisplayItems();
            title.Text = "Items available for sale:";
        }
        private void ReturnToSecondMenu()
        {
            gridCheckout.Visibility = Visibility.Collapsed;

            btnReturnCart.Visibility = Visibility.Visible;
            btnCheckout.Visibility = Visibility.Visible;
            btnRemove.Visibility = Visibility.Visible;
            blueViewbox.Visibility = Visibility.Visible;

            double totalPrice = GetCartTotalPrice();
            if (HasActivatedDiscount) totalPrice *= 0.9;
            title.Text = $"Your cart (total price {totalPrice:C}):";
        }
        private void ProceedToCheckoutMenu()
        {
            btnReturnCart.Visibility = Visibility.Collapsed;
            btnCheckout.Visibility = Visibility.Collapsed;
            btnRemove.Visibility = Visibility.Collapsed;
            blueViewbox.Visibility = Visibility.Collapsed;

            gridCheckout.Visibility = Visibility.Visible;

            double totalPrice = GetCartTotalPrice();
            if (HasActivatedDiscount) totalPrice *= 0.9;
            title.Text = $"You need to pay {totalPrice:C}";
        }
        private void SaveItemInformation()
        {
            foreach (var item in itemCart)
            {
                DataBase.SaveItemInformation(item);
            }
        }
        private double GetCartTotalPrice()
        {
            double totalPrice = 0;
            foreach (var item in itemCart)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
        private void AssignButtonNames()
        {
            btnAdd.ButtonContent = Resex.btnAddCart;
            btnCart.ButtonContent = Resex.btnCart;
            btnReturn.ButtonContent = Resex.btnReturn;
            btnReturnCart.ButtonContent = Resex.btnReturn;
            btnCheckout.ButtonContent = Resex.btnCheckOut;
            btnPay.ButtonContent = Resex.btnPay;
            btnReturnCheckout.ButtonContent = Resex.btnReturn;
            btnRemove.ButtonContent = Resex.btnRemoveCart;
            btnDiscount.ButtonContent = Resex.btnClubDiscount;
        }
        private void AssignButtonEvents() 
        {
            btnAdd.ButtonClickEvent += Button_Click;
            btnCart.ButtonClickEvent += Button_Click;
            btnReturn.ButtonClickEvent += Button_Click;
            btnReturnCart.ButtonClickEvent += Button_ClickReturnCart;
            btnCheckout.ButtonClickEvent += Button_ClickCheckOut;
            btnPay.ButtonClickEvent += Button_ClickPay;
            btnReturnCheckout.ButtonClickEvent += Button_ClickReturnCheckout;
            btnRemove.ButtonClickEvent += BtnRemove_ButtonClickEvent;
            btnDiscount.ButtonClickEvent += BtnDiscount_ButtonClickEvent;
        }
    }
}