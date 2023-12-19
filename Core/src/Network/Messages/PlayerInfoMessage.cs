using Riptide;
using Submerge.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Submerge.Network
{
    public class PlayerInfoMessage
    {
        public Message Create(Transform transform, PlayerRep player)
        {
            var msg = Message.Create(MessageSendMode.Reliable);

            // Position
            msg.AddFloat(transform.position.x);
            msg.AddFloat(transform.position.y);
            msg.AddFloat(transform.position.z);

            return msg.Add();
        }

        [MessageHandler(MessageTags.PlayerInfo)]
        public static void HandleClient(Message message)
        {

        }

        [MessageHandler(MessageTags.PlayerInfo)]
        public static void HandleServer(ushort clientId, Message message)
        {

        }
    }
}
