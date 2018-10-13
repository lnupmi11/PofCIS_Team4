using System;
using System.Windows;
using System.Windows.Input;

namespace PolygonDrawer
{
    /// <summary>
    /// Interaction logic for CreatePolygon.xaml
    /// </summary>
    public partial class CreatePolygon : Window
    {
        public string NumberOfAngles => Text.Text;

        /// <summary>
        /// Creates a polygon on the canvas.
        /// </summary>
        public CreatePolygon()
        {
            InitializeComponent();
            Text.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetWindow(this).DialogResult = true;
                GetWindow(this)?.Close();
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show($"Exception Occured\n{exception.Message}");
            }
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    GetWindow(this).DialogResult = true;
                    GetWindow(this)?.Close();
                }
                catch (ArgumentNullException exception)
                {
                    MessageBox.Show($"Exception Occured\n{exception.Message}");
                }
            }
        }
    }
}
