using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (FileStream stream = File.OpenRead("задача3.txt"))
            {                
                int[] array = new int[stream.Length];
                int j,i,t;
                for (i = 0; i < array.Length; i++)
                {
                    array[i] = stream.ReadByte();//Передача содержимого файла в массив
                }
                for ( i = 0; i < array.Length; i++)
                {
                    for (j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            t = array[i];
                        array[i] = array[j];
                        array[j] = t;
                        }                        
                    }
                }  
                int sum = 0;                
                int max = 1;
                for (i = 0; i < array.Length; i++)
                {
                    if (sum + array[i] <= 8200)//Проверяем есть ли место на диске
                    {
                        sum += array[i];//Складываем файлы
                        max = i;//Запоминаем их место в массиве
                    }
                }
                t = array[max];//Запоминаем максимальный элемент
                for (i=max;i<array.Length; i++)
                {
                    if (sum - t + array[i]<=8200)
                    {
                        sum = sum - t + array[i];
                        t = array[i];
                    }
                }                    
                textBox1.Text =max+" "+t;
            }
            
        }
    }
}
