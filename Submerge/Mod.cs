using MelonLoader;
using Steamworks;
using System.Diagnostics;
using Submerge.Core;

namespace Submerge;

public class Mod : MelonMod
{
    public override void OnApplicationStart()
    {
        MelonLogger.Msg("Loading Submerge...");
    }

    public override void OnLateInitializeMelon()
    {
        InitSteam.Init();
    }
}
