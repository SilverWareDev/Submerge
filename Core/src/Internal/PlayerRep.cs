using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Submerg.Internal
{
    public class PlayerRep
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public GameObject Rep;

        public PlayerRep(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
        }

        public void Update() 
        {
        
        }
    }
}
