using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektAkademia
{
    class Road
    {
        public List<Point> RoadPoints;
        public Road()
        {
            RoadPoints = new List<Point>();
        }
        public Point InitializationPointForElement(Random rand)
        {
            try
            {
                return RoadPoints[rand.Next(RoadPoints.Count - 1)];
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Droga nie istnieje");
                return new Point(0, 0);
            }
            

        }
        public Point NextPoint(Figure element)
        {
            int index = RoadPoints.IndexOf(element.Destination);
            if (element.DirectionOnTheRoad == Direction.forward) index++;
            else index--;

            if (index >= RoadPoints.Count)
            {
                element.DirectionOnTheRoad = Direction.backward;
                index = RoadPoints.Count-1;
            }
            if (index < 0)
            {
                element.DirectionOnTheRoad = Direction.forward;
                index = 0;
            }
            
            return RoadPoints.ElementAt(index);
        }
    }
}
