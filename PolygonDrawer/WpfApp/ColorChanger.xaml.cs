using System;
using System.Windows;

namespace PolygonDrawer
{
    /// <summary>
    /// Логика взаимодействия для ChangeColor.xaml
    /// </summary>
    public partial class ChangeColor : Window
    {
        public byte RedIndex { get; set; }
        public byte GreenIndex { get; set; }
        public byte BlueIndex { get; set; }

        public ChangeColor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (byte.TryParse(RedIndexTextBox.Text, out var redIndex))
                    RedIndex = redIndex;
                if (byte.TryParse(GreenIndexTextBox.Text, out var greenIndex))
                    GreenIndex = greenIndex;
                if (byte.TryParse(BlueIndexTextBox.Text, out var blueIndex))
                    BlueIndex = blueIndex;

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
