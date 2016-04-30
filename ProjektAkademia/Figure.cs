using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace ProjektAkademia
{


    class Figure : IDrawingObject
    {
        
        public Shape me { get; set; }
        public Point Position { get; set; }
        public Point Speed { get; set; }
        protected Point _destination;
        public Point Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
                MovingToDestination = true;
            }
        }

        protected bool MovingToDestination;
        public bool OnRoad { get; set; }
        public bool DestinationAchieved { get; set; }
        public Direction DirectionOnTheRoad;

        public SolidColorBrush solidColorBrush { get; set; }

        protected void updatePosition()
        {
            Canvas.SetLeft(this.me, this.Position.x);
            Canvas.SetTop(this.me, this.Position.y);
        }
        public void GoToTheDestination(double timeInterval, Canvas Pole, Point Destination)
        {
            
            this.Destination = Destination;
            if (this.OnRoad)
            {
                Random rand = new Random((int)this.Position.x);
                this.Speed = (Destination - Position)*(rand.Next(1000)/100+1);
            }
            else this.Speed = (Destination - Position);
            this.DestinationAchieved = false;
        }
        public void move(double timeInterval, Canvas Pole)
        {
            if (this.Speed.x == 0 & this.Speed.y == 0) return;
            if (this.MovingToDestination == true)
            {
                int Precision = 10;
                if (  Position.x < Destination.x + Precision
                    & Position.x > Destination.x - Precision
                    & Position.y < Destination.y + Precision
                    & Position.y > Destination.y - Precision)
                {
                    this.Speed = new Point(0, 0);
                    this.MovingToDestination = false;
                    this.DestinationAchieved = true;
                    return;
                }
            }
            double Height = Pole.Height;
            double widht = Pole.Width;
            double x = this.Position.x + this.Speed.x * timeInterval;
            double y = this.Position.y + this.Speed.y * timeInterval;
            if (x < 0)
            {
                x = -this.Speed.x * timeInterval;
                this.Speed.x = -this.Speed.x;
            }
            if (x > widht)
            {
                x = widht - this.Speed.x * timeInterval;
                this.Speed.x = -this.Speed.x;
            }
            if (y < 0)
            {
                y = -this.Speed.y * timeInterval;
                this.Speed.y = -this.Speed.y;
            }
            if (y > Height)
            {
                y = Height - this.Speed.y * timeInterval;
                this.Speed.y = -this.Speed.y;
            }
            this.Position = new Point(x, y);
            updatePosition();
        }
        public UIElement Show()
        {
            return me;
        }
        public void ReleaseFormDestination()
        {
            MovingToDestination = false;
            OnRoad = false;
            DestinationAchieved = true;
        }
        public void UpDateSpeed()
        {
            Random rand = new Random((int)this.Position.x);
            this.Speed = (Destination - Position)*2 ;
        }

    }
}
