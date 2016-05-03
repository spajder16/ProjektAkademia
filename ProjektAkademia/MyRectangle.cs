using System;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ProjektAkademia
{
    class MyRectangle: Figure
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
        
    }
}
