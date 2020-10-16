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

namespace ColorsWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Colors
        {
            private int r;
            private int g;
            private int b;

            public Colors(int red, int green, int blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }

            public int Red { get => r; set => r = value; }
            public int Green { get => g; set => g = value; }
            public int Blue { get => b; set => b = value; }
        }

        Colors myColors;
        SolidColorBrush mrBrush;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            myColors = new Colors(0, 0, 0);
            mrBrush = new SolidColorBrush(Color.FromRgb((byte)myColors.Red, (byte)myColors.Green, (byte)myColors.Blue));
            mrIntStackPanel.DataContext = myColors;
            mrIntSliders.DataContext = myColors;
            mrRectangle.DataContext = mrBrush;
        }

        private void colorUpdated(object sender, TextChangedEventArgs e)
        {
            mrBrush = new SolidColorBrush(Color.FromRgb((byte)myColors.Red, (byte)myColors.Green, (byte)myColors.Blue));
            mrRectangle.Fill = mrBrush;
        }
    }
}
