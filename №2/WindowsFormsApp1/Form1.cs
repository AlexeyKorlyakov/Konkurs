using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double max;
            double min;
            double sred;
            int sudya = random.Next(3, 10);
            int figurist = Convert.ToInt32(textBox1.Text);
            
            double[,] a = new double[figurist, sudya+1];
            Random rnd = new Random();            
            dataGridView1.RowCount = figurist;
            dataGridView1.ColumnCount = sudya+1;
            for (int i = 0; i < figurist; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                sred = 0;
                max = 0;
                min = 10;
                for (int j = 0; j < sudya; j++)
                {

                    dataGridView1.Columns[j].HeaderCell.Value = (j + 1).ToString();

                    a[i, j] = rnd.NextDouble()*10;//Оценки
                     
                    dataGridView1[j, i].Value =Math.Round( a[i, j],1).ToString();
                    if (max < a[i, j])
                    {
                        max = a[i, j];//максимальный
                    }
                    if (min> a[i, j])
                    {
                        min = a[i, j];//минимальный
                    }
                    sred += a[i, j];
                }
                sred = sred - max - min;//Среднее арфиметическое
                sred = sred / sudya;
                dataGridView1[sudya,i].Value=Math.Round( sred,1);
            }
           
        
        } 
    }
}
