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
        private int[] visited, distance, via;
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
                    distance[round] = 0;
                    via[round] = -1;
                }
                for (int i = 0; i < distance.Length; i++)
                {
                    if (Matriisi[current, i] != 0 && Matriisi[current, i] + distance[current] < distance[i])
                    {
                        distance[round] = distance[current] + Matriisi[current, i];
                        via[round] = current;
                    }
                }
                tdistance = (int[])distance.Clone();
                Array.Sort(tdistance);
                visited[round] = current;
                for (int i = 0; i < tdistance.Length; i++)
                {
                    int former = current;
                    if (tdistance[i] >= distance[current] && visited[i] == -1)
                    {
                        for (int j = 0; j < distance.Length; j++)
                        {
                            if (distance[j] == tdistance[i] && visited[i] == -1)
                            {
                                current = j;
                                break;
                            }
                        }
                        //current = Array.IndexOf(distance, tdistance[i]);
                    }
                    if (current != former) { break; }
                }
                if (Array.FindIndex(visited, item => item == -1) == -1) { finished = true; }
                round++;
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
