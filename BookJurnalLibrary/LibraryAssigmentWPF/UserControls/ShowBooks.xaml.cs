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
    /// Логика взаимодействия для ShowBooks.xaml
    /// </summary>
    public partial class ShowBooks : UserControl
    {
        public ShowBooks()
        {
            InitializeComponent();
            btnReturn.ButtonContent = Resex.btnReturn;
            btnWord.ButtonContent = Resex.btnWord;
            btnFind.ButtonContent = Resex.btnFind;
            btnRevert.ButtonContent = Resex.btnShowBooks;
            btnReturn.ButtonClickEvent += BtnReturn_ButtonClickEvent;
            btnWord.ButtonClickEvent += BtnWord_ButtonClickEvent;
            btnFind.ButtonClickEvent += BtnFind_ButtonClickEvent;
            btnRevert.ButtonClickEvent += BtnRevert_ButtonClickEvent;
            DisplayBooks();
        }
        private void BtnFind_ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            if (textBox.txtInput.Text == string.Empty)
            {
                MessageBox.Show("Please enter a name in the text box in order to sort the list!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    var bookList = DataBase.FilterItemsByName(textBox.txtInput.Text);
                    var itemsList = bookList;
                    for (int i = 0; i < itemsList.Count; i++)
                    {
                        if (itemsList[i].GetType() == typeof(Journal)) bookList.Remove(itemsList[i]);
                    }
                    if (bookList.Count == 0)
                    {
                        MessageBox.Show("The name you entered does not relate to any of the books in the library!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    listBox.ItemsSource = null;
                    listBox.ItemsSource = bookList;
                }
                catch (System.ArgumentException ex)
                {
                    DataBase.LogException(ex);
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void BtnRevert_ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            DisplayBooks();
        }
        public void DisplayBooks()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = DataBase.GetBooks();
        }
        private void BtnReturn_ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            System.Windows.Window mainWindow = System.Windows.Window.GetWindow(this);
            Grid managerGrid = (Grid)mainWindow.FindName("managerGrid");
            managerGrid.Visibility = Visibility.Visible;
            Grid ShowBooksGrid = (Grid)mainWindow.FindName("ShowBooksGrid");
            ShowBooksGrid.Visibility = Visibility.Collapsed;
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
                List<AbstractItem> books = DataBase.GetBooks();
                foreach (AbstractItem item in books)
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
    }
}