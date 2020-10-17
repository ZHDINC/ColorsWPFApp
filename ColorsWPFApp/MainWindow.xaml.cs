using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public class Colors : INotifyPropertyChanged
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

            public int Red 
            { 
                get => r; 
                set
                {
                    if(value != this.r)
                    {
                        this.r = value;
                        OnPropertyChanged();
                    }
                } 
            }
            public int Green 
            { 
                get => g; 
                set
                {
                    if(value != this.g)
                    {
                        this.g = value;
                        OnPropertyChanged();
                    }
                }
            }
            public int Blue 
            { 
                get => b; 
                set
                {
                    if(value != this.b)
                    {
                        this.b = value;
                        OnPropertyChanged();
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string s = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
            }
        }

        public class ColorRects : INotifyPropertyChanged
        {
            private int r;
            private int g;
            private int b;

            public ColorRects(int r, int g, int b)
            {
                RedRect = r;
                GreenRect = g;
                BlueRect = b;
            }

            public int RedRect
            {
                get => r;
                set
                {
                    if (value == 0)
                        this.r = value;
                    else
                        this.r = (int)((value / 255.0) * 175);
                    OnPropertyChanged();
                }
            }

            public int GreenRect
            {
                get => g;
                set
                {
                    if (value == 0)
                        this.g = value;
                    else
                        this.g = (int)((value / 255.0) * 175);
                    OnPropertyChanged();
                }
            }

            public int BlueRect
            {
                get => b;
                set
                {
                    if (value == 0)
                        this.b = value;
                    else
                        this.b = (int)((value / 255.0) * 175);
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            
            private void OnPropertyChanged([CallerMemberName] string s = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
            }
        }

        Colors myColors;
        SolidColorBrush mrBrush;
        ColorRects myColorRects;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            myColors = new Colors(0, 0, 0);
            myColorRects = new ColorRects(myColors.Red, myColors.Green, myColors.Blue);
            mrBrush = new SolidColorBrush(Color.FromRgb((byte)myColors.Red, (byte)myColors.Green, (byte)myColors.Blue));
            mrIntStackPanel.DataContext = myColors;
            mrIntSliders.DataContext = myColors;
            mrRectangle.DataContext = mrBrush;
            TheRects.DataContext = myColorRects;
        }

        private void colorUpdated(object sender, TextChangedEventArgs e)
        {
            mrBrush = new SolidColorBrush(Color.FromRgb((byte)myColors.Red, (byte)myColors.Green, (byte)myColors.Blue));
            myColorRects.RedRect = myColors.Red;
            myColorRects.GreenRect = myColors.Green;
            myColorRects.BlueRect = myColors.Blue;
            mrRectangle.Fill = mrBrush;
        }

        private void onWhoop(object sender, RoutedEventArgs e)
        {
            myColors.Red = 80;
            myColors.Green = 0;
            myColors.Blue = 0;
            mrBrush = new SolidColorBrush(Color.FromRgb((byte)myColors.Red, (byte)myColors.Green, (byte)myColors.Blue));
            myColorRects.RedRect = myColors.Red;
            myColorRects.GreenRect = myColors.Green;
            myColorRects.BlueRect = myColors.Blue;
            mrRectangle.Fill = mrBrush;
        }

        private void onAbout(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This program was written to get a grasp on data binding in WPF!\n(to which it was a great success!)\nWritten by Zachary Drew\ngithub.com/ZHDINC", "About...", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
