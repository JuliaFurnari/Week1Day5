using System;

namespace Week1Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("*******Benvenuto al gioco della Tombola!*******");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            do
            {
                int N = Menu();
                int[] Nutente = InserimentoNumeri(N);
                int Ndiff = SceltaDifficoltà();
                int[] Npc = GenerazioneRandom(Ndiff);
                StampaVettoreNumeriEstratti(Npc, Ndiff);
                int[] Nvincenti = StampaVettoreRisultato(Nutente, Npc, N);
                StampaRisultato(Nvincenti);
                Console.WriteLine("\n Vuoi giocare un'altra partita? Digita si per continuare");
            } while (Console.ReadLine() == "si");
        }

        private static void StampaRisultato(int[] v)
        {
            if (v.Length < 2) Console.WriteLine("Hai Perso!");
            if (v.Length == 2)
            {
                Console.WriteLine("Hai fatto Ambo!");
                StampaVettoreNumeriVincenti(v,2);
            }
            if (v.Length == 3)
            {
                Console.WriteLine("Hai fatto Terno!");
                StampaVettoreNumeriVincenti(v, 3);
            }
            
            if (v.Length == 4)
            {
                Console.WriteLine("Hai fatto Quaterna!");
                StampaVettoreNumeriVincenti(v, 4);
            }
            
            if (v.Length >= 5)
            {
                Console.WriteLine("Hai fatto Cinquina!");
                StampaVettoreNumeriVincenti(v, 5);
            }
            if (v.Length == 15) 
            {
                Console.WriteLine("Hai fatto Tombola!");
                StampaVettoreNumeriVincenti(v, 15);
            }
        }

        private static void StampaVettoreNumeriVincenti(int[] v, int N)
        {
            Console.WriteLine("I valori vincenti sono:");
            for (int i = 0; i < N; i++)
            {

                Console.Write(v[i] + "\t");
            }

        }

        private static int[] StampaVettoreRisultato(int[] v1, int[] v2, int N)
        {
            int[] Nvincenti = new int[N];
            int resize=0;
            for (int i=0; i<N; i++)
            {
                int a = Array.IndexOf(v2, v1[i]);
                if (a != -1) Nvincenti[i] = v1[i];
            }
            Console.WriteLine("\n");
            //Ordino il vettore Nvincenti
            for (int i = 0; i < N; i++)
            {
                int min = i;

                for (int j = i + 1; j < N; j++)
                    if (Nvincenti[j] > Nvincenti[min]) 
                        min = j;
                int a = Nvincenti[min];
                Nvincenti[min] = Nvincenti[i];
                Nvincenti[i] = a;
            }

            //Conto il numero di elementi uguale a zero nel vettore
            for (int i = 0; i < N; i++)
            {
             //   Console.Write(Nvincenti[i] + "\t");// Controllo sul vettore
                if (Nvincenti[i] == 0) resize++;   
            }
            //Resize del vettore affinché non contenga zeri
            Array.Resize(ref Nvincenti, N-resize);
            Console.WriteLine("\n");
            /* Controllo sui numeri vincenti
            for (int i = 0; i < Nvincenti.Length; i++)
            {
                Console.Write(Nvincenti[i] + "\t");
                
            }
            */
            return Nvincenti;
        }

        private static void StampaVettoreNumeriEstratti(int[] v, int N)
        {
            Console.WriteLine("I valori estratti sono:");
            for (int i=0; i < N; i++)
            {
               
                Console.Write(v[i]+"\t");
            }

        }

        private static int[] GenerazioneRandom(int N)
        {
            int[] v = new int[N];
            Random r = new Random();
            
            for (int i = 0; i < N; i++)
            {
                int controllo=0;
                int a = r.Next(1, 91);
                if (i >= 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (a == v[j])
                        {
                            i--;
                            controllo++;
                        }
                        
                    }

                    if (controllo ==0) v[i] = a;
                   
                
                }
                else v[i] =a;                
            }
            return v;
        }

        private static int SceltaDifficoltà()
        {
        
            Console.WriteLine("Scegli la difficoltà di gioco fra le seguenti opzioni:");
            Console.WriteLine("1) Facile: verranno estratti 70 numeri;");
            Console.WriteLine("2) Medio: verranno estratti 40 numeri;");
            Console.WriteLine("3) Difficile: verranno estratti 20 numeri;");
            int scelta;
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3)
            {
                Console.WriteLine("Errore. Inserisci un numero intero tra 1 e 3.");
            }
            int N;
            if (scelta == 1) N = 70;
            else if (scelta == 2) N = 50;
            else  N = 20;
            return N;
        }

        private static int Menu()
        {
            
            Console.WriteLine("Digita il numero associato a una delle seguenti opzioni:");
            Console.WriteLine("1) Gioco con 5 numeri;");
            Console.WriteLine("2) Gioco con 15 numeri;");
            int scelta;
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 2)
            {
                Console.WriteLine("Errore. Inserisci un numero intero tra 1 e 2.");
            }
            int N;
            if (scelta == 1) N = 5;
            else N = 15;
            return N;
        }
        
        private static int[] InserimentoNumeri(int s)
        {
            Console.WriteLine($"Inserisci {s} numeri:");
            int[] Nutente = new int[s];
            for (int i = 0; i < s; i++)
            {
                int a = 0;
                int controllo=0;
                while (!int.TryParse(Console.ReadLine(), out a) || a < 1 || a > 90)
                {
                    Console.WriteLine("Errore. Inserisci un numero intero tra 1 e 90.");
                }
                if (i >= 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (a == Nutente[j]) 
                        {
                            i--;
                            controllo = 1;
                        }
                      
                    }
                    if (controllo == 1) Console.WriteLine("Non puoi inserire un numero già inserito! Scegli un altro numero tra 1 e 90.");
                    else
                    {
                        Nutente[i] = a;
                        Console.WriteLine($"Il {i + 1}° numero inserito è: {Nutente[i]}");
                    }
                }
                else
                {
                    Nutente[i] = a;
                    Console.WriteLine($"Il {i + 1}° numero inserito è: {Nutente[i]}");
                }
            }
            return Nutente;
        }
    }
}
