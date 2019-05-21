using System;
using System.Collections.Generic;
using System.Text;

namespace solid.practices.Core.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}
