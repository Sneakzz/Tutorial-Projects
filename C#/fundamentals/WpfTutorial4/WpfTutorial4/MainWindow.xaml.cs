using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTutorial4
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

        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get a reference to the calendar
            var calendar = sender as Calendar;

            // Check that it has a value
            if (calendar.SelectedDate.HasValue)
            {
                // Display the date
                DateTime date = calendar.SelectedDate.Value;
                try
                {
                    tbDateSelected.Text = date.ToShortDateString();
                }
                catch (NullReferenceException)
                {
                    // Needed for a bug that is triggered during initialization
                }
            }
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            // Get a reference to the radiobutton
            var radiobutton = sender as RadioButton;

            // Get the radiobutton pressed
            string radioBPressed = radiobutton.Content.ToString();

            // Change settings based on button pressed
            if (radioBPressed == "Draw")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }
            else if (radioBPressed == "Erase")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
            }
            else if (radioBPressed == "Select")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
            }
        }

        private void DrawPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if((int)e.Key >= 35 && (int)e.Key <= 68)
            {
                switch ((int)e.Key)
                {
                    case 35:
                        strokeAttr.Width = 2;
                        strokeAttr.Height = 2;
                        break;

                    case 36:
                        strokeAttr.Width = 4;
                        strokeAttr.Height = 4;
                        break;

                    case 37:
                        strokeAttr.Width = 6;
                        strokeAttr.Height = 6;
                        break;

                    case 38:
                        strokeAttr.Width = 8;
                        strokeAttr.Height = 8;
                        break;

                    case 45:
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Blue");
                        break;

                    case 50:
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Green");
                        break;

                    case 68:
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Yellow");
                        break;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("MyPicture.bin", FileMode.Create))
            {
                this.DrawingCanvas.Strokes.Save(fs);
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("MyPicture.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection sc = new StrokeCollection(fs);
                this.DrawingCanvas.Strokes = sc;
            }
        }
    }
}
