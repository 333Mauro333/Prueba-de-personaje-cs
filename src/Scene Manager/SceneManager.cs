using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgtvPlayerTestCs
{
    static class SceneManager
    {
        static Scene scene = null;

        public static Scene GetActualScene()
        {
            return scene;
        }
        public static void LoadScene(Scene newScene)
        {
            scene = newScene;
        }
    }
}
