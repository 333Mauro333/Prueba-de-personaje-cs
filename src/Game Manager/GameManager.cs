using System;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class GameManager
    {
        static bool inGame;
        static int framesPerSecond;


        public GameManager()
        {
            inGame = true;
            framesPerSecond = 60;

            C.HideCursor();
        }


        public void Run()
        {
            Init();

            while (inGame)
            {
                Update();
                Draw();

                LimitFrames();
            }
        }

        public static void EndGame()
        {
            inGame = false;
        }
        public static int GetFramesPerSecond()
        {
            return framesPerSecond;
        }


        void Init()
        {
            SceneManager.LoadScene(new MainMenu(1));
        }
        void Update()
        {
            ConsoleKey ck = 0;

            if (Console.KeyAvailable)
            {
                ck = Console.ReadKey(true).Key;
            }

            SceneManager.GetActualScene().Update(ck);
        }
        void Draw()
        {
            SceneManager.GetActualScene().Draw();
        }

        void LimitFrames()
        {
            C.Sleep(1000 / framesPerSecond);
        }
    }
}
