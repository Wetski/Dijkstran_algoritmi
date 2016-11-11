using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dijkstra
    {
        public int[,] Matriisi { get; set; }
        private int[] unvisited, visited, distance, via;
        private int start, current;
        private bool finished;

        public Dijkstra(int[,] matriisi, int s)
        {
            finished = false;
            start = s;
            current = start;
            Matriisi = matriisi;
            unvisited = new int[(int)Math.Sqrt(matriisi.Length)];
            visited = new int[(int)Math.Sqrt(matriisi.Length)];
            distance = new int[(int)Math.Sqrt(matriisi.Length)];
            via = new int[(int)Math.Sqrt(matriisi.Length)];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = -1;
                via[i] = -1;
            }
            for (int i = 0; i < Math.Sqrt(matriisi.Length); i++)
            {
                unvisited[i] = i;
            }
        }
        public void Calculate()
        {
            int[] tdistance = new int[(int)Math.Sqrt(Matriisi.Length)];
            while (finished != true)
            {
                if (current == start)
                {
                    distance[current] = 0;
                    tdistance = distance;
                    via[current] = -1;
                }
                for (int i = 0; i < distance.Length; i++)
                {
                    if (Matriisi[current, i] != 0 && Matriisi[current, i] + distance[current] < distance[i])
                    {
                        distance[i] = distance[current] + Matriisi[current, i];
                        tdistance = distance;
                        via[i] = current;
                    }
                }
                Array.Sort(tdistance);
                visited[current] = current;
                unvisited[current] = -1;
                for (int i = 0; i < tdistance.Length; i++)
                {
                    if (tdistance[i] > distance[current])
                    {
                        current = Array.FindIndex(distance, item => item == tdistance[i]);
                        break;
                    }
                }
                if (Array.FindIndex(visited, item => item == -1) == -1) { finished = true; }
            }
            Console.WriteLine("Embryo:  Distance:   Via:");
            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write(" {0}         ", visited[i]);
                Console.Write("{0}          ", distance[i]);
                if (via[i] == -1) { Console.WriteLine(" "); }
                else { Console.WriteLine(via[i]); }
            }
        }
    }
}
