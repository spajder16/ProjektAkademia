using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace ProjektAkademia
{
    class Circle: Figure
    {

        public Circle(Random rand)
        {
            me = new Ellipse();
            this.me.Width = 10;
            this.me.Height = 10;
            this.solidColorBrush = new SolidColorBrush();
            this.solidColorBrush.Color = Color.FromArgb(255, (byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            this.me.Fill = this.solidColorBrush;
            this.Position = new Point(10, 10);
            this.Speed = new Point(0, 0);
        }
    }
}
