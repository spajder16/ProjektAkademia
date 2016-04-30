using System.Windows;
using System.Windows.Controls;

namespace ProjektAkademia
{
    interface IDrawingObject
    {
        void move(double timeInterval, Canvas Pole);
        UIElement Show();
    }
}
