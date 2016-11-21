using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Graph
    {
        public int[,] Matriisi
        {
            get
            {
                return matriisi;
            }
        }
        private Random random;
        private int number;
        private int[,] matriisi;

        public Graph(int vertices)
        {
            matriisi = new int[vertices, vertices];
            random = new Random();
            for (int i = 0; i < Math.Sqrt(matriisi.Length); i++)
            {
                int rand = random.Next(1, 5);
                for (int j = 0; j < rand; j++)
                {
                    int temp = random.Next(1, 101);
                    while(true)
                    {
                        number = random.Next(0, (int)Math.Sqrt(matriisi.Length));
                        if (i != number)
                        {
                            matriisi[i, number] = temp;
                            matriisi[number, i] = temp;
                            break;
                        }
                    }
                    
                    
                }
            }
        }
        
    }
}
