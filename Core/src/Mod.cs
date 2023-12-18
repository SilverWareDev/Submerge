using MelonLoader;
using Steamworks;
using System.Diagnostics;
using UnityEngine;

namespace Submerge;

public class Mod : MelonMod
{
    public override void OnApplicationStart()
    {
        MelonLogger.Msg("Loading Submerge...");
    }

    public override void OnLateInitializeMelon()
    {

    }

    public override void OnUpdate()
    {
        
    }

    // Please find a better way/place to do this
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        if (sceneName == "XMenu")
        {
            Submerge.Patching.MainMenu.CreateButton();
        }
    }
}
