using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace ProjektAkademia
{
    

    class Figure
    {
        public Shape me;
        public Point Position;
        public Point Speed;
        public SolidColorBrush solidColorBrush { get; set; }

        protected void updatePosition()
        {
            Canvas.SetLeft(this.me, this.Position.x);
            Canvas.SetTop(this.me, this.Position.y);
        }
        public void move(double timeInterval, Canvas Pole)
        {
            if (this.Speed.x == 0 & this.Speed.y == 0) return;
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

    }
}
