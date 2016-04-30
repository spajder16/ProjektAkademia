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

    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer timer2;

        List<Figure> myElements;
        Road myRoad;

        Random rand;

        public MainWindow()
        {
            InitializeComponent();
            InitVariables();
            this.timer.Interval = TimeSpan.FromMilliseconds(25);
            this.timer.Tick += TimerTick;
            this.timer.Start();
            this.timer2.Interval = TimeSpan.FromMilliseconds(5);
            this.timer2.Tick += TimerTick2;

            this.AddingOptionscomboBox.ItemsSource = Enum.GetValues(typeof(AddingOptions));
            this.AddingOptionscomboBox.SelectedIndex = 0;
        }
        public void InitVariables()
        {
            this.timer = new DispatcherTimer();
            this.timer2 = new DispatcherTimer();

            myElements = new List<Figure>();
            myRoad = new Road();

            this.rand = new Random(DateTime.Now.Ticks.GetHashCode());
        }
        private void TimerTick(object sender, EventArgs e)
        {
            foreach (var element in myElements)
            {
                if (element.OnRoad == true & element.DestinationAchieved == true)
                {
                    Point newDestination = myRoad.NextPoint(element);
                    element.GoToTheDestination(timer.Interval.TotalSeconds, Pole, newDestination);

                }
                else if (element.OnRoad) element.UpDateSpeed();
                element.move(timer.Interval.TotalSeconds, this.Pole);
            }
        }

        private void TimerTick2(object sender, EventArgs e)
        {
            myRoad.RoadPoints.Add(new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y));
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 500; i++)
            {
                myElements.Add(new MyRectangle(rand));
                myElements.Last<Figure>().Speed = new Point(rand.Next(200), rand.Next(200));
                this.Pole.Children.Add(myElements.Last<Figure>().Show());
                myElements.Add(new MyCircle(rand));
                myElements.Last<Figure>().Speed = new Point(rand.Next(200), rand.Next(200));
                this.Pole.Children.Add(myElements.Last<Figure>().Show());
            }

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Pole.Width = this.Width - 190;
            this.Pole.Height = this.Height - 60;
        }

        private void Pole_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddingOptions addingOption = (AddingOptions)Enum.Parse(typeof(AddingOptions), this.AddingOptionscomboBox.Text);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (addingOption == AddingOptions.Road)
                {
                    foreach (var element in myElements)
                    {
                        element.ReleaseFormDestination();
                    }
                    timer2.Start();
                    myRoad.RoadPoints.Clear();
                    List<Line> toRemove = new List<Line>();
                    foreach (var o in Pole.Children)
                    {
                        if (o is Line)
                            toRemove.Add((Line)o);
                    }
                    for (int i = 0; i < toRemove.Count; i++)
                    {
                        Pole.Children.Remove(toRemove[i]);
                    }

                }
                if (addingOption == AddingOptions.Rectangle)
                {

                    Point position = new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y);
                    myElements.Add(new MyRectangle(rand, position));
                    this.Pole.Children.Add(myElements.Last<Figure>().Show());

                }
                if (addingOption == AddingOptions.Circle)
                {

                    Point position = new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y);
                    myElements.Add(new MyCircle(rand, position));
                    this.Pole.Children.Add(myElements.Last<Figure>().Show());

                }
                if (addingOption == AddingOptions.Swarm)
                {

                    for (int i = 0; i < 50; i++)
                    {
                        Point position = new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y);
                        myElements.Add(new MyRectangle(rand, position));
                        this.Pole.Children.Add(myElements.Last<Figure>().Show());
                    }


                }

            }
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Point position = new Point(Mouse.GetPosition(this.Pole).X, Mouse.GetPosition(this.Pole).Y);
                if (myElements.Count != 0)
                {
                    foreach (var element in myElements)
                    {
                        if (!element.OnRoad) element.GoToTheDestination(timer.Interval.TotalSeconds, this.Pole, position);
                    }
                }
            }
            if (e.MiddleButton == MouseButtonState.Pressed)
            {

                    foreach (var element in myElements)
                    {
                        element.Speed = new Point(rand.Next(1000) - rand.Next(1000), rand.Next(1000) - rand.Next(1000));
                    }
               
            }
        }

        private void Pole_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AddingOptions addingOption = (AddingOptions)Enum.Parse(typeof(AddingOptions), this.AddingOptionscomboBox.Text);
            if (addingOption == AddingOptions.Road & e.ChangedButton == MouseButton.Left)
            {
                timer2.Stop();
                for (int i = 0; i < myRoad.RoadPoints.Count - 1; i++)
                {
                    Line myLine = new Line();
                    myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                    myLine.X1 = myRoad.RoadPoints.ElementAt<Point>(i).x;
                    myLine.X2 = myRoad.RoadPoints.ElementAt<Point>(i + 1).x;
                    myLine.Y1 = myRoad.RoadPoints.ElementAt<Point>(i).y;
                    myLine.Y2 = myRoad.RoadPoints.ElementAt<Point>(i + 1).y;

                    Pole.Children.Add(myLine);
                }
                foreach (var element in myElements)
                {
                    element.GoToTheDestination(timer.Interval.TotalSeconds, Pole, myRoad.InitializationPointForElement(rand));
                    element.OnRoad = true;
                    element.DestinationAchieved = false;
                }

            }

        }

        private void deleteAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.Pole.Children.Clear();
            this.myElements.Clear();
            this.myRoad.RoadPoints.Clear();

        }

        private void deleteRoadButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in myElements)
            {
                element.ReleaseFormDestination();
            }
            myRoad.RoadPoints.Clear();
            List<Line> toRemove = new List<Line>();
            foreach (var o in Pole.Children)
            {
                if (o is Line)
                    toRemove.Add((Line)o);
            }
            for (int i = 0; i < toRemove.Count; i++)
            {
                Pole.Children.Remove(toRemove[i]);
            }
        }
    }
}
