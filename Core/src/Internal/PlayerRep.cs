using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace Submerg.Internal
{
    public class PlayerRep
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public GameObject LocalRep = Player.mainObject;

        public PlayerRep(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
        }

        /*public static void CheckForRep() 
        {
            if (Player.mainObject != null)
            {
                MelonLogger.Msg("Player isnt null");
            }
            else
            {
                MelonLogger.Msg("Player is null or not found");
            }
        }*/
    }
}
