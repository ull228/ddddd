using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using BookJurnalLibrary;
using System.Windows.Media;

namespace LibraryAssigmentWPF.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EditBook2.xaml
    /// </summary>
    public partial class EditComics2 : UserControl
    {
        Comics comics = new Comics();
        public EditComics2()
        {
            InitializeComponent();
            btnEnter.ButtonContent = Resex.btnEnter;
            btnReturn.ButtonContent = Resex.btnReturn;

            btnEnter.ButtonClickEvent += btnInput_Click;
            btnReturn.ButtonClickEvent += btnInput_Click;
        }
        public void PopulateComboBox()
        {
            if (comboBox.Items.Count == 0)
            {
                comboBox.Items.Add($"ISBN ({comics.Isbn})");
                comboBox.Items.Add($"Name ({comics.Name})");
                comboBox.Items.Add($"Edition ({comics.Edition})");
                comboBox.Items.Add($"Quantity ({comics.Quantity})");
                comboBox.Items.Add($"Price ({comics.Price})");
                comboBox.Items.Add($"Summary ({comics.Summary})");
                comboBox.Items.Add($"Genre ({comics.Genre})");
            }
        }
        public void ClearComboBox()
        {
            comboBox.Items.Clear();
        }
        public void FindBook()
        {
            try
            {
                comics = new Comics();
                comics = (Comics)DataBase.FindItem(EditComics.Isbn);
            }
            catch (InvalidCastException ex)
            {
                DataBase.LogException(ex);
                ReturnToFirstMenu();
                MessageBox.Show("The ISBN you entered belongs to a journal!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnEnter)
            {
                if (comboBox.SelectedItem != null)
                {
                    ProceedToChangeProperty();
                }
                else
                {
                    MessageBox.Show("Please choose an option!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ReturnToFirstMenu();
            }
        }

        private void btnEnter2_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                EditIsbn();
            }
            else if (comboBox.SelectedIndex == 1)
            {
                EditName();
            }
            else if (comboBox.SelectedIndex == 2)
            {
                EditEdition();
            }
            else if (comboBox.SelectedIndex == 3)
            {
                EditQuantity();
            }
            else if (comboBox.SelectedIndex == 4)
            {
                EditPrice();
            }
            else if (comboBox.SelectedIndex == 5)
            {
                EditSummary();
            }
            else
            {
                EditGenre();
            }
        }
        private void btnReturn2_Click(object sender, RoutedEventArgs e)
        {
            ReturnToOptionSelectionMenu();
        }

        private void ProceedToChangeProperty()
        {
            if (comboBox.SelectedIndex == 6)
            {
                btnEnter.Visibility = Visibility.Collapsed;
                btnReturn.Visibility = Visibility.Collapsed;
                viewBoxCombo.Visibility = Visibility.Collapsed;

                viewBoxEnter2.Visibility = Visibility.Visible;
                viewBoxReturn2.Visibility = Visibility.Visible;
                viewBoxComboGenre.Visibility = Visibility.Visible;
                comboBoxGenre.ItemsSource = Enum.GetValues(typeof(genre));
                title.Text = $"Please choose a new Genre:";
            }
            else
            {
                btnEnter.Visibility = Visibility.Collapsed;
                btnReturn.Visibility = Visibility.Collapsed;
                viewBoxCombo.Visibility = Visibility.Collapsed;

                viewBoxEnter2.Visibility = Visibility.Visible;
                viewBoxReturn2.Visibility = Visibility.Visible;
                viewBoxTextBox.Visibility = Visibility.Visible;
                string boundText = "";

                for (int i = 0; i < comboBox.SelectedItem.ToString()!.Length; i++)
                {
                    if (Char.IsLetter(comboBox.SelectedItem.ToString()![i])) boundText += comboBox.SelectedItem.ToString()![i];
                    else break;
                }
                editTextBox.BoundText = $"Enter new {boundText}";
                title.Text = $"Please choose a new {boundText}";
            }
        }
        private void ReturnToOptionSelectionMenu()
        {
            if (comboBox.SelectedIndex == 6)
            {
                HideGenreComboBox();
            }

            btnEnter.Visibility = Visibility.Visible;
            btnReturn.Visibility = Visibility.Visible;

            viewBoxCombo.Visibility = Visibility.Visible;
            viewBoxEnter2.Visibility = Visibility.Collapsed;
            viewBoxReturn2.Visibility = Visibility.Collapsed;
            viewBoxTextBox.Visibility = Visibility.Collapsed;

            editTextBox.txtInput.Text = string.Empty;
            comboBox.SelectedItem = null;
            comboBox.Text = "Option";
            title.Text = "Please choose the option you would like to edit:";
        }

        private void HideGenreComboBox()
        {
            viewBoxCombo.Visibility = Visibility.Collapsed;
            comboBox.SelectedItem = null;
            comboBox.Text = "Genre";
        }

        private void ReturnToManagerMenu()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid editBookGrid2 = (Grid)mainWindow.FindName("editBookGrid2");
            editBookGrid2.Visibility = Visibility.Collapsed;
            Grid managerGrid = (Grid)mainWindow.FindName("managerGrid");
            managerGrid.Visibility = Visibility.Visible;
        }
        private void ReturnToFirstMenu()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid editBookGrid2 = (Grid)mainWindow.FindName("editBookGrid2");
            editBookGrid2.Visibility = Visibility.Collapsed;
            Grid editBookGrid = (Grid)mainWindow.FindName("editBookGrid");
            editBookGrid.Visibility = Visibility.Visible;
            comboBox.SelectedValue = null;
            comboBox.Text = "Option";
            comboBox.Foreground = Brushes.DarkGray;
        }

        private void EditIsbn() //метод редактирования номера книги
        {
            string oldIsbn = comics.Isbn;
            try
            {
                comics.IsIsbnValid(editTextBox.txtInput.Text);
                DataBase.IsIsbnAvailable(editTextBox.txtInput.Text);
                comics.Isbn = editTextBox.txtInput.Text;
                DataBase.SaveItemInformation(comics);
                MessageBox.Show("The ISBN of the book has been successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ReturnToOptionSelectionMenu();
                ReturnToManagerMenu();
            }
            catch (IllegalIsbnException ex)
            {
                ErorrMessage(ex);
                editTextBox.txtInput.Focus();
            }
            catch (DirectoryNotFoundException ex)
            {
                ErorrMessage(ex);
                comics.Isbn = oldIsbn;
                editTextBox.txtInput.Focus();
            }
        }

        private void ErorrMessage(Exception ex)
        {
            DataBase.LogException(ex);
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void EditName()
        {
            if (string.IsNullOrWhiteSpace(editTextBox.txtInput.Text))
            {
                MessageBox.Show("Field is empty!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                editTextBox.txtInput.Focus();
            }
            else
            {
                string oldName = comics.Name;
                try
                {
                    comics.Name = editTextBox.txtInput.Text;
                    DataBase.SaveItemInformation(comics);
                    MessageBox.Show("The Name of the book has been successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReturnToOptionSelectionMenu();
                    ReturnToManagerMenu();
                }
                catch (DirectoryNotFoundException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    comics.Name = oldName;
                    editTextBox.txtInput.Focus();
                }
            }
        }
        private void EditEdition()
        {
            if (string.IsNullOrWhiteSpace(editTextBox.txtInput.Text))
            {
                MessageBox.Show("Field is empty!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                editTextBox.txtInput.Focus();
            }
            else
            {
                string oldEdition = comics.Edition;
                try
                {
                    comics.Edition = editTextBox.txtInput.Text;
                    DataBase.SaveItemInformation(comics);
                    MessageBox.Show("The Edition of the book has been successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReturnToOptionSelectionMenu();
                    ReturnToManagerMenu();
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    comics.Edition = oldEdition;
                    editTextBox.txtInput.Focus();
                }
            }
        }

        private void EditQuantity()
        {
            int oldQuantity = comics.Quantity;
            try
            {
                comics.IsQuantityInt(editTextBox.txtInput.Text);
                DataBase.SaveItemInformation(comics);
                MessageBox.Show("The Quantity of the book has been successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ReturnToOptionSelectionMenu();
                ReturnToManagerMenu();
            }
            catch (FormatException ex)
            {
                DataBase.LogException(ex);
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                editTextBox.txtInput.Focus();
            }
            catch (DirectoryNotFoundException ex)
            {
                DataBase.LogException(ex);
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                comics.Quantity = oldQuantity;
                editTextBox.txtInput.Focus();
            }
        }
        private void EditPrice() //метод редактирования цены книги
        {
            double oldPrice = comics.Price;
            try
            {
                comics.IsPriceDouble(editTextBox.txtInput.Text);
                DataBase.SaveItemInformation(comics);
                MessageBox.Show("The Price of the book has been successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ReturnToOptionSelectionMenu();
                ReturnToManagerMenu();
            }
            catch (FormatException ex)
            {
                DataBase.LogException(ex);
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                editTextBox.txtInput.Focus();
            }
            catch (DirectoryNotFoundException ex)
            {
                DataBase.LogException(ex);
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                comics.Price = oldPrice;
                editTextBox.txtInput.Focus();
            }
        }

        private void EditSummary()
        {
            if (string.IsNullOrWhiteSpace(editTextBox.txtInput.Text))
            {
                MessageBox.Show("Field is empty!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                editTextBox.txtInput.Focus();
            }
            else
            {
                string oldSummary = comics.Summary;
                try
                {
                    comics.Summary = editTextBox.txtInput.Text;
                    DataBase.SaveItemInformation(comics);
                    MessageBox.Show("The Summary of the book has been successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReturnToOptionSelectionMenu();
                    ReturnToManagerMenu();
                }
                catch (DirectoryNotFoundException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    comics.Summary = oldSummary;
                    editTextBox.txtInput.Focus();
                }
            }
        }
        private void EditGenre()
        {
            if (comboBoxGenre.SelectedItem != null)
            {
                genre oldGenre = comics.Genre;
                try
                {
                    comics.Genre = (genre)comboBoxGenre.SelectedItem;
                    DataBase.SaveItemInformation(comics);
                    MessageBox.Show("The Genre of the book has been successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReturnToOptionSelectionMenu();
                    ReturnToManagerMenu();
                }
                catch (DirectoryNotFoundException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    comics.Genre = oldGenre;
                    editTextBox.txtInput.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please pick a genre!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBox_DropDownOpened(object sender, EventArgs e)
        {
            comboBox.Foreground = Brushes.Black;
        }

        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {

            if (comboBox.SelectedItem != null) comboBox.Foreground = Brushes.Black;
            else comboBox.Foreground = Brushes.DarkGray;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox.Foreground = Brushes.Black;
        }

        private void comboBoxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxGenre.Foreground = Brushes.Black;
        }

        private void comboBoxGenre_DropDownOpened(object sender, EventArgs e)
        {
            comboBoxGenre.Foreground = Brushes.Black;
        }
        private void comboBoxGenre_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxGenre.SelectedItem != null) comboBoxGenre.Foreground = Brushes.Black;
            else comboBoxGenre.Foreground = Brushes.DarkGray;
        }
    }
}