using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class PolygonListChangedEventArgs
    {
        public PolygonListChangedEventArgs(MyPolygon pol, PolygonCanvas canvas)
        {
            this.P = pol;
            this.Canvas = canvas;
        }

        public MyPolygon P { get; set; }

        public PolygonCanvas Canvas { get; set; }
    }
}
