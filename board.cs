using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gra
{
    static class board 
    {
        public static int jeden=0;
        public static int dwa = 0;
        public static string[,] plansza = new string[3, 3];

        public static void Pboard()
        {
            

            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {

                    plansza[i, j] = "-";

                }

            }
        }

        public static void CHboard()
        {
            Console.WriteLine("|-----|-----|-----|");
            Console.WriteLine("|  " + plansza[0, 0] + "  |  " + plansza[0, 1] + "  |  " + plansza[0, 2] + "  |");
            Console.WriteLine("|-----|-----|-----|");
            Console.WriteLine("|  " + plansza[1, 0] + "  |  " + plansza[1, 1] + "  |  " + plansza[1, 2] + "  |");
            Console.WriteLine("|-----|-----|-----|");
            Console.WriteLine("|  " + plansza[2, 0] + "  |  " + plansza[2, 1] + "  |  " + plansza[2, 2] + "  |");
            Console.WriteLine("|-----|-----|-----|");
        }

        public static void setchar(string a)
        {
            for (;;)
            {
                
                Console.WriteLine("Wybierz miejsce w które chcesz wstawic znak...");
                Console.Write("Podaj numer wiersza (od 1 do 3) : ");
                try
                {
                    jeden = Convert.ToInt32(Console.ReadLine());
                    if (jeden < 0 || jeden > 3)
                    {
                        try
                        {
                            throw new WrongChoiceException();
                        }
                        catch (WrongChoiceException e)
                        {
                            jeden = 0;
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.Source);
                            Console.ReadKey();
                            Console.Clear();
                            CHboard();
                            Console.WriteLine("\nZacznij wpisywanie na nowo.");
                            Console.WriteLine("Nadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                            continue;
                        }

                    }
                }
                catch (FormatException e)
                {
                    jeden = 0;
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.Clear();
                    Console.ReadKey();
                    CHboard();
                    Console.WriteLine("\nZacznij wpisywanie na nowo.");
                    Console.WriteLine("Nadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                    continue;
                }
                catch (OverflowException e)
                {
                    jeden = 0;
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.ReadKey();
                    Console.Clear();
                    CHboard();
                    Console.WriteLine("\nZacznij wpisywanie na nowo.");
                    Console.WriteLine("Nadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                    continue;
                }

                Console.Write("Podaj numer kolumny (od 1 do 3) : ");
                try
                {
                    dwa = Convert.ToInt32(Console.ReadLine());
                    if (dwa < 0 || dwa > 3)
                    {
                        try
                        {
                            throw new WrongChoiceException();
                        }
                        catch (WrongChoiceException e)
                        {
                            dwa = 0;
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.Source);
                            Console.ReadKey();
                            Console.Clear();
                            CHboard();
                            Console.WriteLine("\nZacznij wpisywanie na nowo.");
                            Console.WriteLine("Nadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                            continue;
                        }

                    }
                }
                catch(FormatException e)
                {
                    dwa = 0;
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.Clear();
                    Console.ReadKey();
                    CHboard();
                    Console.WriteLine("\nZacznij wpisywanie na nowo.");
                    Console.WriteLine("Nadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                    continue;
                }
                catch (OverflowException e)
                {
                    dwa = 0;
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.ReadKey();
                    Console.Clear();
                    CHboard();
                    Console.WriteLine("\nZacznij wpisywanie na nowo.");
                    Console.WriteLine("Nadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                    continue;
                }
                if ( plansza[(jeden - 1), (dwa - 1)] == "-" )
                {
                    plansza[(jeden - 1), (dwa - 1)] = a;
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("To pole jest zajete, wybierz inne.");
                    Console.WriteLine("Nacisnij dowolny klawisz aby kontynuowac...");
                    Console.ReadKey();
                    Console.Clear();
                    CHboard();
                    Console.WriteLine("\nNadal obowiazuje tura gracza ktory sie pomylil.\n\n");
                    
                }
            }
           
        }


    }
}
