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
using Microsoft.Win32;

namespace PolygonDrawer
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

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Visibility = Visibility.Visible;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Visibility = Visibility.Visible;

            FileDialog fileDialog = new SaveFileDialog
            {
                Filter = "XML files|*.xml|All files|*.*"
            };
            if (fileDialog.ShowDialog() == true)
                //TODO
                return;

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Visibility = Visibility.Visible;

            FileDialog fileDialog = new OpenFileDialog
            {
                Filter = "XML files|*.xml|All files|*.*",
                DefaultExt = ".xml"
            };

            var dialogOk = fileDialog.ShowDialog();
            if (dialogOk == true)
            {
                string fileName = fileDialog.FileName;
                //TODO
            }
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var canvas = sender as Canvas;
            var canvasChangedArgs = e;
            
            if (Math.Abs(canvasChangedArgs.PreviousSize.Width) < 0.000001)
                return;

            var oldHeight = canvasChangedArgs.PreviousSize.Height;
            var newHeight = canvasChangedArgs.NewSize.Height;
            var oldWidth = canvasChangedArgs.PreviousSize.Width;
            var newWidth = canvasChangedArgs.NewSize.Width;

            var scaleWidth = newWidth / oldWidth;
            var scaleHeight = newHeight / oldHeight;


            if (canvas != null)
                foreach (FrameworkElement element in canvas.Children)
                {
                    var oldLeft = Canvas.GetLeft(element);
                    var oldTop = Canvas.GetTop(element);

                    Canvas.SetLeft(element, oldLeft * scaleWidth);
                    Canvas.SetTop(element, oldTop * scaleHeight);

                    element.Width = element.Width * scaleWidth;
                    element.Height = element.Height * scaleHeight;
                }
        }
    }
}
