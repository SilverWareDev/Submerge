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
        public static void Update()
        {
            RiptideServer.CurrentServer.Update();
            RiptideClient.CurrentClient.Update();
        }

        public async Task ConnectToServer(string ip, int port = 7777)
        {
            RiptideClient.CurrentClient.Connect($"{ip}:{port}");

            while (RiptideClient.CurrentClient.IsNotConnected) { Thread.Sleep(100); }

            while (SceneManager.GetActiveScene().name != "Main") { Thread.Sleep(100); }


        }
    }
}
