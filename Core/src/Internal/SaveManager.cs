using Riptide;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submerge.Internal
{
    public class SaveManager
    {
        // this will do for now

        public static void CreateSaveHost()
        {
            IEnumerator startNewGame = uGUI_MainMenu.main.StartNewGame(GameMode.Creative);
            UWE.CoroutineHost.StartCoroutine(startNewGame);
        }
        public static void CreateSaveClient()
        {
            IEnumerator startNewGame = uGUI_MainMenu.main.StartNewGame(GameMode.Creative);
            UWE.CoroutineHost.StartCoroutine(startNewGame);
        }
    }
}
