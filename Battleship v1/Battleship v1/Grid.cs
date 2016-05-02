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
        protected int m { get; set; }
        public Grid ()
        {
            grid = new int[8,8];
            Random rand = new Random();
            m = rand.Next(1, 4);
            String input = File.ReadAllText(@"..\..\Resources\Matrixes\m" + m + ".txt");
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
        public Grid(bool check)
        {
            grid = new int[8, 8];
            for(int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    grid[i, j] = 0;
                }
            }
        }
        public Grid(int m)
        {
            grid = new int[8, 8];
            Random rand = new Random();
            int[] seq = Enumerable.Range(1, 3).ToArray();
            List<int> possible = new List<int>();
            for (int num=0; num < seq.Length; num++)
            {
                if (seq[num] != m) possible.Add(seq[num]);
            }
            String input = File.ReadAllText(@"..\..\Resources\Matrixes\m" + possible.ElementAt(rand.Next(0, possible.Count)) + ".txt");
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
            if (rand.Next(0, 2) == 1)
            {
                for (i = 0; i < 8; i++)
                {
                    for (j = i + 1; j < 8; j++)
                    {
                        int temp = grid[i, j];
                        grid[i, j] = grid[j, i];
                        grid[j, i] = temp;
                    }
                }
            }
        }
        public int get (int i, int j)
        {
            return grid[i-1,j-1];
        }
        public void set(int i, int j, int val)
        {
            grid[i - 1, j - 1] = val;
        }
        public int getM ()
        {
            return m;
        }

    }
}
