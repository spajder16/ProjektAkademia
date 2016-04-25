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
        private DispatcherTimer timer2 = new DispatcherTimer();
        List<Figure> myElements = new List<Figure>();
        List<Point> myRoad = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(50); // update 20 times/second
            timer.Tick += TimerTick;
            timer.Start();
            timer2.Interval = TimeSpan.FromMilliseconds(10); // update 20 times/second
            timer2.Tick += TimerTick2;
            

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

        private void TimerTick2(object sender, EventArgs e)
        {
            // movement in one interval

            // update position
            myRoad.Add(new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y));

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
                timer2.Start();
                myRoad.Clear();
                
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
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                if (myElements.Count != 0)
                {
                    Random rand = new Random(2);
                    foreach (var element in myElements)
                    {
                        element.Speed = new Point(rand.Next(1000), rand.Next(1000));
                    }
                }
            }
        }

        private void Pole_MouseUp(object sender, MouseButtonEventArgs e)
        {
            timer2.Stop();
            for (int i = 0; i < myRoad.Count-1; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                myLine.X1 = myRoad.ElementAt<Point>(i).x;
                myLine.X2 = myRoad.ElementAt<Point>(i+1).x;
                myLine.Y1 = myRoad.ElementAt<Point>(i).y;
                myLine.Y2 = myRoad.ElementAt<Point>(i+1).y;
                Pole.Children.Add(myLine);
            }
             
            Pole.UpdateLayout();
        }
    }
}
