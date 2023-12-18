// Do not put this into Utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;

namespace Submerge.Core
{
    public class InitSteam
    {
        public static void Init()
        {
            if (!SteamAPI.Init())
            {
                MelonLoader.MelonLogger.Error("SteamAPI Init failed!");
                return;
            }
            Steamworks.CSteamID steamID = Steamworks.SteamUser.GetSteamID();
            MelonLoader.MelonLogger.Msg("SteamID: " + steamID);
        }
    }
}
