﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Common
{
   public static class EnumerableMethods
    {
        public static List<T> MakeList<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            return new List<T>(source);
        }
    }
}
