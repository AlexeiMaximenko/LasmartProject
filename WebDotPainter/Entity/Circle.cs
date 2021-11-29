using System.Collections.Generic;
using WebDotPainter.Classes;

namespace WebDotPainter.Entity
{
    public class Circle : Figure
    {
        public int Radius { get; set; }
        public List<CircleComment> Comments { get; set; }
    }
}
