using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v1
{
    public class Grid
    {
        protected int [,] grid { get; set; }
        public Grid ()
        {
            grid = new int[8,8];
            Random rand = new Random();
            String input = File.ReadAllText(@"C:\Users\kate\Desktop\проект вп\Battleship v1\Battleship v1\Resources\Matrixes\m" + rand.Next(1,4) + ".txt");
            int i = 0, j = 0;
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    grid[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            if(rand.Next(0,2) == 1)
            {
                for (i = 0; i < 8; i++)
                {
                    for (j = i + 1; j < 8; j++)
                    {
                        int temp = grid[i,j];
                        grid[i,j] = grid[j,i];
                        grid[j,i] = temp;
                    }
                }
            }
        }
        public int get (int i, int j)
        {
            return grid[i-1,j-1];
        }

    }
}
