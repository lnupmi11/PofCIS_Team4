using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Win32;
using PolygonDrawer.BL;
using PolygonDrawer.Utils;
using WpfApp;

namespace PolygonDrawer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDraw = false;
        private Polygon _polygon;
        private List<Polygon> _polygonList = new List<Polygon>();
        private int _currentVertex = 0;
        private int _numberOfVertex = 0;
        private int _numberOfPolygons = 0;

        /// <summary>
        /// Initialize componets for Main Window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New(object sender, RoutedEventArgs e)
        {
            cnv.Children.Clear();
        }

        private void OnClosing(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            Ul.CreateInformationWindow();
        }

        private void Save(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = Ul.CreateSaveFile();

            if (saveFileDialog.ShowDialog() == true)
            {
                ShapesBl.SerializeList(_polygonList, saveFileDialog.FileName);
            }

        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = Ul.CreateOpenFile();

            if (openFileDialog.ShowDialog() == true)
            {
                _polygonList.Clear();
                _polygonList = ShapesBl.DeserializeList(openFileDialog.FileName);
                cnv.Children.Clear();
                foreach (var it in _polygonList)
                {
                    cnv.Children.Add(it);
                }

                _numberOfPolygons = _polygonList.Count;
            }

        }

        private void DrawNewPolygon(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2 && _isDraw == false)
            {
                CreatePolygon data = new CreatePolygon();

                if (data.ShowDialog() == true)
                {
                    if (int.TryParse(data.NumberOfAngles, out var result) && result >= 3)
                    {
                        _numberOfPolygons++;
                        _polygon = new Polygon
                        {
                            Stroke = Brushes.Black,
                            Fill = Brushes.LightBlue,
                            StrokeThickness = result,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Center,
                            Name = $"Polugon{_numberOfPolygons}"
                        };
                        _numberOfVertex = result;

                        _isDraw = true;

                        _polygon.Points = new PointCollection();
                        _polygonList.Add(_polygon);
                    }
                }
            }
            else if (e.ClickCount == 1 && _isDraw)
            {
                _currentVertex++;
                var tmp = e.GetPosition(this);
                _polygon.Points.Add(new Point(tmp.X, tmp.Y));

                if (_currentVertex == _numberOfVertex)
                {
                    cnv.Children.Add(_polygon);
                    _polygon = null;
                    _currentVertex = 0;
                    _numberOfVertex = 0;
                    _isDraw = false;
                }
            }

            LabelVertex.Content = (_numberOfVertex - _currentVertex).ToString();
            ShowPolygons();
        }

        private void ShowPolygons()
        {
            ListOfPolygons.Items.Clear();
            foreach (var polygon in _polygonList)
            {
                var item = new ListBoxItem
                {
                    Content = $"{polygon.Name} with {polygon.Points.Count} points.",

                };

                ListOfPolygons.Items.Add(item);
            }
        }

        private void ListOfPolygons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_polygonList.Find(element => element.Name == ListOfPolygons.SelectedItem?.ToString().Split()[1]) != null)
            {
                ChangeColor changeColorWindow = new ChangeColor();
                if (changeColorWindow.ShowDialog() == true)
                {
                    var brush = new SolidColorBrush(Color.FromRgb(changeColorWindow.RedIndex,
                        changeColorWindow.GreenIndex,
                        changeColorWindow.BlueIndex));
                    _polygonList.Find(element => element.Name == ListOfPolygons.SelectedItem?.ToString().Split()[1])
                            .Fill
                        = brush;
                }
            }
        }
    }
}
