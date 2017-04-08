using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace gra
{
    class Program
    {
        public static  player gracz1;
        public static player gracz2;
        public static string winner = "NIKT";
        static void Main(string[] args)
        {
           
            int a=0;
            int x = 0;
           
            for (;;)
            {
                //try
                //{
                    menu();
                    Console.Write("\nWybierz Opcje :");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        //Console.WriteLine(e.Source);
                    Console.WriteLine(e.StackTrace);
                    Console.ReadKey();
                        continue;
                    }
                    catch (OverflowException e)
                    {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.WriteLine(e.StackTrace);
                    Console.ReadKey();
                    continue;
                    }
                
                    if ((a > 4) || (a == 0))
                    {
                    try
                    {
                        a = 0;
                        throw new WrongChoiceException();
                    }
                    catch(WrongChoiceException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.Source);
                        //Console.WriteLine(e.StackTrace);
                        Console.ReadKey();
                        continue;
                    }
                    }
                    else if ((a >= 1) && (a <= 4))
                    {
                        while (a == 1)
                        {

                            Console.Clear();
                            // losowe przydzielenie kolka i krzyzyka
                            // pierwszy krzyzyk
                            //koniec jak 3 takie same znaki
                            gracz1 = new player();
                            gracz2 = new player();                          
                            gracz1.setname("Gracz_1");
                            gracz2.setname("Gracz_2");
                            Console.Clear();
                            efekt();
                            try
                            {
                            x = losowanie();
                            }
                            catch(BadAssignmentException e)
                            {
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.Source);
                            x = 0;
                            a = 0;
                            continue;
                            }
                            if (x < 5)
                            {
                                gracz1.frst = "X";
                                gracz2.frst = "O";
                                Console.Write("Zaczyna gracz : "); gracz1.showname();
                                Console.Write("\n\nWCISNIJ DOWOLNY KLAWISZ ABY KOTYNUOWAC...");
                                Console.ReadKey();
                                Console.Clear();
                                board.Pboard();
                                // ruchy wloz do funkcji sprawdzajacej wygrana
                                moveX();
                                moveO();
                                moveX();
                                moveO();
                                moveX();
                                // 3 ruch X ZMIEN INDEKSY Z 3 NA 2 DEBILU
                                #region 
                                if (
                                    ((board.plansza[0, 0] == "X") && (board.plansza[0, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                    ((board.plansza[1, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[1, 2] == "X")) ||
                                    ((board.plansza[2, 0] == "X") && (board.plansza[2, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                    ((board.plansza[0, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                    ((board.plansza[2, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                    ((board.plansza[0, 0] == "X") && (board.plansza[1, 0] == "X") && (board.plansza[2, 0] == "X")) ||
                                    ((board.plansza[0, 1] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 1] == "X")) ||
                                    ((board.plansza[0, 2] == "X") && (board.plansza[1, 2] == "X") && (board.plansza[2, 2] == "X"))
                                   )
                                {
                                    Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz1.showname();
                                    winner = gracz1.setwinner(winner);
                                    Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                    Console.ReadKey();
                                    x = 0;
                                    break;
                                }
                                else
                                {
                                    moveO();
                                    //3 ruch O
                                    #region
                                    if (
                                              ((board.plansza[0, 0] == "O") && (board.plansza[0, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                              ((board.plansza[1, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[1, 2] == "O")) ||
                                              ((board.plansza[2, 0] == "O") && (board.plansza[2, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                              ((board.plansza[0, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                              ((board.plansza[2, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                              ((board.plansza[0, 0] == "O") && (board.plansza[1, 0] == "O") && (board.plansza[2, 0] == "O")) ||
                                              ((board.plansza[0, 1] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 1] == "O")) ||
                                              ((board.plansza[0, 2] == "O") && (board.plansza[1, 2] == "O") && (board.plansza[2, 2] == "O"))
                                            )
                                    {
                                        Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz2.showname();
                                        winner = gracz2.setwinner(winner);
                                        Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                        Console.ReadKey();
                                        x = 0;
                                        break;
                                    }
                                    else
                                    {
                                        moveX();
                                        // 4 ruch X
                                        #region
                                        if (
                                             ((board.plansza[0, 0] == "X") && (board.plansza[0, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                             ((board.plansza[1, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[1, 2] == "X")) ||
                                             ((board.plansza[2, 0] == "X") && (board.plansza[2, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                             ((board.plansza[0, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                             ((board.plansza[2, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                             ((board.plansza[0, 0] == "X") && (board.plansza[1, 0] == "X") && (board.plansza[2, 0] == "X")) ||
                                             ((board.plansza[0, 1] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 1] == "X")) ||
                                             ((board.plansza[0, 2] == "X") && (board.plansza[1, 2] == "X") && (board.plansza[2, 2] == "X"))
                                           )
                                        {
                                            Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz1.showname();
                                            winner = gracz1.setwinner(winner);
                                            Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                            Console.ReadKey();
                                            x = 0;
                                            break;
                                        }
                                        else
                                        {

                                            moveO();
                                            // 4 ruch O
                                            #region
                                            if (
                                                     ((board.plansza[0, 0] == "O") && (board.plansza[0, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                                     ((board.plansza[1, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[1, 2] == "O")) ||
                                                     ((board.plansza[2, 0] == "O") && (board.plansza[2, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                                     ((board.plansza[0, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                                     ((board.plansza[2, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                                     ((board.plansza[0, 0] == "O") && (board.plansza[1, 0] == "O") && (board.plansza[2, 0] == "O")) ||
                                                     ((board.plansza[0, 1] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 1] == "O")) ||
                                                     ((board.plansza[0, 2] == "O") && (board.plansza[1, 2] == "O") && (board.plansza[2, 2] == "O"))
                                                   )
                                            {
                                                Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz2.showname();
                                                winner = gracz2.setwinner(winner);
                                                Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                                Console.ReadKey();
                                                x = 0;
                                                break;
                                            }
                                            else
                                            {

                                                moveX();
                                                // 5 ruch X
                                                #region
                                                if (
                                                      ((board.plansza[0, 0] == "X") && (board.plansza[0, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                                      ((board.plansza[1, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[1, 2] == "X")) ||
                                                      ((board.plansza[2, 0] == "X") && (board.plansza[2, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                                      ((board.plansza[0, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                                      ((board.plansza[2, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                                      ((board.plansza[0, 0] == "X") && (board.plansza[1, 0] == "X") && (board.plansza[2, 0] == "X")) ||
                                                      ((board.plansza[0, 1] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 1] == "X")) ||
                                                      ((board.plansza[0, 2] == "X") && (board.plansza[1, 2] == "X") && (board.plansza[2, 2] == "X"))
                                                    )
                                                {
                                                    Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz1.showname();
                                                    winner = gracz1.setwinner(winner);
                                                    Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                                    Console.ReadKey();
                                                    x = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\n Gra zakonczyla sie remisem.");
                                                    Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                                    winner = "NIKT";
                                                    Console.ReadKey();
                                                    x = 0;
                                                    break;
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    #endregion

                                }
                                #endregion


                                //dopisz funkcje ktora bd sprawdzac podane parametry i czy pole nie jest juz zajete
                                //oddziel od siebie graczy
                                //zrob system naliczania pkt

                            }
                            else
                            {
                                gracz2.frst = "X";
                                gracz1.frst = "O";
                                Console.Write("Zaczyna gracz : "); gracz2.showname();
                                Console.Write("\n\nWCISNIJ DOWOLNY KLAWISZ ABY KOTYNUOWAC...");
                                Console.ReadKey();
                                Console.Clear();
                                board.Pboard();
                                // ruchy wloz do funkcji sprawdzajacej wygrana
                                moveX1();
                                moveO1();
                                moveX1();
                                moveO1();
                                moveX1();
                                // 3 ruch X ZMIEN INDEKSY Z 3 NA 2 DEBILU
                                #region 
                                if (
                                    ((board.plansza[0, 0] == "X") && (board.plansza[0, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                    ((board.plansza[1, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[1, 2] == "X")) ||
                                    ((board.plansza[2, 0] == "X") && (board.plansza[2, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                    ((board.plansza[0, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                    ((board.plansza[2, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                    ((board.plansza[0, 0] == "X") && (board.plansza[1, 0] == "X") && (board.plansza[2, 0] == "X")) ||
                                    ((board.plansza[0, 1] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 1] == "X")) ||
                                    ((board.plansza[0, 2] == "X") && (board.plansza[1, 2] == "X") && (board.plansza[2, 2] == "X"))
                                   )
                                {
                                    Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz2.showname();
                                    winner = gracz2.setwinner(winner);
                                    Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                    Console.ReadKey();
                                    x = 0;
                                    break;
                                }
                                else
                                {
                                    moveO1();
                                    //3 ruch O
                                    #region
                                    if (
                                              ((board.plansza[0, 0] == "O") && (board.plansza[0, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                              ((board.plansza[1, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[1, 2] == "O")) ||
                                              ((board.plansza[2, 0] == "O") && (board.plansza[2, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                              ((board.plansza[0, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                              ((board.plansza[2, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                              ((board.plansza[0, 0] == "O") && (board.plansza[1, 0] == "O") && (board.plansza[2, 0] == "O")) ||
                                              ((board.plansza[0, 1] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 1] == "O")) ||
                                              ((board.plansza[0, 2] == "O") && (board.plansza[1, 2] == "O") && (board.plansza[2, 2] == "O"))
                                            )
                                    {
                                        Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz1.showname();
                                        winner = gracz1.setwinner(winner);
                                        Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                        Console.ReadKey();
                                        x = 0;
                                        break;
                                    }
                                    else
                                    {
                                        moveX1();
                                        // 4 ruch X
                                        #region
                                        if (
                                             ((board.plansza[0, 0] == "X") && (board.plansza[0, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                             ((board.plansza[1, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[1, 2] == "X")) ||
                                             ((board.plansza[2, 0] == "X") && (board.plansza[2, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                             ((board.plansza[0, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                             ((board.plansza[2, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                             ((board.plansza[0, 0] == "X") && (board.plansza[1, 0] == "X") && (board.plansza[2, 0] == "X")) ||
                                             ((board.plansza[0, 1] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 1] == "X")) ||
                                             ((board.plansza[0, 2] == "X") && (board.plansza[1, 2] == "X") && (board.plansza[2, 2] == "X"))
                                           )
                                        {
                                            Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz2.showname();
                                            winner = gracz2.setwinner(winner);
                                            Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                            Console.ReadKey();
                                            x = 0;
                                            break;
                                        }
                                        else
                                        {

                                            moveO1();
                                            // 4 ruch O
                                            #region
                                            if (
                                                     ((board.plansza[0, 0] == "O") && (board.plansza[0, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                                     ((board.plansza[1, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[1, 2] == "O")) ||
                                                     ((board.plansza[2, 0] == "O") && (board.plansza[2, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                                     ((board.plansza[0, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 2] == "O")) ||
                                                     ((board.plansza[2, 0] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[0, 2] == "O")) ||
                                                     ((board.plansza[0, 0] == "O") && (board.plansza[1, 0] == "O") && (board.plansza[2, 0] == "O")) ||
                                                     ((board.plansza[0, 1] == "O") && (board.plansza[1, 1] == "O") && (board.plansza[2, 1] == "O")) ||
                                                     ((board.plansza[0, 2] == "O") && (board.plansza[1, 2] == "O") && (board.plansza[2, 2] == "O"))
                                                   )
                                            {
                                                Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz1.showname();
                                                winner = gracz1.setwinner(winner);
                                                Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                                Console.ReadKey();
                                                x = 0;
                                                break;
                                            }
                                            else
                                            {

                                                moveX1();
                                                // 5 ruch X
                                                #region
                                                if (
                                                      ((board.plansza[0, 0] == "X") && (board.plansza[0, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                                      ((board.plansza[1, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[1, 2] == "X")) ||
                                                      ((board.plansza[2, 0] == "X") && (board.plansza[2, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                                      ((board.plansza[0, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 2] == "X")) ||
                                                      ((board.plansza[2, 0] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[0, 2] == "X")) ||
                                                      ((board.plansza[0, 0] == "X") && (board.plansza[1, 0] == "X") && (board.plansza[2, 0] == "X")) ||
                                                      ((board.plansza[0, 1] == "X") && (board.plansza[1, 1] == "X") && (board.plansza[2, 1] == "X")) ||
                                                      ((board.plansza[0, 2] == "X") && (board.plansza[1, 2] == "X") && (board.plansza[2, 2] == "X"))
                                                    )
                                                {
                                                    Console.Write("\n\n\t\tWYGRYWA GRACZ : "); gracz2.showname();
                                                    winner = gracz2.setwinner(winner);
                                                    Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                                    Console.ReadKey();
                                                    x = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\n Gra zakonczyla sie remisem.");
                                                    Console.WriteLine("\n\n\t\tNacisnij dowolny klawisz aby kontynuowac...");
                                                    winner = "NIKT";
                                                    Console.ReadKey();
                                                    x = 0;
                                                    break;
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    #endregion

                                }
                                #endregion
                            }



                        }
                        while (a == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Wyglad planszy : \n");
                            Console.WriteLine("|--------|---------|--------|");
                            Console.WriteLine("|  w1 k1 |   w1 k2 |  w1 k3 |");
                            Console.WriteLine("|--------|---------|--------|");
                            Console.WriteLine("|  w2 k1 |   w2 k2 |  w2 k3 |");
                            Console.WriteLine("|--------|---------|--------|");
                            Console.WriteLine("|  w3 k1 |   w3 k2 |  w3 k3 |");
                            Console.WriteLine("|--------|---------|--------|");
                            Console.WriteLine("\n\nWybieraj pola przez wskazanie odpowiedniej komorki.");
                            Console.WriteLine("Pierwsza wpisywana liczba to numer wiersza, a druga to numer kolumny, komorki w ktorej chcesz umiescic znak");
                            Console.WriteLine("Tradycyjnie pierwszenstwo ma krzyzyk.");
                            Console.WriteLine("\n\nNacisnij dowolny klawisz aby kontynuowac...");
                            Console.ReadKey();
                            a = 0;
                            Console.Clear();
                            break;


                        }
                        while (a == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Ostatni zwycięzca to : " + winner);
                            Console.WriteLine("\n\nNacisnij dowolny klawisz aby kontynuowac...");
                            Console.ReadKey();
                            a = 0;
                            Console.Clear();
                            break;

                        }
                        while (a == 4)
                        {
                            System.Environment.Exit(1);
                            break;

                        }
                    }

                //}

                //catch (Exception exception)
                //{
                //    Console.Clear();
                //    Console.WriteLine("Error : " + exception.Message);
                //    Console.WriteLine("NACISNIJ DOWOLNY KALWISZ ABY WROCIC DO MENU");
                //    Console.ReadKey();
                //    Console.Clear();

                //}
            }
        }

        static public int losowanie()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 8);
            return dice;
        }
        static public void efekt()
        {
            Console.Write("\nLosowanie pierwszenstwa");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }
        static public void menu()
        {
            // dodaj na szytwno ustawiona wielksoc okna 
            Console.Clear();
            Console.WriteLine("===========MENU===========");
            Console.WriteLine("=        1.Start         =");
            Console.WriteLine("=        2.Instrukcja    =");
            Console.WriteLine("=    3.Ostatni Zwyciezca =");
            Console.WriteLine("=        4.Koniec        =");
            Console.WriteLine("==========================");

        }
        static public void moveX()
        {
            Console.WriteLine("Ruch gracza :");gracz1.showname();Console.Write("\n\n");
            gracz1.showname(); Console.Write(": X\n");
            gracz2.showname(); Console.Write(": O\n");
            board.CHboard();
            board.setchar(gracz1.frst);

        }
        static public void moveO()
        {
            Console.WriteLine("Ruch gracza :"); gracz2.showname(); Console.Write("\n\n");
            gracz1.showname(); Console.Write(": X\n");
            gracz2.showname(); Console.Write(": O\n");
            board.CHboard();
            board.setchar(gracz2.frst);

        }
        static public void moveX1()
        {
            Console.WriteLine("Ruch gracza :"); gracz2.showname(); Console.Write("\n\n");
            gracz2.showname(); Console.Write(": X\n");
            gracz1.showname(); Console.Write(": O\n");
            board.CHboard();
            board.setchar(gracz2.frst);

        }
        static public void moveO1()
        {
            Console.WriteLine("Ruch gracza :"); gracz1.showname(); Console.Write("\n\n");
            gracz2.showname(); Console.Write(": X\n");
            gracz1.showname(); Console.Write(": O\n");
            board.CHboard();
            board.setchar(gracz1.frst);

        }

    }
}



