using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int[,] Matriisi = new int[8, 8];
            Matriisi[0, 1] = 10;
            Matriisi[0, 2] = 15;
            Matriisi[1, 0] = 10;
            Matriisi[1, 3] = 17;
            Matriisi[1, 4] = 16;
            Matriisi[2, 0] = 15;
            Matriisi[2, 4] = 24;
            Matriisi[2, 5] = 45;
            Matriisi[2, 6] = 15;
            Matriisi[2, 7] = 45;
            Matriisi[3, 1] = 17;
            Matriisi[3, 4] = 12;
            Matriisi[4, 1] = 16;
            Matriisi[4, 2] = 24;
            Matriisi[4, 3] = 12;
            Matriisi[4, 7] = 19;
            Matriisi[5, 2] = 45;
            Matriisi[5, 6] = 11;
            Matriisi[5, 7] = 19;
            Matriisi[6, 2] = 15;
            Matriisi[6, 5] = 11;
            Matriisi[6, 7] = 21;
            Matriisi[7, 2] = 45;
            Matriisi[7, 4] = 19;
            Matriisi[7, 5] = 19;
            Matriisi[7, 6] = 21; */
            int[,] Matriisi = new int[5, 5];
            Matriisi[0, 1] = 6;
            Matriisi[0, 3] = 1;
            Matriisi[1, 0] = 6;
            Matriisi[1, 2] = 5;
            Matriisi[1, 3] = 2;
            Matriisi[1, 4] = 2;
            Matriisi[2, 1] = 5;
            Matriisi[2, 4] = 5;
            Matriisi[3, 0] = 1;
            Matriisi[3, 1] = 2;
            Matriisi[3, 4] = 1;
            Matriisi[4, 1] = 2;
            Matriisi[4, 2] = 5;
            Matriisi[4, 3] = 1;
            Dijkstra Algoritmi = new Dijkstra(Matriisi, 2);
            Algoritmi.Calculate();
        }
    }
}
