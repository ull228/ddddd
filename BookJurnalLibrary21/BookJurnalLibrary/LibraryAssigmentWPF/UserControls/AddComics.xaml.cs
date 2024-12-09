using BookJurnalLibrary;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace LibraryAssigmentWPF.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddComics : UserControl
    {
        Comics comics = new Comics();
        public AddComics()
        {
            InitializeComponent();
            comboBox.ItemsSource = Enum.GetValues(typeof(genre));
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            ReturnToManagerMenu();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AssignComicsProperties();
                IsComboBoxNull();
                comics.IsFormValid();
                comics.IsIsbnValid(isbnx.txtInput.Text);
                comics.IsPriceDouble(pricex.txtInput.Text);
                comics.IsQuantityInt(quantityx.txtInput.Text);
                Comics actualComics = new Comics(isbnx.txtInput.Text, namex.txtInput.Text, editionx.txtInput.Text, comics.Quantity, summaryx.txtInput.Text, comics.Genre, comics.Price);
                DataBase.AddItem(actualComics);
                DataBase.SaveItemInformation(actualComics);
                MessageBox.Show($"{actualComics.Name} has been successfully crated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearAllTextBoxes();
                ReturnToManagerMenu();
            }
            catch (ArgumentNullException ex)
            {
                ErrorMessage(ex);
            }
            catch (FormatException ex)
            {
                ErrorMessage(ex);
            }
            catch (ItemAlreadyExistsException ex)
            {
                ErrorMessage(ex);
            }
            catch (IllegalIsbnException ex)
            {
                ErrorMessage(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                ErrorMessage(ex);
                DataBase.RemoveItem(isbnx.txtInput.Text);
            }
        }
        private void ErrorMessage(Exception ex)
        {
            DataBase.LogException(ex);
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void ClearAllTextBoxes()
        {
            isbnx.txtInput.Clear();
            namex.txtInput.Clear();
            editionx.txtInput.Clear();
            quantityx.txtInput.Clear();
            summaryx.txtInput.Clear();
            pricex.txtInput.Clear();
            comboBox.SelectedItem = null;
            comboBox.Text = "Genre";
            comboBox.Foreground = Brushes.DarkGray;
        }

        private void ReturnToManagerMenu()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid AddComicsGrid = (Grid)mainWindow.FindName("AddComicsGrid");
            AddComicsGrid.Visibility = Visibility.Collapsed;
            Grid managerGrid = (Grid)mainWindow.FindName("managerGrid");
            managerGrid.Visibility = Visibility.Visible;
            ClearAllTextBoxes();
        }

        private void AssignComicsProperties()
        {
            comics.Isbn = isbnx.txtInput.Text;
            comics.Name = namex.txtInput.Text;
            comics.Edition = editionx.txtInput.Text;
            comics.Summary = summaryx.txtInput.Text;
            comics.DateOfPrint = DateTime.Now;
        }

        private void IsComboBoxNull()
        {
            if (comboBox.SelectedItem == null)
            {
                throw new ArgumentNullException("Please select a genre!");
            }
            else comics.Genre = (genre)comboBox.SelectedItem;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox.Foreground = Brushes.Black;
        }

        private void comboBox_DropDownChanged(object sender, EventArgs e)
        {
            comboBox.Foreground = Brushes.Black;
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
    }
}