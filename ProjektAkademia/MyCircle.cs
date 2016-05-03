using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProjektAkademia
{
    class MyCircle: Figure
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
    }
}
