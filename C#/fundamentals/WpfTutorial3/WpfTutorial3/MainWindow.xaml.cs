using Microsoft.Win32;
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

namespace WpfTutorial3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Closes the app
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Opens the open file dialog
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
        }

        // Opens the save file dialog
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.ShowDialog();
        }

        // Unchecks other fonts and changes font for the text box
        private void MenuFontTimes_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontArial.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Times New Roman");
        }

        private void MenuFontCourier_Click(object sender, RoutedEventArgs e)
        {
            menuFontTimes.IsChecked = false;
            menuFontArial.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Courier");
        }

        private void MenuFontArial_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontTimes.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Arial");
        }

        // ---------- NEW STUFF ----------

        // Used to track if font size combobox is closed
        private bool comboFSClosed = true;

        // Verify combo is closed and call for font size change
        private void ComboFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboFSClosed) ChangeTBFontSize();
            comboFSClosed = true;
        }

        // Change font size of text box after combo is closed
        private void ComboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            comboFSClosed = !combobox.IsDropDownOpen;
            ChangeTBFontSize();
        }

        private void ChangeTBFontSize()
        {
            // Convert combo font size data to string
            string fontsize = comboFontSize.SelectedItem.ToString();

            // Get the last 2 numbers
            fontsize = fontsize.Substring(fontsize.Length - 2);

            switch (fontsize)
            {
                case "10":
                    txtBoxDoc.FontSize = 10;
                    break;
                case "12":
                    txtBoxDoc.FontSize = 12;
                    break;
                case "14":
                    txtBoxDoc.FontSize = 14;
                    break;
                case "16":
                    txtBoxDoc.FontSize = 16;
                    break;
            }
        }
    }
}
