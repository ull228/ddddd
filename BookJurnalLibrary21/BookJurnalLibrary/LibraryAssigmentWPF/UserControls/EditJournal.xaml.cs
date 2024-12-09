using BookJurnalLibrary;
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

namespace LibraryAssigmentWPF.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EditJournal.xaml
    /// </summary>
    public partial class EditJournal : UserControl
    {
        public static string? Isbn { get; set; }
        public EditJournal()
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
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
            Grid EditJournalGrid = (Grid)mainWindow.FindName("EditJournalGrid");
            EditJournalGrid.Visibility = Visibility.Collapsed;
            Grid managerGrid = (Grid)mainWindow.FindName("managerGrid");
            managerGrid.Visibility = Visibility.Visible;

            isbnBox.txtInput.Text = string.Empty;
        }

        private void ProceedToNextMenu()
        {
            Window mainWindow = Window.GetWindow(this);
            Grid EditJournalGrid = (Grid)mainWindow.FindName("EditJournalGrid");
            EditJournalGrid.Visibility = Visibility.Visible;

            Grid EditJournalGrid2 = (Grid)mainWindow.FindName("EditJournalGrid2");
            EditJournalGrid2.Visibility = Visibility.Visible;

            EditJournal2 editJournal2Control = (EditJournal2)EditJournalGrid2.Children[0];
            editJournal2Control.ClearComboBox();
            editJournal2Control.FindJournal();
            editJournal2Control.PopulateComboBox();
        }

        private void isbnBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}