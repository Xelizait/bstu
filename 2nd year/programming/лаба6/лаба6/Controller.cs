using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5;
using lan6;

namespace lan6
{
  

     partial class Controller
    {
        
        public static int FindTheBiggest(List<Figure> figures)
        {
            int biggest, index = 0;
            biggest = figures[0].FigureArea;
            for (int i = 1; i < figures.Count; i++)
            {
                if (biggest < figures[i].FigureArea)
                {
                    biggest = figures[i].FigureArea;
                    index = i;
                }
            }
            return index;    
        }

        public static int FindTotal(List<Figure> figures)
        {
            int total = 0;
            total = figures[0].FigureArea;
            for (int i = 1; i < figures.Count; i++)
            {
                total = total + figures[i].FigureArea;                
            }
            return total;
        }



    }
}
