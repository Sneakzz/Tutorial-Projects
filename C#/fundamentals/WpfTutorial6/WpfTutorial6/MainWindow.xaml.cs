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

namespace WpfTutorial6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    // For generating a limited number of 2D vector images you can use System.Windows.Shapes
    // Shapes created this way respond to events like other WPF components.
    public partial class MainWindow : Window
    {
        // Define enum for all 3 shapes
        private enum MyShape
        {
            Line, Ellipse, Rectangle
        }

        // Define the current shape used
        private MyShape currShape = MyShape.Line;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Line;
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Ellipse;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Rectangle;
        }

        Point start;
        Point end;

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
            start = e.GetPosition(this);
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Draw the correct shape
            switch (currShape)
            {
                case MyShape.Line:
                    DrawLine();
                    break;

                case MyShape.Ellipse:
                    DrawEllipse();
                    break;

                case MyShape.Rectangle:
                    DrawRectangle();
                    break;

                default:
                    return;
            }
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves for the end point
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        // Sets and draws line after mouse is released
        private void DrawLine()
        {
            Line newLine = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = start.X,
                Y1 = start.Y - 50,
                X2 = end.X,
                Y2 = end.Y - 50
            };

            MyCanvas.Children.Add(newLine);

        }

        // Sets and draws an ellipse after mouse is released
        private void DrawEllipse()
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Green,
                Fill = Brushes.Red,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            // If the user tries to draw from any direction then down and to the right
            // you'll get an error unless you use a if/else statement to change
            // LeftProperty & TopProperty and Height and Width accordingly.

            if (end.X >= start.X)
            {
                // Defines the left part of the ellipse
                newEllipse.SetValue(Canvas.LeftProperty, start.X);
                newEllipse.Width = end.X - start.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, end.X);
                newEllipse.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, start.Y - 50);
                newEllipse.Height = end.Y - start.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, end.Y - 50);
                newEllipse.Height = start.Y - end.Y;
            }

            MyCanvas.Children.Add(newEllipse);
        }

        // Sets and draws rectangle after mouse is released
        private void DrawRectangle()
        {
            Rectangle newRectangle = new Rectangle()
            {
                Stroke = Brushes.Green,
                Fill = Brushes.Red,
                StrokeThickness = 4
            };

            if (end.X >= start.X)
            {
                // Defines the left part of the rectangle
                newRectangle.SetValue(Canvas.LeftProperty, start.X);
                newRectangle.Width = end.X - start.X;
            }
            else
            {
                newRectangle.SetValue(Canvas.LeftProperty, end.X);
                newRectangle.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                // Defines the top part of the rectangle
                newRectangle.SetValue(Canvas.TopProperty, start.Y - 50);
                newRectangle.Height = end.Y - start.Y;
            }
            else
            {
                newRectangle.SetValue(Canvas.TopProperty, end.Y - 50);
                newRectangle.Height = start.Y - end.Y;
            }

            MyCanvas.Children.Add(newRectangle);
        }
    }
}
