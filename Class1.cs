using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class Kletka
    {
        int size, sum;
        bool[,] pop;

        public Kletka(int sum, int size)
        {
            this.size = size;
            this.sum = sum;
            pop = new bool[size, size];
            Colony();
        }

        public int SUM
        {
            get { return sum; }
        }

        public int SIZE
        {
            get { return size; }
        }

        public bool this[int x, int y]
        {
            get { return pop[x, y]; }
            set { pop[x, y] = value; }
        }
        
        public bool[,] Pop 
        {
            get { return pop;}
            set { pop = value; }
        }

        void Colony()
        {

            int x, y, count = 0;

            Random rnd = new Random();
            if (sum>= size * size)
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        pop[i, j] = true;
                    }
            }
            else
            {
                while (count < sum)
                {
                    x = rnd.Next(size);
                    y = rnd.Next(size);
                    if (pop[x, y] != true)
                    {
                        pop[x, y] = true;
                        count++;
                    }
                };
            }
        }

        public int Neigh(int x, int y)
         {
             int nb = 0;
             if (this.pop[check(x - 1), check(y - 1)] == true) nb++;
             if (this.pop[check(x-1), check(y)] == true) nb++;
             if (this.pop[check(x - 1), check(y + 1)] == true) nb++;
             if (this.pop[check(x), check(y-1)] == true) nb++;
             if (this.pop[check(x), check(y + 1)] == true) nb++;
             if (this.pop[check(x + 1), check(y-1)] == true) nb++;
             if (this.pop[check(x + 1), check(y)] == true) nb++;
             if (this.pop[check(x + 1), check(y+1)] == true) nb++;
             return nb;
         }

        int check(int koord)
        {
            int k=koord;
            if (koord < 0) k = size - 1;
            if (koord > size - 1) k = 0;
            return k;
        }

       public void Print( DataGridView dgv)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.pop[i, j] == true)
                    {
                        dgv.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Green;
                    }
                }
            }
        }

       public void CleanDgv(DataGridView dgv)
       {
           for (int i = 0; i < dgv.RowCount; i++)
           {
               for (int j = 0; j < dgv.ColumnCount; j++)
               {
                   dgv.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
               }
           }
       }

        public void ReColorDgv(DataGridView dgv, int x, int y)
        {
            dgv.Rows[x].Cells[y].Style.BackColor = System.Drawing.Color.White;
        }

        public int AliveCells()
        {
            int c = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.pop[i, j] == true)
                    {
                        c++;
                    }
                }
            }
            return c;
        }

    }
}
