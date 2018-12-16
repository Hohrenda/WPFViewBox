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

namespace WpfViewBoxAttr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ImageSource_MouseMove(object sender, MouseEventArgs e)
        {


          
            Image image = sender as Image;
            Point p = e.GetPosition(image);

            var imgWidth = image.ActualWidth;
            var imgHeight = image.ActualHeight;

            var currentX = p.X;
            var currentY = p.Y;

            var viewBoxStartX = (currentX / imgWidth)-0.25;
            var viewBoxStartY = (currentY / imgHeight)-0.25;

            var viewBoxWidth = 0.5;
            var viewBoxHeight = 0.5;

            var viewBoxMaxStartX = 0.5;
            var viewBoxMaxStartY = 0.5;

            if (viewBoxStartX <= viewBoxMaxStartX && viewBoxStartY <= viewBoxMaxStartY)
            {
                ((VisualBrush)imageScaled.Fill).Viewbox =
                    new Rect(viewBoxStartX, viewBoxStartY, viewBoxWidth, viewBoxHeight);
            }
            else if (viewBoxStartX > viewBoxMaxStartX && viewBoxStartY <= viewBoxMaxStartY)
            {
                ((VisualBrush)imageScaled.Fill).Viewbox =
                    new Rect(viewBoxMaxStartX, viewBoxStartY, viewBoxWidth, viewBoxHeight);
            }
            else if (viewBoxStartY > viewBoxMaxStartY && viewBoxStartX <= viewBoxMaxStartX)
            {
                ((VisualBrush)imageScaled.Fill).Viewbox =
                    new Rect(viewBoxStartX, viewBoxMaxStartY, viewBoxWidth, viewBoxHeight);
            }

            if (p.X*1.33 < image.ActualWidth && p.X>image.MinWidth + 92)
            {
                imageBox.Width = imgWidth * 0.5;
                Canvas.SetLeft(imageBox, currentX - imageBox.Width * 0.5);
            }
            if (p.Y*1.33<imgHeight && p.Y>image.MinHeight + 69)
            {
                Console.WriteLine(p.Y);
                imageBox.Height = imgHeight * 0.5;
                Canvas.SetTop(imageBox, currentY - imageBox.Height * 0.5);
            }
            //imageBox.Visibility = Visibility.Visible;
            //imageBox.Width = imgWidth * 0.5;
            //imageBox.Height = imgHeight * 0.5;
            //Canvas.SetLeft(imageBox, currentX - imageBox.Width * 0.5);
            //Canvas.SetTop(imageBox, currentY - imageBox.Height * 0.5);
            imageSource.CaptureMouse();


        }
        private void ImageSource_MouseLeave(object sender, MouseEventArgs e)
        {
            imageSource.ReleaseMouseCapture();
        }
    }
}
