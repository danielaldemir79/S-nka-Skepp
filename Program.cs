namespace Sänka_Skepp
{
    internal class Program
    {
        static string[,] playerMap = new string[4, 6];
        static string[,] computerMap = new string[4, 6];
        static string[,] displayComputerMap = new string[4, 6];

        static int antalHitsSpelare = 0;
        static int antalHitsDator = 0;

        static void Main(string[] args)
        {
                                 

            SkapaKarta(playerMap, computerMap, displayComputerMap);

            PlaceraAllaSkepp(playerMap);
            PlaceraAllaSkepp(computerMap);


            Console.WriteLine();

            //Console.WriteLine("Datorns Karta");
            //SkrivUtKarta(computerMap);


            while (true)
            {
                
                if (antalHitsSpelare == 3 || antalHitsDator == 3)
                {
                    break;
                }


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Datorns karta");
                Console.WriteLine("***********");
                Console.ResetColor();
                SkrivUtKarta(displayComputerMap);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("***********");
                Console.ResetColor();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Din Karta");
                Console.WriteLine("***********");
                Console.ResetColor();
                SkrivUtKarta(playerMap);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("***********");
                Console.ResetColor();
                Console.WriteLine();

                SpealreplaceraSkott(computerMap);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Datorns karta");
                Console.WriteLine("***********");
                Console.ResetColor();
                SkrivUtKarta(displayComputerMap);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("***********");
                Console.ResetColor();

                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine();  

                DatornPlacerarSkott(playerMap);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Din Karta");
                Console.WriteLine("***********");
                Console.ResetColor();
                SkrivUtKarta(playerMap);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("***********");
                Console.ResetColor();
                Console.WriteLine();


                Console.WriteLine();
                Console.WriteLine("Klicka på valfri tangent för nästa skott");
                Console.ReadKey();
                Console.Clear();

                

               

            }

            Console.WriteLine();

            if (antalHitsSpelare == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Grattis du vann!");
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tyvärr du förlorade!");
                Console.ResetColor();
            }

                                   
        }




        //Metoder börjar här


        static void SkapaKarta(string[,] playerMap, string[,] computerMap, string[,] displayComputerMap) //Metod för att skapa spelplanen
        {


            for (int i = 0; i < playerMap.GetLength(0); i++)
            {
                for (int j = 0; j < playerMap.GetLength(1); j++)
                {
                    playerMap[i, j] = ("X");
                }

            }

            for (int i = 0; i < computerMap.GetLength(0); i++)
            {
                for (int j = 0; j < computerMap.GetLength(1); j++)
                {
                    computerMap[i, j] = (" ");
                }

            }

            for (int i = 0; i < displayComputerMap.GetLength(0); i++)
            {
                for (int j = 0; j < displayComputerMap.GetLength(1); j++)
                {
                    displayComputerMap[i, j] = (" ");
                }

            }


        }


        static void SkrivUtKarta(string[,] map) //Metod för att skriva ut spelplanen
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == "T")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (map[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (map[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.Write($"{map[i, j]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }


        static void PlaceraAllaSkepp(string[,] map) //Metod för att placera ut skepp på spelplanen
        {
            int row = 0;
            int col = 0;

            for (int i = 0; i < 3; i++) //Placerar ut 3 skepp
            {
                bool placed = false;
                Random rand = new Random();

                while (!placed)    //Loopar tills ett skepp har placerats
                {
                    row = rand.Next(0, (map.GetLength(0))); // ger slumpad rad
                    col = rand.Next(0, (map.GetLength(1))); // ger slumpad kolumn

                    if (map[row, col] != "O") //Kollar om det redan finns ett skepp på den platsen
                    {
                        map[row, col] = "O";
                        placed = true;
                    }

                }

            }

        }

       static  void SpealreplaceraSkott(string[,] map)
        {
            int col;
            int row;
            bool validInput = false;

            while (validInput == false)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Placera ditt skott.");
                Console.Write("Ange X-kordinat (1-6): ");
                col = GetInt();
                Console.ResetColor();

                if (col < 1 || col > 6)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning. Försök igen.");
                    Console.ResetColor();
                    continue;
                }


                do
                {

                   Console.ForegroundColor = ConsoleColor.Yellow;
                   Console.Write("Ange Y-kordinat (1-4): ");

                    row = GetInt();
                    Console.ResetColor();

                    if (row < 1 || row > 4)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning. Försök igen.");
                        Console.ResetColor();
                    }

                } while (row < 1 || row > 4);

                row--;  //Görs om till index då index börjar på 0
                col--;  //Görs om till index då index börjar på 0

                // Kontrollera om spelaren redan har skjutit här
                if (displayComputerMap[row, col] == "T" || displayComputerMap[row, col] == "-")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine(" Redan skjutit där. Sikta om!");
                    Console.WriteLine("-----------------------------");
                    Console.ResetColor();
                    validInput = false;
                    continue;

                }

                if (map[row, col] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    displayComputerMap[row, col] = "T";
                    Console.WriteLine();
                    Console.WriteLine("-------------------");
                    Console.WriteLine(" Snyggt du träffa! ");
                    Console.WriteLine("-------------------");
                    antalHitsSpelare++;
                    Console.ResetColor();

                }
                else if (map[row, col] == " ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    displayComputerMap[row, col] = "-";
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                    Console.WriteLine(" Du missade! ");
                    Console.WriteLine("-------------");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Något gick fel. Försök igen.");
                    Console.ResetColor();
                    continue;
                }



                validInput = true;
            }
        }


        static void DatornPlacerarSkott(string[,] map)
        {
            Random rand = new Random();


            while (true)
            {
                int col = rand.Next(0, map.GetLength(1)); // ger slumpad kolumn (0-5)
                int row = rand.Next(0, map.GetLength(0)); // ger slumpad rad (0-3)


                if (map[row, col] == "-" || map[row, col] == "T")
                {
                    continue;
                }
                else if (map[row, col] == "O")
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    playerMap[row, col] = "T";
                    Console.WriteLine("----------------");
                    Console.WriteLine(" Datorn träffa! ");
                    Console.WriteLine("----------------");
                    antalHitsDator++;
                    Console.ResetColor();
                    break;


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    playerMap[row, col] = "-";
                    Console.WriteLine("-----------------");
                    Console.WriteLine(" Datorn missade! ");
                    Console.WriteLine("-----------------");
                    Console.ResetColor();
                    break;
                }
            }
            


        }
        static int GetInt()
        {
            int heltal;

            while (!int.TryParse(Console.ReadLine(), out heltal))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
            }

            return heltal;

        }
    }
}
