using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submerge.Network
{
    public abstract class NetworkLayer
    {
        private Type _type;
        private bool _hasType;

        /// <summary>
        /// The Type of this NetworkLayer.
        /// </summary>
        internal Type Type
        {
            get
            {
                if (!_hasType)
                {
                    _type = GetType();
                    _hasType = true;
                }
                return _type;
            }
        }

        internal virtual string Title => Type.AssemblyQualifiedName;

        internal virtual bool IsServer => false;

        internal virtual bool IsClient => false;
    }
}
