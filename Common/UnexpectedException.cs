using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Common
{
    [Serializable]
    public sealed class UnexpectedException : Exception
    {
        private readonly object[] _args_;

        public object[] Arguments
        {
            get
            {
                return this._args_;
            }
        }

        public UnexpectedException(string message, params object[] args) : base(message)
        {
            this._args_ = (args ?? new object[0]);
        }
    }
}
