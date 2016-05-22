using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProjektAkademia
{
    class MyCircle : Figure, IMovingObject
    {

        public MyCircle(Random rand)
        {
            me = new Ellipse();
            this.Position = new Point(10, 10);

            Init(rand);
        }
        public MyCircle(Random rand, Point position)
        {
            me = new Ellipse();
            this.Position = position;

            Init(rand);
        }

        public override void move(double timeInterval, Canvas Pole)
        {
            if (this.Speed.x == 0 & this.Speed.y == 0) return;
            if (this.MovingToDestination == true)
            {
                int Precision = 10;
                if (Position.x < Destination.x + Precision
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

            Random rand = new Random((int)Position.x);
            int factor = rand.Next(100);

            if (x < 0)
            {
                x = -this.Speed.x * timeInterval;
                if (rand.Next(1) == 1) this.Speed.x = -this.Speed.x + factor;
                else this.Speed.x = -this.Speed.x - factor;
                if (rand.Next(1) == 1) this.Speed.y += factor;
                else this.Speed.y -= factor;
            }
            if (x > widht)
            {
                x = widht - this.Speed.x * timeInterval;
                if (rand.Next(1) == 1) this.Speed.x = -this.Speed.x + factor;
                else this.Speed.x = -this.Speed.x - factor;
                if (rand.Next(1) == 1) this.Speed.y += factor;
                else this.Speed.y -= factor;
            }
            if (y < 0)
            {
                y = -this.Speed.y * timeInterval;
                if (rand.Next(1) == 1) this.Speed.y = -this.Speed.y + factor;
                else this.Speed.y = -this.Speed.y - factor;
                if (rand.Next(1) == 1) this.Speed.x += factor;
                else this.Speed.x -= factor;
            }
            if (y > Height)
            {
                y = Height - this.Speed.y * timeInterval;
                if (rand.Next(1) == 1) this.Speed.y = -this.Speed.y + factor;
                else this.Speed.y = -this.Speed.y - factor;
                if (rand.Next(1) == 1) this.Speed.x += factor;
                else this.Speed.x -= factor;
            }

            this.Position = new Point(x, y);
            updatePosition();
        }


    }
}
