using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn2.Enabled = false;
            btn3.Enabled = false;
        }

        Kletka colony1;
        Kletka colony2;
        int n, amount;

        private void button1_Click(object sender, EventArgs e)
        {
            input();
            dgvsize();
            colony1.Print(dgv1);
           // life();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn1.Enabled = false;
            tb1.Enabled = false;
            tb2.Enabled = false;
            button1.Enabled = true;
            colony2.CleanDgv(dgv2);
            life();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btn1.Enabled = true;
            button1.Enabled = false;
            btn3.Enabled = false;
            tb1.Enabled = true;
            tb2.Enabled = true;
            colony1.CleanDgv(dgv1);
            colony2.CleanDgv(dgv2);
            input();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn4.Enabled = true;
            timer1 = new Timer(); // опять создаем новый таймер (не забудем про визуальный компонент
            timer1.Interval = 1000; //ставим интервал события
            timer1.Tick += btn2_Click;     //Создаем событие
            timer1.Enabled = true;	//включаем таймер
    }

        public void life()
        {
            colony2.Pop = (bool[,]) colony1.Pop.Clone();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int neigh = colony1.Neigh(i,j);
                    if (neigh == 2)
                    {
                        colony2[i, j] = colony1[i, j];
                        continue;
                    }
                    else
                    { 
                        if (neigh > 3 || neigh <= 1)
                    {
                        colony2[i, j] = false;
                        continue;
                    }
                    else
                    {
                        if (neigh == 3)
                        {
                            colony2[i, j] = true;
                            continue;
                        }
                    }
                    }
                }
            }
            
            colony2.Print(dgv2);
            colony1 = colony2;
          //  colony2 = new Kletka(0, colony1.SUM);
            
        }

        public void dgvsize()
        {
            dgv1.RowCount = n;
            dgv1.ColumnCount = n;
            dgv2.RowCount = n;
            dgv2.ColumnCount = n;
            dgv1.Rows[0].Cells[0].Selected = false;
            dgv2.Rows[0].Cells[0].Selected = false;
            dgv1.Height = 400;
            dgv1.Width = 400;
            dgv2.Height = 400;
            dgv2.Width = 400;
            dgv1.RowHeadersVisible = false;
            dgv1.ColumnHeadersVisible = false;
            dgv2.RowHeadersVisible = false;
            dgv2.ColumnHeadersVisible = false;

            int razmer = 400 / n;
            for (int i = 0; i < n; i++)
            {
                dgv1.Rows[i].Height = razmer;
            }
            for (int i = 0; i < n; i++)
            {
                dgv1.Columns[i].Width = razmer;
            }

            for (int i = 0; i < n; i++)
            {
                dgv2.Rows[i].Height = razmer;
            }
            for (int i = 0; i < n; i++)
            {
                dgv2.Columns[i].Width = razmer;
            }
        }

        public void input()
        {
            btn2.Enabled = true;
            btn3.Enabled = true;
            n = Convert.ToInt32(tb1.Text);//размерность поля
            amount = Convert.ToInt32(tb2.Text);//количество клеток
            colony1 = new Kletka(amount, n);
            colony2 = new Kletka(0, n);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
