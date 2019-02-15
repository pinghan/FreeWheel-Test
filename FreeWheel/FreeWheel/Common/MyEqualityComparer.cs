using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Models;

namespace FreeWheel.Common
{
    public class MyEqualityComparer : IEqualityComparer<MarketPop>
    {
        public bool Equals(MarketPop m1, MarketPop m2)
        {
            if (m2 == null && m1 == null)
                return true;
            else if (m1 == null || m2 == null)
                return false;
            else if (m1.CellId == m2.CellId && m1.MarketId == m2.MarketId)
                return true;
            else
                return false;
        }

        public int GetHashCode(MarketPop mp)
        {
            int hCode = mp.CellId;
            return hCode.GetHashCode();
        }
    }
}
