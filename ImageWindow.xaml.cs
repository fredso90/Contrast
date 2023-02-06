using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;


namespace Contrast
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
            SetColors();
        }

        private void SetColors()
        {
            var window = (MainWindow)Application.Current.MainWindow;
            SolidColorBrush colorOneBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Convert.ToString(window.color1_txt.Content)));
            SolidColorBrush colorTwoBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Convert.ToString(window.color2_txt.Content)));
            SolidColorBrush colorThreeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Convert.ToString(window.color3_txt.Content)));

            color1image.Background = colorOneBrush;
            color2image.Background = colorTwoBrush;
            color3image.Background = colorThreeBrush;

            ellipse1.Fill = colorOneBrush;
            ellipse2.Fill = colorTwoBrush;
            ellipse3.Fill = colorThreeBrush;

            c1_rect.Fill = colorOneBrush;
            c2_rect.Fill = colorTwoBrush;
            c3_rect.Fill = colorThreeBrush;
            con.Foreground = colorOneBrush;
            tra.Foreground = colorTwoBrush;
            st.Foreground = colorThreeBrush;

            c1_txt.Content = Convert.ToString(window.color1_txt.Content);
            c2_txt.Content = Convert.ToString(window.color2_txt.Content);
            c3_txt.Content = Convert.ToString(window.color3_txt.Content);

            c1_txt.Background = Brushes.White;
            c2_txt.Background = Brushes.White;
            c3_txt.Background = Brushes.White;
        }
        
        private bool SaveAsPng()
        {
            saveImgBtn.Visibility = Visibility.Hidden;
            try
            {
                Window window = Application.Current.Windows.OfType<ImageWindow>().Single(x => x.IsActive);

                RenderTargetBitmap bmp = new RenderTargetBitmap((int)window.ActualWidth, (int)window.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(window);

                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(bmp));

                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "ContrastPalette"; // Default file name
                dlg.DefaultExt = ".png"; // Default file extension
                dlg.Filter = "Png (.png)|*.png"; // Filter files by extension

                string filename = "";

                //Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                //Process save file dialog results

                if (result == true)
                {
                    //Save image
                    filename = dlg.FileName;
                }

                //Save file to the user's system using the path selected in the save file dialog
                using (Stream stm = File.Create(System.IO.Path.GetFullPath(filename)))
                {
                    png.Save(stm);
                }
                saveImgBtn.Visibility = Visibility.Visible;
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                saveImgBtn.Visibility = Visibility.Visible;
                return false;
            }
            

        }

        private void saveImgBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveAsPng();
        }
    }
}
