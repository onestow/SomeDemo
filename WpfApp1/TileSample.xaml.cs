using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// TileSample.xaml 的交互逻辑
    /// </summary>
    public partial class TileSample : UserControl
    {
        public TileSample()
        {
            InitializeComponent();
        }
    }

    public class TilesViewModel
    {
        public List<TileModel> Tiles { get; set; }

        public TilesViewModel()
        {
            var images = new ImageSource[]
            {
                new BitmapImage(new Uri("/Resources/Images/calendar(1).png", UriKind.Relative)),
                new BitmapImage(new Uri("/Resources/Images/checklist.png", UriKind.Relative)),
                new BitmapImage(new Uri("/Resources/Images/folder.png", UriKind.Relative)),
            };

            Tiles = new List<TileModel>
            {
                new TileModel() { Header = "Header1", Images = images.Take(2).ToList()},
                new TileModel() { Header = "Header2", Images = images.Skip(2).Take(1).ToList()},
            };
        }
    }

    public class TileModel
    {
        public IEnumerable<ImageSource> Images { get; set; }
        public string Header { get; set; }
    }
}
