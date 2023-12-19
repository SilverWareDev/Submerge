using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Submerge.Network
{
    /// <summary>
    /// Tags for Riptide Message handlers. Tag convention goes as follows:
    /// - 1-100: Player actions/events
    /// - 101-200: World actions/events
    /// - 201-300: Entity actions/events
    /// - 301-400: Connection
    /// </summary>
    public class MessageTags
    {
        public const ushort PlayerSpawn = 1;
        public const ushort PlayerTransform = 2;

        public const ushort Connect = 301;
        public const ushort PlayerInfo = 302;
    }
}
