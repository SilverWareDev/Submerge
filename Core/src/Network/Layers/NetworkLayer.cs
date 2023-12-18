using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submerge.Network
{
    public abstract class NetworkLayer
    {
        internal abstract void OnInitializeLayer();

        internal abstract void OnLateInitializeLayer();

        internal abstract void SendToAll(SubmergeMessage message);
    }
}
