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
using System.Windows.Threading;

namespace ProjektAkademia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer(); // timer object
        List<Figure> myElements = new List<Figure>();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(50); // update 20 times/second
            timer.Tick += TimerTick;
            timer.Start();

        }
        private void TimerTick(object sender, EventArgs e)
        {
            // movement in one interval

            // update position
            foreach (var element in myElements)
            {
                element.move(timer.Interval.TotalSeconds,this.Pole);
            }
            Pole.UpdateLayout();
            
            //Canvas.SetLeft()
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random(DateTime.Now.Ticks.GetHashCode());
            for (int i = 0; i < 500; i++)
            {
                myElements.Add(new Prostokat(rand));
                myElements.Last<Figure>().Speed = new Point(rand.Next(200), rand.Next(200));
                this.Pole.Children.Add(myElements.Last<Figure>().Show());
                myElements.Add(new Circle(rand));
                myElements.Last<Figure>().Speed = new Point(rand.Next(200), rand.Next(200));
                this.Pole.Children.Add(myElements.Last<Figure>().Show());
            }
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Pole.Width = this.Width - 140;
            this.Pole.Height = this.Height-60;
        }

        private void Pole_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
               
                Random rand = new Random();
                Point position = new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y);
                myElements.Add(new Prostokat(rand, position));
                this.Pole.Children.Add(myElements.Last<Figure>().Show());
                Pole.UpdateLayout();
            }
            if(e.RightButton == MouseButtonState.Pressed)
            {
                Point position = new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y);
                if(myElements.Count != 0)
                {
                    foreach (var element in myElements)
                    {
                        element.Speed = (position - element.Position) ;
                    }
                }
            }
        }
    }
}
