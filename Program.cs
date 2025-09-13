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

            Console.WriteLine("Din Karta");
            SkrivUtKarta(playerMap);

            Console.WriteLine();

            //Console.WriteLine("Datorns Karta");
            //SkrivUtKarta(computerMap);


            while (true)
            {
                
                if (antalHitsSpelare == 3 || antalHitsDator == 3)
                {
                    break;
                }

                SpealreplaceraSkott(computerMap);
                SkrivUtKarta(displayComputerMap);
                
                Thread.Sleep(500);
                
                DatornPlacerarSkott(playerMap);
                SkrivUtKarta(playerMap);

            }

            Console.WriteLine();

            if (antalHitsSpelare == 3)
            {
                Console.WriteLine("Grattis du vann!");
            }
            else
            {
                Console.WriteLine("Tyvärr du förlorade!");
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
                    Console.Write(map[i, j]);
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

                Console.WriteLine("Placera ditt skott. Ange X-kordinat (1-6)");
                col = GetInt();

                if (col < 1 || col > 6)
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen.");
                    continue;
                }


                do
                {

                    Console.WriteLine("Placera ditt skott. Ange Y-kordinat (1-4)");
                    row = GetInt();

                    if (row < 1 || row > 4)
                    {
                        Console.WriteLine("Ogiltig inmatning. Försök igen.");
                    }

                } while (row < 1 || row > 4);

                row--;  //Görs om till index då index börjar på 0
                col--;  //Görs om till index då index börjar på 0

                // Kontrollera om spelaren redan har skjutit här
                if (displayComputerMap[row, col] == "T" || displayComputerMap[row, col] == "-")
                {
                    Console.WriteLine("Redan skjutit där. Sikta om!");
                    validInput = false;
                    continue;

                }

                if (map[row, col] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    displayComputerMap[row, col] = "T";
                    Console.WriteLine("Träff!");
                    antalHitsSpelare++;

                }
                else if (map[row, col] == " ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    displayComputerMap[row, col] = "-";
                    Console.WriteLine("Miss!");
                }
                else
                {
                    Console.WriteLine("Något gick fel. Försök igen.");
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

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    playerMap[row, col] = "T";
                    Console.WriteLine("Datorn träffa!");
                    antalHitsDator++;
                    break;


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    playerMap[row, col] = "-";
                    Console.WriteLine("Datorn missa!");
                    break;
                }
            }
            Console.WriteLine();


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
