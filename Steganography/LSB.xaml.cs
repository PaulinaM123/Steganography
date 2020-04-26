using Microsoft.Win32;
using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Steganografia_implementacja
{
    /// <summary>
    /// Interaction logic for LSB.xaml
    /// </summary>
    public partial class LSB : UserControl
    {
        public LSB()
        {
            InitializeComponent();
        }
        string lokalizacja;
        string lokalizacja2;
       
        public static byte[] DecodeToBytes(string str)
        {
            bool even = str[0] == '0';
            byte[] bytes = new byte[(str.Length - 1) * sizeof(char) + (even ? 0 : -1)];
            char[] chars = str.ToCharArray();
            System.Buffer.BlockCopy(chars, 2, bytes, 0, bytes.Length);

            return bytes;
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        public static byte f_LSB(byte color, char c)
        {
            BitArray myBA = new BitArray(BitConverter.GetBytes(color).ToArray());
            if (c == '1')
            {
                myBA[0] = true;
            }
            else
            {
                myBA[0] = false;
            }
            byte[] bb = BitArrayToByteArray(myBA);
            color = bb[0];
            return color;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files ( *png, *jpg, *bmp) | *.png; *.jpg; *.bmp";
            openDialog.InitialDirectory = "C:\\Users\\PM\\Desktop";
            lokalizacja = openDialog.FileName.ToString();

            Nullable<bool> result = openDialog.ShowDialog();

            if (result == true)
            {
                lokalizacja = openDialog.FileName;
                Obraz.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(lokalizacja);

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri(lokalizacja));
            int width = (int)image.PixelWidth;
            int height = (int)image.PixelHeight;
            WriteableBitmap bitmap = new WriteableBitmap(image);
            string data = tekst.Text;
            bool zabezpieczenie_przed_rozmiarem = true;
            if (((width * height * 3) - 9) < ((data.Length) * 8))
            {
                zabezpieczenie_przed_rozmiarem = false;
            }
            int start_pixel = Int32.Parse(start.Text);
            bool poczatek = true; ;
            if(((width * height * 3) - 9)-start_pixel< (data.Length) * 8)
            {
                poczatek = false;
            }
            if (zabezpieczenie_przed_rozmiarem == true && poczatek==true)
            {
                int stride = width * ((bitmap.Format.BitsPerPixel + 7) / 8);
                int arraySize = stride * height;
                byte[] pixels = new byte[arraySize];
                bitmap.CopyPixels(pixels, stride, 0);


                Console.WriteLine(data);
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                int długość = bytes.Length;
                Console.WriteLine(długość);
                var sb = new StringBuilder();
                sb.Append(Convert.ToString(długość, 2).PadLeft(8, '0'));
                sb.Append('1');
                for (int t = 0; t < bytes.Length; t++)
                {
                    for (var g = 7; g >= 0; g--)
                    {
                        sb.Append((bytes[t] & (1 << g)) == 0 ? '0' : '1');
                    }
                }
                Console.WriteLine(sb);
                Console.WriteLine(sb[0]);
                Console.WriteLine("Długość sb: " + sb.Length);
                Console.WriteLine("Height: " + height);
                Console.WriteLine("Width:" + width);





                int licznik = 0;
                int j = 0;
                for (int i = 0; i < height; ++i)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if (licznik < sb.Length)
                        {
                            byte blue = pixels[j];
                            byte green = pixels[j + 1];
                            byte red = pixels[j + 2];


                            blue = f_LSB(blue, sb[licznik]);
                            licznik++;

                            if (licznik < sb.Length)
                            {
                                green = f_LSB(green, sb[licznik]);
                                licznik++;
                            }
                            if (licznik < sb.Length)
                            {
                                red = f_LSB(red, sb[licznik]);
                                licznik++;
                            }
                            pixels[j] = blue;
                            pixels[j + 1] = green;
                            pixels[j + 2] = red;
                            Console.WriteLine();
                            Console.WriteLine("  i= " + i + " j= " + k);
                            Console.Write("   Blue: " + blue);
                            Console.Write("   Green: " + green);
                            Console.Write("   Red: " + red);

                            Console.WriteLine();

                            j = j + 4;
                        }
                    }
                }


                BitmapSource bs = BitmapSource.Create(width, height, 300, 300, PixelFormats.Bgr32, null, pixels, stride);
                Obraz1.Source = bs;
                //zapisz_obraz(Obraz1);
            }
            else
            {
                MessageBox.Show("Tekst jest za długi. Nie zmieści się na wczytanym obrazku!");
            }

        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string filePath = @"C:\Users\PM\Desktop\Tajne.png";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)Obraz1.Source));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            BitmapImage image = new BitmapImage(new Uri(lokalizacja2));
            int width = (int)image.PixelWidth;
            int height = (int)image.PixelHeight;
            WriteableBitmap bitmap = new WriteableBitmap(image);

            int stride = width * ((bitmap.Format.BitsPerPixel + 7) / 8);
            int arraySize = stride * height;
            byte[] pixels = new byte[arraySize];
            bitmap.CopyPixels(pixels, stride, 0);
            //int start_pixel = Int32.Parse(start2.Text);
            //*****znacznik rozmiaru
            var rozmiar = new StringBuilder();
            int j = 0;
            

            for (j = 0; j < 9; j = j + 4)
            {
                byte blue = pixels[j];
                rozmiar.Append((blue & (1 << 0)) == 0 ? '0' : '1');
                byte green = pixels[j + 1];
                rozmiar.Append((green & (1 << 0)) == 0 ? '0' : '1');
                byte red = pixels[j + 2];
                rozmiar.Append((red & (1 << 0)) == 0 ? '0' : '1');
            }

            string rozmiar_string = (rozmiar.ToString()).Remove(8);
            Console.WriteLine("ZNACZNIK: " + rozmiar_string);
            int size = Convert.ToInt32(rozmiar_string, 2);
            Console.WriteLine("SIZE: " + size);

            var sb = new StringBuilder();
            j = 0;
            byte[] bb = new byte[size * 8 + 9];
            int licznik = 0;
            for (int i = 0; i < height; ++i)
            {
                for (int k = 0; k < width; k++)
                {

                    if (licznik < bb.Length)
                    {
                        byte blue = pixels[j];
                        bb[licznik] = blue;
                        licznik++;
                    }
                    if (licznik < bb.Length)
                    {
                        byte green = pixels[j + 1];
                        bb[licznik] = green;
                        licznik++;
                    }
                    if (licznik < bb.Length)
                    {
                        byte red = pixels[j + 2];
                        bb[licznik] = red;
                        licznik++;
                    }

                    j = j + 4;

                }
            }
            
            for (int t = 9; t < bb.Length; t++)
            {

                sb.Append((bb[t] & (1 << 0)) == 0 ? '0' : '1');

            }
            string s = sb.ToString();
            string result = "";
            while (s.Length > 0)
            {
                var first8 = s.Substring(0, 8);
                s = s.Substring(8);
                var number = Convert.ToInt32(first8, 2);
                result += (char)number;
            }
            if (start.Text == start2.Text)
            {
                tekst2.Text = result;
            }
            else
            {
                tekst2.Text = "Baj^*d1z";
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files ( *png, *jpg, *bmp) | *.png; *.jpg; *.bmp";
            openDialog.InitialDirectory = "C:\\Users\\PM\\Desktop";
            lokalizacja2 = openDialog.FileName.ToString();

            Nullable<bool> result = openDialog.ShowDialog();

            if (result == true)
            {
                lokalizacja2 = openDialog.FileName;
                Obraz1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(lokalizacja2);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Zasada_działania dd = new Zasada_działania();
            dd.ShowDialog();
        }

        static String odczyt_z_pliku(String path)
        {
            string s = File.ReadAllText(path, Encoding.Default);
            return s;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string path = dlg.FileName;
                tekst.Text = odczyt_z_pliku(path);
            }
        }
    }
}
