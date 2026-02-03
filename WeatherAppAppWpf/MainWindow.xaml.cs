using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherAppAppWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonSubmit.Click += ButtonSubmit_Click;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            Label label = new Label();
            WeatherManager weatherManager = new WeatherManager("");
            string weather = weatherManager.GetWeather("Владикавказ").ToString();
            label.Content = weather;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.FontSize = 40;
            border.Visibility = Visibility.Visible;

            
            Grid.SetColumn(label, 1);
            Grid.SetRow(label, 0);
            grid.Children.Add(label);
        }
    }
}