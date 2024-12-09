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
using Microsoft.Office.Interop.Word;
using System.IO;
using Range = Microsoft.Office.Interop.Word.Range;

namespace LibraryAssigmentWPF.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ManageExceptions.xaml
    /// </summary>
    public partial class ManageExceptions : UserControl
    {
        public ManageExceptions()
        {
            InitializeComponent();
            btnReturn.ButtonContent = Resex.btnReturn;
            btnWord.ButtonContent = Resex.btnWord;
            btnReturn.ButtonClickEvent += BtnReturn_ButtonClickEvent;
            btnWord.ButtonClickEvent += BtnWord_ButtonClickEvent;
            DisplayExceptions();
        }
        private void BtnWord_ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = true;
                Document doc = wordApp.Documents.Add();
                Range range = doc.Content;
                range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                range.InsertAfter(title.Text + "\n\n");
                List<string> items = DataBase.GetExceptions();
                foreach (string item in items)
                {
                    range.InsertAfter(item.ToString() + "\n\n");
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
            catch (DirectoryNotFoundException ex)
            {
                DataBase.LogException(ex);
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnReturn_ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            ReturnToMenu();
        }
        private void ReturnToMenu()
        {
            System.Windows.Window mainWindow = System.Windows.Window.GetWindow(this);
            Grid ManageExceptionsGrid = (Grid)mainWindow.FindName("ManageExceptionsGrid");
            ManageExceptionsGrid.Visibility = Visibility.Collapsed;
            Grid managerGrid = (Grid)mainWindow.FindName("managerGrid");
            managerGrid.Visibility = Visibility.Visible;
        }
        public void DisplayExceptions()
        {
            try
            {
                ListBox.ItemsSource = null;
                ListBox.ItemsSource = DataBase.GetExceptions();
            }
            catch (DirectoryNotFoundException ex)
            {
                DataBase.LogException(ex);
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

