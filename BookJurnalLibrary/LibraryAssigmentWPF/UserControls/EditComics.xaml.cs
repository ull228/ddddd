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
using BookJurnalLibrary;

namespace LibraryAssigmentWPF.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EditBook.xaml
    /// </summary>
    public partial class EditComics : UserControl
    {
        public static string Isbn { get; set; }
        public EditComics()
        {
            InitializeComponent();
            btnEnter.ButtonContent = Resex.btnEnter;
            btnreturn.ButtonContent = Resex.btnReturn;
            btnEnter.ButtonClickEvent += btnInput_Click;
            btnreturn.ButtonClickEvent += btnInput_Click;
        }
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnEnter)
            {
                try
                {
                    DataBase.IsIsbnValid(isbnBox.txtInput.Text);
                    Isbn = isbnBox.txtInput.Text;
                    ProceedToNextMenu();
                }
                catch (IllegalIsbnException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERORR", MessageBoxButton.OK, MessageBoxImage.Error);
                    isbnBox.txtInput.Focus();
                }
            }
            else
            {
                ReturnToManagerMenu();
            }
        }
        private void ReturnToManagerMenu()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid EditComicsGrid = (Grid)mainWindow.FindName("EditComicsGrid");
            EditComicsGrid.Visibility = Visibility.Collapsed;

            Grid managerGrid = (Grid)mainWindow.FindName("managerGrid");
            managerGrid.Visibility = Visibility.Visible;

            isbnBox.txtInput.Text = string.Empty;
        }
        private void ProceedToNextMenu()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid EditComicsGrid = (Grid)mainWindow.FindName("EditComicsGrid");
            EditComicsGrid.Visibility = Visibility.Collapsed;

            Grid EditComicsGrid2 = (Grid)mainWindow.FindName("EditComicsGrid2");
            EditComicsGrid2.Visibility = Visibility.Visible;

            EditComics2 editComicsGrid2Control = (EditComics2)EditComicsGrid2.Children[0];
            editComicsGrid2Control.ClearComboBox();
            editComicsGrid2Control.FindBook();
            editComicsGrid2Control.PopulateComboBox();
        }
    }
}
