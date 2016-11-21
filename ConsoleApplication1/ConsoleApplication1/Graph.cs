/*
 * Copyright 2016 Veeti Karttunen, Niki Liuhanen, Aaro Lyytinen
 *
 * This is a part of Data structrures and Algorithms course assignment
 * and is licensed under MIT license, see LICENSE file.
 *
 * Created: 21.11.2016
 */
using System;

namespace ConsoleApplication1
{
    class Graph
    {
        public int[,] Matriisi  //Satunnaisverkon matriisitaulukko
        {
            get
            {
                return matriisi;
            }
        }
        private Random random;
        private int number;
        private int[,] matriisi;

        public Graph(int vertices)  //Konstruktori
        {
            matriisi = new int[vertices, vertices];
            random = new Random();
            for (int i = 0; i < Math.Sqrt(matriisi.Length); i++)    //For silmukka käy läpi matriisitaulukon alkioiden lukumäärän verran kierroksia
            {
                int rand = random.Next(1, 5);                       //Satunnainen numero 1-4 väliltä
                for (int j = 0; j < rand; j++)                      //For silmukka ylläolevan satunnaisluvun verran kierroksia
                {
                    int temp = random.Next(1, 101);
                    while(true)
                    {
                        number = random.Next(0, (int)Math.Sqrt(matriisi.Length));   //Luodaan matriisitalukon linkit kahden eri alkion välille
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
