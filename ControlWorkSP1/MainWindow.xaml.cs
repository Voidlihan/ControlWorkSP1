using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ControlWorkSP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Uri iconUri = new Uri("https://icons-for-free.com/download-icon-chat+im+message+messages+slack+thread+icon-1320162256476057785_512.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }

        private void Save(object sender, RoutedEventArgs e)
        {   
            if(string.IsNullOrWhiteSpace(textBoxPeriod.Text))
            {
                MessageBox.Show("Ничего не введено!");
                if(!int.TryParse(textBoxPeriod.Text, out var time)) {
                    MessageBox.Show("Неправильный ввод, задайте минуту в числах!");
                }
                else
                {
                    ThreadPool.GetAvailableThreads(out int threads, out int ports);
                    Timer timer = new Timer(Screen, null, TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(Convert.ToDouble(textBoxPeriod.Text)));                    
                }
            }
        }
        private void Screen(object state)
        {
            double screenLeft = SystemParameters.VirtualScreenLeft;
            double screenTop = SystemParameters.VirtualScreenTop;
            double screenWidth = SystemParameters.VirtualScreenWidth;
            double screenHeight = SystemParameters.VirtualScreenHeight;
            using (Bitmap bmp = new Bitmap((int)screenWidth, (int)screenHeight))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    String filename = "ScreenCapture-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";
                    Opacity = .0;
                    g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);
                    bmp.Save("C:\\Users\\ЕсентайА\\Pictures\\ControlWorkSP1" + filename);
                    Opacity = 1;
                }
            }
        }
    }
}
