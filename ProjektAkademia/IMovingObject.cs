using System.Windows;
using System.Windows.Controls;

namespace ProjektAkademia
{
    interface IMovingObject
    {
        void move(double timeInterval, Canvas Pole);  
    }
}
