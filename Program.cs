using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backtrackteheneszetek
{
    class Program
    {

        static bool defined = false;
        static int[] best_best_mo;
        static int[] best_akt_mo;


        static bool Jobb(int[] egyik, int[] masik)
        {
            //...
        }

       
        static void Legjobb(int[] tehenészetek, int[] tejüzemek, int eleje)
        {
            bool siker = eleje == tehenészetek.Length;
           

            bool reménytelen = defined && Jobb(best_best_mo, best_akt_mo);
            

            if (siker)
            {
                if (!defined || Jobb(best_akt_mo, best_best_mo))
                {
                    best_best_mo = best_akt_mo.ToArray();
                }
                defined = true;
                return;
            }

            if (reménytelen)
            {
                return;
            }

            for (int i = 0; i < tejüzemek.Length; i++)
            {
                best_akt_mo[eleje] = i;
                Legjobb(tehenészetek, tejüzemek, eleje + 1);
            }
        }


        static void Main(string[] args)
        {
           
            string[] sortomb = Console.ReadLine().Split(' ');
            int N = int.Parse(sortomb[0]);
            int M = int.Parse(sortomb[1]);

            int[] teheneszetek = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] tejuzemek = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[][] m = new int[N][];

            for (int i = 0; i < N; i++)
            {
                m[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            
            best_akt_mo = new int[N];
            Legjobb(teheneszetek, tejuzemek, 0);

            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                Console.Write(best_best_mo[i]);
            }

            
            Console.Error.WriteLine();

            
        }
    }
}