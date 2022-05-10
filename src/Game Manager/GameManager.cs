using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class GameManager
    {
        bool inGame;
        int framesPerSecond;


        public GameManager()
        {
            inGame = true;
            framesPerSecond = 30;

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

        void Init()
        {
            SceneManager.LoadScene(new Gameplay());
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
