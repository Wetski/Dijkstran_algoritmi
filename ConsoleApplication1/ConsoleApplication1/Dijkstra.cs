﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dijkstra
    {
        public int[,] Matriisi { get; set; }
        private int[] visited, distance, via, indexes;
        private int start, current;
        private bool finished;

        public Dijkstra(int[,] matriisi, int s)
        {
            finished = false;
            start = s;
            current = start;
            Matriisi = matriisi;
            visited = new int[(int)Math.Sqrt(matriisi.Length)];
            distance = new int[(int)Math.Sqrt(matriisi.Length)];
            via = new int[(int)Math.Sqrt(matriisi.Length)];
            indexes = new int[(int)Math.Sqrt(matriisi.Length)];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = -1;
                via[i] = -1;
            }
        }
        public void Calculate()
        {
            int[] tdistance = new int[(int)Math.Sqrt(Matriisi.Length)];
            int round = 0;
            while (finished != true)
            {
                if (current == start)
                {
                    distance[current] = 0;
                    via[current] = -1;
                }
                for (int i = 0; i < distance.Length; i++)
                {
                    if (Matriisi[current, i] != 0 && Matriisi[current, i] + distance[current] < distance[i])
                    {
                        distance[i] = distance[current] + Matriisi[current, i];
                        via[i] = current;
                    }
                }
                tdistance = (int[])distance.Clone();
                Array.Sort(tdistance);
                visited[round] = current;
                for (int i = 0; i < tdistance.Length; i++)
                {
                    int former = current;
                    for (int j = 0; j < tdistance.Length; j++)
                    {
                        indexes[j] = -1;
                        if (distance[j] == tdistance[i]) { indexes[j] = j; }
                    }
                    foreach (int value in indexes)
                    {
                        if (tdistance[i] >= distance[current] && Array.IndexOf(visited, value) == -1 && value != -1)
                        {
                            current = value;
                            break;
                        }
                    }
                    if (former != current) { break; }
                }
                if (Array.FindIndex(visited, item => item == -1) == -1) { finished = true; }
                round++;
            }
            Console.WriteLine("Vertex:  Distance:   Via:");
            Console.WriteLine("---------------------------");
            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write(" {0}         ", i);
                Console.Write("{0}          ", distance[i]);
                if (via[i] == -1) { Console.WriteLine(" "); }
                else { Console.WriteLine(via[i]); }
                Console.WriteLine("---------------------------");
            }
            Console.Read();
        }
    }
}
