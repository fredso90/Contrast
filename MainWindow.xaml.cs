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

namespace Contrast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HideGenerateImageButton()
        {
            if(contrastMenuItem.IsSelected)
            {
                GetImage.Visibility = Visibility.Hidden;
            } else if (!contrastMenuItem.IsSelected)
            { 
                GetImage.Visibility = Visibility.Visible;
            }
        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            RunSelectedPaletteType();
            HideGenerateImageButton();
        }

        private void generateSomeRadio_Click(object sender, RoutedEventArgs e)
        {
            if(generateAllRadio.IsChecked == true)
            {
                customR.IsReadOnly= true;
                customG.IsReadOnly= true;
                customB.IsReadOnly= true;
                customR.Foreground = Brushes.LightGray;
                customG.Foreground = Brushes.LightGray;
                customB.Foreground = Brushes.LightGray;
                customR.Text = "R";
                customG.Text = "G";
                customB.Text = "B";
                customHex.IsReadOnly = true;
                customHex.Foreground = Brushes.LightGray;
            } else if (generateSomeRadio.IsChecked == true) 
            {
                customR.IsReadOnly = false;
                customG.IsReadOnly = false;
                customB.IsReadOnly = false;
                customR.Foreground = Brushes.Black;
                customG.Foreground = Brushes.Black;
                customB.Foreground = Brushes.Black;
                customHex.IsReadOnly = true;
                customHex.Foreground = Brushes.LightGray;
            } else if(generateSomeHexRadio.IsChecked == true)
            {
                customR.IsReadOnly = true;
                customG.IsReadOnly = true;
                customB.IsReadOnly = true;
                customR.Foreground = Brushes.LightGray;
                customG.Foreground = Brushes.LightGray;
                customB.Foreground = Brushes.LightGray;
                customR.Text = "R";
                customG.Text = "G";
                customB.Text = "B";
                customHex.IsReadOnly = false;
                customHex.Foreground = Brushes.Black;
            }
        }

        private void GetImage_Click(object sender, RoutedEventArgs e)
        {
            ImageWindow imageWindow = new ImageWindow();

            imageWindow.Show();
            imageWindow.Owner = this;
        }

        private void RunSelectedPaletteType()
        {
            if (analogousMenuItem.IsSelected)
            {
                AnalogousPalette();
            }
            else if (contrastMenuItem.IsSelected)
            {
                ContrastColor();
            } else if(triadicMenuItem.IsSelected)
            {
                TriadicPalette();
            }
        }

        private List<int> GenerateColor()
        {
            List<int> colors = new List<int>();
            if (generateSomeRadio.IsChecked == true)
            {
                colors.Add(Convert.ToInt32(customR.Text));
                colors.Add(Convert.ToInt32(customG.Text));
                colors.Add(Convert.ToInt32(customB.Text));
            } else if (generateAllRadio.IsChecked == true)
            {
                var rand = new Random();

                for (int i = 0; i < 3; i++)
                {
                    colors.Add(rand.Next(0, 255));
                }
            } else if(generateSomeHexRadio.IsChecked == true)
            {
                colors = ConvertHexToRGB(customHex.Text);
            }

            return colors;
        }

        private List<int> ConvertHexToRGB(string hex)
        {
            List<int>colors = new List<int>();
            string temp = "";

            while(hex.Length > 0)
            {
                temp += hex[0];
                temp += hex[1];

                colors.Add(ConvertHexToRGBSwitch(temp));

                temp = "";
                hex = hex.Remove(0, 1);
                hex = hex.Remove(0, 1);
            }

            return colors;
        }

        private int ConvertHexToRGBSwitch(string partialHex)
        {
            int p1 = 0;
            int p2 = 0;

            switch(partialHex[0])
            {
                case'0':
                    p1 = 0;
                    break;
                case'1':
                    p1 = 1 * 16;
                    break;
                case '2':
                    p1 = 2 * 16;
                    break;
                case '3':
                    p1 = 3 * 16;
                    break;
                case '4':
                    p1 = 4 * 16;
                    break;
                case '5':
                    p1 = 5 * 16;
                    break;
                case '6':
                    p1 = 6 * 16;
                    break;
                case '7':
                    p1 = 7 * 16;
                    break;
                case '8':
                    p1 = 8 * 16;
                    break;
                case '9':
                    p1 = 9 * 16;
                    break;
                case 'a':
                    p1 = 10 * 16;
                    break;
                case 'b':
                    p1 = 11 * 16;
                    break;
                case 'c':
                    p1 = 12 * 16;
                    break;
                case 'd':
                    p1 = 13 * 16;
                    break;
                case 'e':
                    p1 = 14 * 16;
                    break;
                case 'f':
                    p1 = 15 * 16;
                    break;
            }

            switch(partialHex[1])
            {
                case '0':
                    p2 = 0;
                    break;
                case '1':
                    p2 = 1;
                    break;
                case '2':
                    p2 = 2;
                    break;
                case '3':
                    p2 = 3;
                    break;
                case '4':
                    p2 = 4;
                    break;
                case '5':
                    p2 = 5;
                    break;
                case '6':
                    p2 = 6;
                    break;
                case '7':
                    p2 = 7;
                    break;
                case '8':
                    p2 = 8;
                    break;
                case '9':
                    p2 = 9;
                    break;
                case 'a':
                    p2 = 10;
                    break;
                case 'b':
                    p2 = 11;
                    break;
                case 'c':
                    p2 = 12;
                    break;
                case 'd':
                    p2 = 13;
                    break;
                case 'e':
                    p2 = 14;
                    break;
                case 'f':
                    p2 = 15;
                    break;
            }

            return p1 + p2;
        }

        private string ConvertToHex(List<int> colors)
        {
            string returnString = "#";

            foreach( int color in colors)
            {
                switch((color - (color % 16))/16)
                {
                    case 15:
                        returnString += "f";
                        break;
                    case 14:
                        returnString += "e";
                        break;
                    case 13:
                        returnString += "d";
                        break;
                    case 12:
                        returnString += "c";
                        break;
                    case 11:
                        returnString += "b";
                        break;
                    case 10:
                        returnString += "a";
                        break;
                    case 9:
                        returnString += "9";
                        break;
                    case 8:
                        returnString += "8";
                        break;
                    case 7:
                        returnString += "7";
                        break;
                    case 6:
                        returnString += "6";
                        break;
                    case 5:
                        returnString += "5";
                        break;
                    case 4:
                        returnString += "4";
                        break;
                    case 3:
                        returnString += "3";
                        break;
                    case 2:
                        returnString += "2";
                        break;
                    case 1:
                        returnString += "1";
                        break;
                    case 0:
                        returnString += "0";
                        break;
                }

                switch (color%16)
                {
                    case 15:
                        returnString += "f";
                        break;
                    case 14:
                        returnString += "e";
                        break;
                    case 13:
                        returnString += "d";
                        break;
                    case 12:
                        returnString += "c";
                        break;
                    case 11:
                        returnString += "b";
                        break;
                    case 10:
                        returnString += "a";
                        break;
                    case 9:
                        returnString += "9";
                        break;
                    case 8:
                        returnString += "8";
                        break;
                    case 7:
                        returnString += "7";
                        break;
                    case 6:
                        returnString += "6";
                        break;
                    case 5:
                        returnString += "5";
                        break;
                    case 4:
                        returnString += "4";
                        break;
                    case 3:
                        returnString += "3";
                        break;
                    case 2:
                        returnString += "2";
                        break;
                    case 1:
                        returnString += "1";
                        break;
                    case 0:
                        returnString += "0";
                        break;
                }
            }

            return returnString;
        }

        private void AnalogousPalette()
        {
            List<int> color2List = GenerateColor();
            List<double> color1List = ConvertRGBToHSV(color2List);
            List<double> color3List = ConvertRGBToHSV(color2List);

            if (color1List[0] - 15 > 0)
            {
                color1List[0] -= 15;
            } else if (color1List[0] - 15 < 0)
            {
                color1List[0] = 360 + (color1List[0] - 15);
            }

            if (color3List[0] + 15 < 360)
            {
                color3List[0] += 15;
            }
            else if (color3List[0] + 15 >= 360)
            {
                color3List[0] = 360 - color3List[0] +15;
            }

            string color2 = ConvertToHex(color2List);
            SolidColorBrush color2brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color2));

            string color1 = ConvertToHex(ConvertHSVToRGB(color1List));
            SolidColorBrush color1brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color1));

            string color3 = ConvertToHex(ConvertHSVToRGB(color3List));
            SolidColorBrush color3brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color3));


            color1_txt.Content = color1;
            color1_clr.Background = color1brush;

            color2_txt.Content = color2;
            color2_clr.Background = color2brush;

            color3_txt.Content = color3;
            color3_txt.Background = Brushes.White;
            color3_clr.Background = color3brush;
        }

        private void ContrastColor()
        {
            List<int> color1List = GenerateColor();
            List<double> color2List = ConvertRGBToHSV(color1List);

            if (color2List[0] + 180 < 360)
            {
                color2List[0] += 180;
            } else if (color2List[0] + 180 >= 360)
            {
                color2List[0] = color2List[0] + 180 - 360;
            }

            string color1 = ConvertToHex(color1List);
            SolidColorBrush color1brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color1));

            string color2 = ConvertToHex(ConvertHSVToRGB(color2List));
            SolidColorBrush color2brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color2));

            color1_txt.Content = color1;
            color1_clr.Background = color1brush;

            color2_txt.Content = color2;
            color2_clr.Background = color2brush;

            color3_txt.Content = "";
            color3_txt.Background = null;
            color3_clr.Background = null;
        }

        private void TriadicPalette()
        {
            List<int> color2List = GenerateColor();
            List<double> color1List = ConvertRGBToHSV(color2List);
            List<double> color3List = ConvertRGBToHSV(color2List);

            if (color1List[0] - 120 >= 0)
            {
                color1List[0] -= 120;
            } else if (color1List[0] - 120 < 0)
            {
                color1List[0] = 360 + (color1List[0] - 120);
            }

            if (color3List[0] + 120 < 360)
            {
                color3List[0] += 120;
            } else if (color3List[0] + 120 >= 360)
            {
                color3List[0] = color3List[0] + 120 - 360;
            }

            string color2 = ConvertToHex(color2List);
            SolidColorBrush color2brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color2));

            string color1 = ConvertToHex(ConvertHSVToRGB(color1List));
            SolidColorBrush color1brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color1));

            string color3 = ConvertToHex(ConvertHSVToRGB(color3List));
            SolidColorBrush color3brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color3));

            color1_txt.Content = color1;
            color1_clr.Background = color1brush;

            color2_txt.Content = color2;
            color2_clr.Background = color2brush;

            color3_txt.Content = color3;
            color3_txt.Background = Brushes.White;
            color3_clr.Background = color3brush;
        }

        private List<double> ConvertRGBToHSV(List<int> rgb) 
        {
            List<double> HSV = new List<double>();
            double r = rgb[0];
            double g = rgb[1];
            double b = rgb[2];

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);

            double v = max / 255;
            double s = 0;
            double hradians = 0;
            double h = 0;

            if(max > 0)
            {
                s = 1 - (min / max);
            } else if(max == 0)
            {
                s = 0;
            }

            //Define h(hue)
            if(g >= b)
            {
                hradians = Math.Acos((r - (g / 2) - (b / 2)) / Math.Sqrt((r * r) + (g * g) + (b * b) - (r * g) - (r * b) - (g * b)));
                h = Math.Round(hradians * (180 / Math.PI));
                HSV.Add(h);
            } else if(b > g)
            {
                hradians = Math.Acos((r - (g / 2) - (b / 2)) / Math.Sqrt((r * r) + (g * g) + (b * b) - (r * g) - (r * b) - (g * b)));
                h = Math.Round(360 - (hradians * (180 / Math.PI)));
                HSV.Add(h);
            }

            HSV.Add(s);
            HSV.Add(v);


            return HSV;
        }

        private List<int> ConvertHSVToRGB(List<double> hsv)
        {
            List<int> rgb = new List<int>();

            double h = hsv[0];
            double s = hsv[1];
            double v = hsv[2];

            int max = Convert.ToInt32(Math.Round(255 * v));
            int min = Convert.ToInt32(Math.Round(max * (1 - s)));
            int z = 0;

            if(max - min != 0)
            {
                z = Convert.ToInt32(Math.Round((max - min) * (1 - ((h / 60) % 2 - 1))));
            }       

            int r = 0;
            int g = 0;
            int b = 0;

            if(h < 60)
            {
                r = max;
                g = z + min;
                b = min;
            } else if(h >= 60 && h < 120)
            {
                r = z + min;
                g = max;
                b = min;
            } else if(h >= 120 && h < 180)
            {
                r = min;
                g = max;
                b = z + min;
            } else if(h >= 180 && h < 240)
            {
                r = min;
                g = z + min;
                b = max;
            } else if(h >= 240 && h < 300)
            {
                r = z + min;
                g = min;
                b = max;
            } else if(h >= 300 && h <= 360)
            {
                r = max;
                g = min;
                b = z + min;
            }

            if(r > 255)
            {
                r = r - 255;
            }
            if(r < 0)
            {
                r = 255 + r;
            }

            if (g > 255)
            {
                g = g - 255;
            }
            if (g < 0)
            {
                g = 255 + g;
            }

            if (b > 255)
            {
                b = b -255;
            }
            if (b < 0)
            {
                b = 255 + b;
            }

            rgb.Add(r);
            rgb.Add(g);
            rgb.Add(b);

            return rgb;
        }


    }
}
