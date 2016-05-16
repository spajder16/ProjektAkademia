namespace ProjektAkademia
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point() { }
        public Point(double _x, double _y)
        {
            this.x = _x;
            this.y = _y;
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x & p1.y == p2.y);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.x != p2.x | p1.y != p2.y);
        }
        public static Point operator /(Point p1, double p2)
        {
            try
            {
                return new Point(p1.x / p2, p1.y / p2);
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine("Nie dzielimy przez 0");
                return new Point(0, 0);
            }
            
        }
        public static Point operator *(Point p1, double p2)
        {
            return new Point(p1.x * p2, p1.y * p2);
        }
        public static explicit operator System.Windows.Point(Point point)
        {
            System.Windows.Point temp = new System.Windows.Point(point.x, point.y);
            return temp;
        }
        public Point intParse()
        {   
            return new Point((int)this.x, (int)this.y);
        }
    }
}
