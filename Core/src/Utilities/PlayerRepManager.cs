using Submerge.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Submerge.Utilities
{
    public class PlayerRepManager
    {
        public static PlayerRep LocalRep = new(new());
        public static List<PlayerRep> ActiveReps = new List<PlayerRep>();

        public static List<byte> PlayerIds = new List<byte>();

        public static void CreateRep(Transform transform)
        {

        }

        public static void UpdateReps()
        {

        }
    }
}
