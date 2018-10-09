using System;
using System.Collections.Generic;
using System.Text;

namespace IEX
{
    public abstract class IEXResponse
    {
        internal abstract void Deserialize(string data);
    }
}
