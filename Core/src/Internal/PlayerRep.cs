using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Submerge.Internal
{
    public class PlayerRep
    {
        public byte PlayerId;

        public Vector3 Position;
        public Quaternion Rotation;

        public GameObject LocalRep = Player.mainObject;

        public PlayerRep(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
        }
    }
}
