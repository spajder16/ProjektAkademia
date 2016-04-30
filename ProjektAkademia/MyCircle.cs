using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace ProjektAkademia
{
    class MyCircle: Figure
    {

        public MyCircle(Random rand)
        {
            me = new Ellipse();
            this.me.Width = 10;
            this.me.Height = 10;
            this.solidColorBrush = new SolidColorBrush();
            this.solidColorBrush.Color = Color.FromArgb(255, (byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            this.me.Fill = this.solidColorBrush;
            this.Position = new Point(10, 10);
            this.Speed = new Point(0, 0);
            this.Destination = new Point(0, 0);
            this.MovingToDestination = false;
            this.OnRoad = false;
            this.DestinationAchieved = true;
            if (rand.Next(1) == 1) this.DirectionOnTheRoad = Direction.forward;
            else this.DirectionOnTheRoad = Direction.backward;
        }
        public MyCircle(Random rand, Point position)
        {
            me = new Ellipse();
            this.me.Width = 10;
            this.me.Height = 10;
            this.solidColorBrush = new SolidColorBrush();
            this.solidColorBrush.Color = Color.FromArgb(255, (byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            this.me.Fill = this.solidColorBrush;
            this.Position = position;
            this.Speed = new Point(0, 0);
            this.updatePosition();
            this.Destination = new Point(0, 0);
            this.MovingToDestination = false;
            this.OnRoad = false;
            this.DestinationAchieved = true;

            if (rand.Next(1) == 1) this.DirectionOnTheRoad = Direction.forward;
            else this.DirectionOnTheRoad = Direction.backward;

        }
    }
}
