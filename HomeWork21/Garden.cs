using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork21
{
    public class Garden
    {
        public bool Gardener1_Status { get; set; }      //логическая переменная, сигнализирующая о завершении работы 1-м садовником
        public bool Gardener2_Status { get; set; }      //логическая переменная, сигнализирующая о завершении работы 2-м садовником
        public char[,] District { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public Garden(int length, int width)
        {
            Length = length;
            Width = width;
            District = new char[length, width];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    District[i, j] = '.';
                }
            }
            Gardener1_Status = false;
            Gardener2_Status = false;
        }
        public void Gardener1(object speed)     //садовник 1
        {            
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (District[i, j] == '.')
                    {
                        District[i, j] = '$';
                        Thread.Sleep((int)speed);
                    }
                }
            }
            Gardener1_Status = true;
        }
        public void Gardener2(object speed)     //садовник 2
        {            
            for (int j = Width - 1; j >= 0; j--)
            {
                for (int i = Length - 1; i >= 0; i--)
                {
                    if (District[i, j] == '.')
                    {
                        District[i, j] = '*';
                        Thread.Sleep((int)speed);
                    }
                }
            }
            Gardener2_Status = true;
        }
    }
}
