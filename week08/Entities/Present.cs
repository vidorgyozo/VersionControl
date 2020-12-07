using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entities
{
    class Present : Toy
    {
        public SolidBrush RibbonColor { get; set; }
        public SolidBrush BoxColor { get; set; }

        public Present(Color ribbon, Color box)
        {
            RibbonColor = new SolidBrush(ribbon);
            BoxColor = new SolidBrush(box);
        }

        protected override void DrawImage(Graphics graphics)
        {
            Rectangle box = new Rectangle(0, 0, Width, Height);
            graphics.FillRectangle(BoxColor, box);

            Rectangle ribbonV = new Rectangle((int)(Width * ((double)2 / 5)), 0, (int)(Width/(double)5), Height);
            graphics.FillRectangle(RibbonColor, ribbonV);
            Rectangle ribbonH = new Rectangle(0, (int)(Height * ((double)2 / 5)), Width, (int)(Height / (double)5));
            graphics.FillRectangle(RibbonColor, ribbonH);
        }
    }
}
