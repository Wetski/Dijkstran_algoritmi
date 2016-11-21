/*
 * Copyright 2016 Veeti Karttunen, Niki Liuhanen, Aaro Lyytinen
 *
 * This is a part of Data structrures and Algorithms course assignment
 * and is licensed under MIT license, see LICENSE file.
 *
 * Created: 21.11.2016
 */
using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            
            int[,] Matriisi = new int[10, 10];
            Matriisi[0, 1] = 10;
            Matriisi[0, 2] = 15;
            Matriisi[0, 9] = 67;
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
            Matriisi[3, 8] = 11;
            Matriisi[4, 1] = 16;
            Matriisi[4, 2] = 24;
            Matriisi[4, 3] = 12;
            Matriisi[4, 7] = 19;
            Matriisi[5, 2] = 45;
            Matriisi[5, 6] = 11;
            Matriisi[5, 7] = 18;
            Matriisi[5, 9] = 49;
            Matriisi[6, 2] = 15;
            Matriisi[6, 5] = 11;
            Matriisi[6, 7] = 21;
            Matriisi[7, 2] = 45;
            Matriisi[7, 4] = 19;
            Matriisi[7, 5] = 18;
            Matriisi[7, 6] = 21;
            Matriisi[7, 8] = 13;
            Matriisi[8, 3] = 11;
            Matriisi[8, 7] = 13;
            Matriisi[9, 0] = 67;
            Matriisi[9, 5] = 49;
            /*
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
            Matriisi[4, 3] = 1; */
            /*
            char[] name = new char[3];
            for (int i = 0; i < 10; i++)
            {
                
                name[i]++;
            }*/

            Graph graafi = new Graph(2500);
            timer.Start();
            Dijkstra Algoritmi = new Dijkstra(graafi.Matriisi, 0, 7);
            /*
            for (int i = 0; i < Math.Sqrt(graafi.Matriisi.Length); i++)
            {
                Algoritmi.Start = i;
                Algoritmi.Calculate();
                Console.WriteLine("{0}: {1}",i, timer.ElapsedMilliseconds);
            }*/
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
