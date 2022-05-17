using System;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class MainMenu : Screen
    {
        int maxOption;
        int xStart;
        int yStart;

        bool alteredColor;
        char cBlock;
        char cEmpty;
        char[,] bigLetter;

        int counter;
        int framesToChangeColor;


        public MainMenu(int actualOption) : base(actualOption)
        {
            maxOption = 2;

            xStart = C.GetScreenWidth() / 2 - 49;
            yStart = 2;

            alteredColor = false;
            cBlock = '█';
            cEmpty = ' ';
            bigLetter = new char[8, 5];

            counter = 0;
            framesToChangeColor = GameManager.GetFramesPerSecond() / 4;

            WriteTitle();
        }


        public override void Update(ConsoleKey key)
        {
            CheckTitleColor();
            CheckKey(key);
        }
        public override void Draw()
        {
            WriteMenu();
        }


        void WriteTitle(ConsoleColor color = ConsoleColor.Green)
        {
            SetLetter('P');
            WriteSetLetter(xStart, yStart, color);

            SetLetter('L');
            WriteSetLetter(xStart + 9, yStart, color);

            SetLetter('A');
            WriteSetLetter(xStart + 18, yStart, color);

            SetLetter('Y');
            WriteSetLetter(xStart + 27, yStart, color);

            SetLetter('E');
            WriteSetLetter(xStart + 36, yStart, color);

            SetLetter('R');
            WriteSetLetter(xStart + 45, yStart, color);

            SetLetter('T');
            WriteSetLetter(xStart + 63, yStart, color);

            SetLetter('E');
            WriteSetLetter(xStart + 72, yStart, color);

            SetLetter('S');
            WriteSetLetter(xStart + 81, yStart, color);

            SetLetter('T');
            WriteSetLetter(xStart + 90, yStart, color);
        }

        void SetLetter(char letter)
        {
            if (letter == 'P')
            {
                bigLetter = new char[7, 6] { { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock },
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty} };
            }
            else if (letter == 'L')
            {
                bigLetter = new char[7, 6] { { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty },
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock} };
            }
            else if (letter == 'A')
            {
                bigLetter = new char[7, 6] { { cEmpty, cBlock, cBlock, cBlock, cBlock, cEmpty },
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock} };
            }
            else if (letter == 'Y')
            {
                bigLetter = new char[7, 6] { { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock },
                                        { cBlock, cBlock, cEmpty, cEmpty, cBlock, cBlock},
                                        { cEmpty, cBlock, cBlock, cBlock, cBlock, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty} };
            }
            else if (letter == 'E')
            {
                bigLetter = new char[7, 6] { { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock },
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock} };
            }
            else if (letter == 'R')
            {
                bigLetter = new char[7, 6] { { cBlock, cBlock, cBlock, cBlock, cBlock, cEmpty },
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cBlock, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cBlock, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cBlock} };
            }
            else if (letter == 'T')
            {
                bigLetter = new char[7, 6] { { cBlock, cBlock, cBlock, cBlock, cBlock, cBlock },
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty},
                                        { cEmpty, cEmpty, cBlock, cBlock, cEmpty, cEmpty} };
            }
            else if (letter == 'S')
            {
                bigLetter = new char[7, 6] { { cEmpty, cBlock, cBlock, cBlock, cBlock, cBlock },
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cBlock, cEmpty, cEmpty, cEmpty, cEmpty, cEmpty},
                                        { cEmpty, cBlock, cBlock, cBlock, cBlock, cEmpty},
                                        { cEmpty, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cEmpty, cEmpty, cEmpty, cEmpty, cEmpty, cBlock},
                                        { cBlock, cBlock, cBlock, cBlock, cBlock, cEmpty} };
            }
        }
        void WriteSetLetter(int x, int y, ConsoleColor color = ConsoleColor.Gray)
        {
            ConsoleColor previousColor = Console.ForegroundColor;


            Console.ForegroundColor = color;

            C.GoToCoordinates(x, y);


            for (int i = 0; i < bigLetter.GetLength(0); i++)
            {
                for (int j = 0; j < bigLetter.GetLength(1); j++)
                {
                    Console.Write(bigLetter[i, j]);
                }

                C.GoToCoordinates(x, y + i + 1);
            }

            Console.ForegroundColor = previousColor;
        }

        void WriteMenu()
        {
            C.GoToCoordinates(C.GetScreenWidth() / 2 - 6, 15);
            WriteOption(1);

            C.GoToCoordinates(C.GetScreenWidth() / 2 - 6, 17);
            WriteOption(2);
        }
        void WriteOption(int optionNumber)
        {
            string optionText = "";


            switch (optionNumber)
            {
                case 1:
                    optionText = "PLAY";
                    break;

                case 2:
                    optionText = "QUIT";
                    break;
            }

            if (optionNumber == actualOption)
            {
                C.WriteInColor("--> " + optionText + " <--", ConsoleColor.Yellow);
            }
            else
            {
                Console.Write("    " + optionText + "    ");
            }
        }

        void CheckKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    ChangeOption(OptionChangeType.PREVIOUS, maxOption);
                    break;

                case ConsoleKey.DownArrow:
                    ChangeOption(OptionChangeType.NEXT, maxOption);
                    break;

                case ConsoleKey.Enter:
                    EnterOption();
                    break;
            }
        }
        void CheckTitleColor()
        {
            if (counter >= framesToChangeColor)
            {
                counter = 0;

                if (alteredColor)
                {
                    WriteTitle(ConsoleColor.Green);
                }
                else
                {
                    WriteTitle(ConsoleColor.Red);
                }

                alteredColor = !alteredColor;
            }
            else
            {
                counter++;
            }
        }

        protected override void EnterOption()
        {
            switch (actualOption)
            {
                case 1:
                    Console.Clear();
                    SceneManager.LoadScene(new Gameplay());
                    break;
                case 2:
                    GameManager.EndGame();
                    break;
            }
        }
    }
}
