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
        public int[,] Matriisi { get; set; }    //Käytettävä 2-ulotteinen matriisitaulukko.
        public int Start                        //Lähtöpiste
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
        private int[] visited, distance, via;   //Taulukot, vierrailtujen alkioiden, alkioiden etäisyydet ja periytynyt alkio
        private List<int> inde;                 //Taulukko, jos on kaksi tai useampi yhtäpitkä etäisyys.
        private Stack<int> path;                //Polku, lähtöpisteestä päätepisteeseen.
        private int start, current;             //Start on lähtöpiste, Current on tutkittava piste
        private bool finished;                  //Totuusarvo onko algoritmi valmis.

        public Dijkstra(int[,] matriisi, int s, int target)
        {
            start = s;
            Matriisi = matriisi;
            //Alustetaan kaikki taulukot.
            visited = new int[(int)Math.Sqrt(matriisi.Length)];
            distance = new int[visited.Length];
            via = new int[visited.Length];
            inde = new List<int>();
            path = new Stack<int>();
            finished = false;
            for (int i = 0; i < distance.Length; i++)
            {
                //Alustetaan alla olevien taulukoiden erikoisarvot.
                distance[i] = int.MaxValue;
                visited[i] = -1;
                via[i] = -1;
            }
            inde.Clear();
            current = start;
            int[] tdistance = new int[visited.Length];
            int round = 0;
            //Aloitetaan algoritmi.
            while (finished != true)
            {
                if (current == start)       //Jos tarkasteltava piste on aloituspiste niin sen etäisyys asetetaan nollaksi.
                {
                    distance[current] = 0;
                    via[current] = -1;
                }
                for (int i = 0; i < distance.Length; i++)
                {
                    if (Matriisi[current, i] != 0 && Matriisi[current, i] + distance[current] < distance[i])
                                        {   //Jos tarkasteltavan pisteen ja i:n väli on 0 välissä ei ole linkkiä.
                                            //Jos tarkasteltavan pisteen ja i:n väli on < kuin niinden välinen etäisyys asetetaan uusi etäisyys.
                        distance[i] = distance[current] + Matriisi[current, i];
                        via[i] = current;   //asetetaan perittävä piste
                    }
                }
                tdistance = (int[])distance.Clone();    //Kloonataan etäisyyslista.
                Array.Sort(tdistance);                  //Väliaikainen etäisyyslista lajitellaan.
                visited[round] = current;               //Vierailtujenlistaan lisätään tarkasteltu piste.
                for (int i = 0; i < tdistance.Length; i++)  //Silmukka, jossa katsotaan väliaikaislistan pituus.
                {
                    inde.Clear();                       //Tyhjennetään inde-lista.
                    int former = current;               //Asetetaan muutosmuuttuja
                    for (int j = 0; j < distance.Length; j++)
                    {
                        if (distance[j] == tdistance[i])//Tarkastellaan lyhimmästä pisimpään järjestyksessä, mikä seuraavan tarkastelupisteen tulee olla.
                        {
                            inde.Add(j);                //Lisätään kandidaatit listaan inde
                        }
                    }
                    foreach (int value in inde)         //Käydään läpi inde lista
                    {
                        if (tdistance[i] >= distance[current] && Array.IndexOf(visited, value) == -1 && value != -1)
                        //Jos väliaikaisetäisyys on >= tarkasteltava etäisyys JA vierailtujentaulukosta ei löydy kyseistä inde-listassa olevaa arvoa JA arvo != -1
                        {
                            current = value;    //Asetetaan uudeksi tarkasteltavaksi pisteeksi inde-listan tämänhetkinen arvo.
                            break;
                        }
                    }
                    if (former != current) { break; }   //Jos muutosmuuttujan ja tarkasteltavan pisteen välillä on ero on tarkasteltava piste vaihtunut.
                }
                if (Array.IndexOf(visited, -1) == -1) { finished = true; } //Jos vierailtujen lista on täynnä on algoritmi valmis.
                round++;
            }
            Console.WriteLine("Vertex:  Distance:   Via:"); //Tulostetaan selvästi luettava lista.
            Console.WriteLine("---------------------------");
            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write(" {0}         ", i);
                Console.Write("{0}          ", distance[i]);
                if (via[i] == -1) { Console.WriteLine(" "); }
                else { Console.WriteLine(via[i]); }
                Console.WriteLine("---------------------------");
            }
            while(true) //Tulostetaan polku lähtöpisteestä päätepisteeseen.
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
