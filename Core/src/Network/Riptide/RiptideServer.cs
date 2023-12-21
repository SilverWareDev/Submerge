using Riptide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Submerge.Network.RiptideClient;

namespace Submerge.Network
{
    public class RiptideServer
    {
        public static Server CurrentServer = new();

        public static void StartServer(int port = 7777, byte playerCount = 4)
        {
            if (CurrentServer.IsRunning)
                CurrentServer.Stop();

            if (CurrentClient.IsConnected)
                CurrentClient.Disconnect();

            CurrentServer.Start(7777, 8);
        }
    }
}
