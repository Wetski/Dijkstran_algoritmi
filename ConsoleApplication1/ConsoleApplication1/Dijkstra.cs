/*
 * Copyright 2016 Veeti Karttunen, Niki Liuhanen, Aaro Lyytinen
 *
 * This is a part of Data structrures and Algorithms course assignment
 * and is licensed under MIT license, see LICENSE file.
 *
 * Created: 21.11.2016
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Dijkstra
    {
        public int[,] Matriisi { get; set; }
        public int Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }
        private int[] visited, distance, via;
        private List<int> inde;
        private Stack<int> path;
        private int start, current;
        private bool finished;

        public Dijkstra(int[,] matriisi, int s, int target)
        {
            start = s;
            Matriisi = matriisi;
            visited = new int[(int)Math.Sqrt(matriisi.Length)];
            distance = new int[visited.Length];
            via = new int[visited.Length];
            inde = new List<int>();
            path = new Stack<int>();
            finished = false;
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = -1;
                via[i] = -1;
            }
            inde.Clear();
            current = start;
            int[] tdistance = new int[visited.Length];
            int round = 0;
            while (finished != true)
            {
                //Console.WriteLine(current);
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
                    inde.Clear();
                    int former = current;
                    for (int j = 0; j < distance.Length; j++)
                    {
                        if (distance[j] == tdistance[i])
                        {
                            inde.Add(j);
                        }
                    }
                    foreach (int value in inde)
                    {
                        if (tdistance[i] >= distance[current] && Array.IndexOf(visited, value) == -1 && value != -1)
                        {
                            current = value;
                            break;
                        }
                    }
                    if (former != current) { break; }
                }
                if (Array.IndexOf(visited, -1) == -1) { finished = true; }
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
            while(true)
            {
                path.Push(target);
                if(target == start)
                {
                    break;
                }
                target = via[target];
            }
            while(path.Count() != 0)
            {
                Console.Write("{0}, ", path.Pop());
            }
        }
    }
}
