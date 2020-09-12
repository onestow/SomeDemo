using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenShotApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Point pStart, pEnd;
        Bitmap ScreenSnapshot;
        public MainWindow()
        {
            InitializeComponent();
            ScreenSnapshot = GetScreenSnapshot();
            canvas.Background = new ImageBrush(ToBitmapSource(ScreenSnapshot));
            var screenRect = SystemInformation.VirtualScreen;
            this.Left = screenRect.X;
            this.Top = screenRect.Y;
            this.Width = screenRect.Width;
            this.Height = screenRect.Height;
        }

        public Bitmap GetScreenSnapshot()
        {
            var rect = SystemInformation.VirtualScreen;
            var bitmap = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(bitmap))
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
            return bitmap;
        }

        public BitmapSource ToBitmapSource(Bitmap bmp)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
                this.Close();
            else if (e.LeftButton == MouseButtonState.Pressed)
            {
                pStart = e.GetPosition(this);
                pEnd = pStart;
            }
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                hint.Visibility = Visibility.Collapsed;
                pEnd = e.GetPosition(this);
                Mask.Rect = GetMouseMoveRect();
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var rect = GetMouseMoveRect();
            if (rect.Width < 3 || rect.Height < 3)
            {
                hint.Visibility = Visibility.Visible;
                Mask.Rect = new Rect();
                return;
            }

            var srcRect = new RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
            var destRect = new RectangleF(0, 0, srcRect.Width, srcRect.Height);
            using (var bmp = new Bitmap((int)rect.Width, (int)rect.Height))
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(ScreenSnapshot, destRect, srcRect, GraphicsUnit.Pixel);
                System.Windows.Forms.Clipboard.SetImage(bmp);
            }
            this.Close();
        }


        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void Grid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (hint.Visibility == Visibility.Visible)
            {
                var mousePos = e.GetPosition(this);
                Canvas.SetLeft(hint, mousePos.X + 10);
                Canvas.SetTop(hint, mousePos.Y + 10);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ScreenSnapshot?.Dispose();
        }

        private Rect GetMouseMoveRect()
        {
            var x = Math.Min(pStart.X, pEnd.X);
            var y = Math.Min(pStart.Y, pEnd.Y);
            var w = Math.Abs(pStart.X - pEnd.X);
            var h = Math.Abs(pStart.Y - pEnd.Y);
            return new Rect(x, y, w, h);
        }
    }
}
