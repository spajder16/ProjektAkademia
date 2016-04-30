using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
