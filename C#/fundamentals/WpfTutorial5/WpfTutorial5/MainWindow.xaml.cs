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

namespace WpfTutorial5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GenerateDoc();
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
            if ((int)e.Key >= 35 && (int)e.Key <= 68)
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

        private void GenerateDoc()
        {
            FlowDocument doc = new FlowDocument();

            Paragraph para = new Paragraph(new Run("Lorem ipsum dolor sit amet," +
                "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et" +
                "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco" +
                "laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in" +
                "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt" +
                "mollit anim id est laborum."));

            doc.Blocks.Add(para);

            para = new Paragraph(new Run("Lorem ipsum dolor sit amet," +
                "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et" +
                "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco" +
                "laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in" +
                "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt" +
                "mollit anim id est laborum."))
            {
                FontSize = 14,
                FontStyle = FontStyles.Italic,
                Foreground = Brushes.Green
            };

            doc.Blocks.Add(para);
            fdScrollViewer.Document = doc;
        }

        // A ContextMenu displays Cut, Copy and Paste commands
        private void RichTB_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            // Convert to a RichTextBox and check for null
            RichTextBox rtb = sender as RichTextBox;
            if (rtb == null) return;

            // Create ContextMenu
            ContextMenu contextMenu = rtb.ContextMenu;
            contextMenu.PlacementTarget = rtb;

            // This will place the menu at the point where it is right clicked
            contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.RelativePoint;

            TextPointer position = rtb.Selection.End;

            if (position == null) return;

            // Create the menu
            Rect positionRect = position.GetCharacterRect(LogicalDirection.Forward);
            contextMenu.HorizontalOffset = positionRect.X;
            contextMenu.VerticalOffset = positionRect.Y;

            // Finally, mark the event as handled
            contextMenu.IsOpen = true;
            e.Handled = true;
        }

        private void SaveRTBContent(object sender, RoutedEventArgs e)
        {
            // Defines the range of text to save
            TextRange range = new TextRange(RichTB.Document.ContentStart, RichTB.Document.ContentEnd);

            // Create a stream to write to the file
            FileStream fStream = new FileStream("c:\\Users\\Kenny\\C#Data\\test.xaml", FileMode.Create);

            // Save the content
            range.Save(fStream, DataFormats.XamlPackage);
            fStream.Close();
        }

        // Load text into RichTextBox
        private void OpenRTBContent(object sender, RoutedEventArgs e)
        {
            TextRange range;
            FileStream fStream;

            if (File.Exists("c:\\Users\\Kenny\\C#Data\\test.xaml"))
            {
                range = new TextRange(RichTB.Document.ContentStart, RichTB.Document.ContentEnd);
                fStream = new FileStream("c:\\Users\\Kenny\\C#Data\\test.xaml", FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.XamlPackage);
                fStream.Close();
            }
        }

    }
}
