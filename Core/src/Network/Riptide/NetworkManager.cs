using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Submerge.Network
{
    public class NetworkManager
    {
        public static bool IsServer = false;
        public static bool IsClient = false;

        public NetworkManager()
        {

        }

        public static void Update()
        {
            RiptideServer.CurrentServer.Update();
            RiptideClient.CurrentClient.Update();
        }

        public static async Task ConnectToServer(string ip, int port = 7777)
        {
            RiptideClient.CurrentClient.Connect($"{ip}:{port}");

            /* Crashes the game
            while (RiptideClient.CurrentClient.IsNotConnected) { Thread.Sleep(100); }

            while (SceneManager.GetActiveScene().name != "Main") { Thread.Sleep(100); }*/
        }
    }
}