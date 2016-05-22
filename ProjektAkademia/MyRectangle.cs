using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ProjektAkademia
{
    class MyRectangle: Figure, IMovingObject
    {
        public MyRectangle(Random rand)
        {
            me = new Rectangle();
            this.Position = new Point(10, 10);

            Init(rand);
        }
        public MyRectangle(Random rand, Point position)
        {
            me = new Rectangle();
            this.Position = position;

            Init(rand);
        }

        public override void move(double timeInterval, Canvas Pole)
        {
            base.move(timeInterval, Pole);
        }

    }
}
